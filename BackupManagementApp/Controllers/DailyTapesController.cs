using BackupManagementApp.Models;
using BackupManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackupManagementApp.Controllers
{
    public class DailyTapesController : Controller
    {
        // GET: DailyTapes
        ApplicationDbContext _context;
        public DailyTapesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //creating new viewmodel containing the list of tapes for today's backup
            var viewmodel = new DailyTapesViewModel
            {
                Tapes = GetDailyTapesList(),
                CheckingDate = DateTime.Now,
                BackupSystems = _context.BackupSystems.ToList(),
                BackupTypes = _context.BackupTypes.ToList(),
                Days = _context.Days.ToList(),
                Weeks = _context.Weeks.ToList(),
                Months = _context.Months.ToList(),
                CheckStatus = GetDailyTapesStatus()
            };
            if(User.IsInRole(RoleName.CanManageTapes))
                 return View("List",viewmodel);
            return View("ReadOnlyList", viewmodel);
        }
        [Authorize(Roles=RoleName.CanManageTapes)]
        public ActionResult OpenCheckTape(int id)
        {
            var tape = new Tape();
            tape = (Tape)_context.Tapes.SingleOrDefault(t => t.Id == id);//getting the selected tape          
            var viewmodel = new DailyTapesViewModel(tape)//passing tape in view model constructor for initializing the form values
            {
                CheckingDate = DateTime.Now,
                BackupSystems = _context.BackupSystems.ToList(),
                BackupTypes = _context.BackupTypes.ToList(),
                Days = _context.Days.ToList(),
                Weeks = _context.Weeks.ToList(),
                Months = _context.Months.ToList()
            };
            return View("CheckDailyTape",viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageTapes)]
        public ActionResult CheckTape(DailyTapesViewModel viewmodel)//the checktape action which is adding the tape in the history table
        {
            var date = viewmodel.CheckingDate;
            var code = viewmodel.BarCode;
            var checkedTape = _context.History.SingleOrDefault(t => t.BarCode == code);
            if (checkedTape==null || (checkedTape != null && checkedTape.CheckedDate.Date != date.Date))//checking if the tape was not already checked today
            {
                History HistoryObject = new History();
                HistoryObject.BarCode = viewmodel.BarCode;
                HistoryObject.BackupSystemId = (byte)viewmodel.BackupSystemId;
                HistoryObject.BackupTypesId = (byte)viewmodel.BackupTypesId;
                HistoryObject.DayId = (byte)viewmodel.DayId;
                HistoryObject.WeekId = viewmodel.WeekId;
                HistoryObject.MonthId = viewmodel.MonthId;
                HistoryObject.Details = viewmodel.Details;
                HistoryObject.CheckedDate = date;
                _context.History.Add(HistoryObject);
                _context.SaveChanges();            
            }
            return RedirectToAction("Index", "DailyTapes");
        }
        
        
        
        [NonAction]
        public string GetMonthName(int x)//returning month name using month number given as parameter
        {
            string[] months = new string[13];
            months[1] = "January"; months[2] = "February"; months[3] = "March"; months[4] = "April"; months[5] = "May"; months[6] = "June";
            months[7] = "July"; months[8] = "August"; months[9] = "September"; months[10] = "October"; months[11] = "November"; months[12] = "December";
            return months[x];
        }
        [NonAction]
        public int GetDayId(string name)//method for returning week day index
        {
            int id = 0; ;
            switch (name) 
            {
                case "Monday":                                  
                    return id=1;                   
                case "Tuesday":
                    return id=2; 
                case "Wednesday":
                    return id=3;
                case "Thursday":
                    return id=4;
                case "Friday":
                    return id=5;
                case "Saturday":
                    return id=6;
                case "Sunday":
                    return id=7;
            }
            return id;
        }
        [NonAction]

        public List<string> GetListOfWeeksInCurrentMonth(DateTime today)//counting number of weeks of the current month based on the weekly backup day
        {
            List<string> weeks = new List<string>();

            var weeklyBackupDay = _context.Days.Single(d => d.IsWeeklyTape == true);
            DateTime nextmonth = today.AddMonths(1);
            DateTime firstDayOfTheMonth = new DateTime(today.Year, today.Month, 1);
            
            for (var d = firstDayOfTheMonth; d < new DateTime(nextmonth.Year,nextmonth.Month,1); d=d.AddDays(1))//iterating through current month days
            {
                if (d.DayOfWeek.ToString() == weeklyBackupDay.Name.ToString())
                {
                    weeks.Add(d.Date.ToShortDateString());//adding all weekly backup dates of current month in the list
                }
            }

            return weeks;
        }
        [NonAction]
        public List<bool> GetDailyTapesStatus()
        {
            List<bool> DailyTapesStatus = new List<bool>();
            var DailyTapes = GetDailyTapesList();
            foreach (var tape in DailyTapes)
            {
                var today = DateTime.Now.Date;
                var checkedTape = _context.History.Where(t => t.BarCode == tape.BarCode).ToList();
                int index=checkedTape.Count;
                if (index == 0 || (index != 0 && checkedTape[index-1].CheckedDate.ToShortDateString() != today.ToShortDateString()))
                {
                    DailyTapesStatus.Add(true);
                }
                else
                {
                    DailyTapesStatus.Add(false);
                }
            }
            return DailyTapesStatus;
        }

        [NonAction]
        public List<Tape> GetDailyTapesList()
        {
            var DailyTapes= new List<Tape>();//list of daily tapes
            var weeks = GetListOfWeeksInCurrentMonth(DateTime.Now);//list of dates for weekly/monthly backup
            var dailyBackupDaysFromDb = _context.Days.Where(d => d.IsDailyTape == true).ToList();//list of daily backup days
            var weeklyBackupDay = _context.Days.Single(d => d.IsWeeklyTape == true);//the day for weekly backup 

            List<string> dailyBackupDays = new List<string>();//list with the names of daily backup
            foreach (var day in dailyBackupDaysFromDb)
            {
                dailyBackupDays.Add(day.Name);
            }
            var today = DateTime.Now;
            var todayName = today.DayOfWeek.ToString();
            var todayId = GetDayId(todayName);// the ID for today
            if (dailyBackupDays.Contains(todayName))//if today is a daily backup day
            {                
                DailyTapes = _context.Tapes.Where(t => (t.DayId == todayId && t.BackupTypesId==BackupTypes.DailyBackup)).ToList();// getting the list of today tapes where type is daily and the dayId is the same for today
            }
            else if (weeklyBackupDay.Name.ToString() == todayName)//if today is a weekly backup day
            {
                if (weeks.IndexOf(today.ToShortDateString()) != 0)//means it's a weekly backup day with the weekID == week.IndexOf(today)
                {
                    int WeekId = weeks.IndexOf(today.Date.ToShortDateString());
                    DailyTapes = _context.Tapes.Where(t => (t.DayId == todayId && t.BackupTypesId == BackupTypes.WeeklyBackup && t.WeekId == WeekId  && t.MonthId==null)).ToList();
                }
                else // means it's a monthly backup day, so we need the tapes for previous month
                {
                    int previousMonthId = today.AddMonths(-1).Month;
                    DailyTapes = _context.Tapes.Where(t => (t.DayId == todayId && (t.BackupTypesId == BackupTypes.MonthlyBackup || t.BackupTypesId==BackupTypes.YearlyBackup) && t.WeekId == null && t.MonthId==previousMonthId)).ToList();
                }                
            }
            return DailyTapes;
        }
    }
}