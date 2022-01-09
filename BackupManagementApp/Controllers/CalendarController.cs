using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackupManagementApp.ViewModels;

namespace BackupManagementApp.Controllers
{
    public class CalendarController : Controller
    {
        ApplicationDbContext _context;
        public CalendarController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Calendar
        public ActionResult Index(int? year, int? month)
        {
            var viewmodel = new CalendarViewModel();
            if (year != null && month != null)
            {
                if (month == 13)
                {
                    month = 1;
                    year++;
                }

                if (month == 0)
                {
                    month = 12;
                    year--;
                }

                ViewBag.Year = year;
                ViewBag.Month = month;
                viewmodel.Weeks = GetListOfWeeksInCurrentMonth(new DateTime(ViewBag.Year, ViewBag.Month, 1));              
            }
            else 
            {
                viewmodel.Weeks = GetListOfWeeksInCurrentMonth(DateTime.Now);             
            }
            return View(viewmodel);
        }

        public List<DateTime> GetListOfWeeksInCurrentMonth(DateTime DateInCalendar)//counting number of weeks of the current month based on the weekly backup day
        {
            List<DateTime> weeks = new List<DateTime>();

            var weeklyBackupDay = _context.Days.Single(d => d.IsWeeklyTape == true);
            DateTime nextmonth = DateInCalendar.AddMonths(1);
            DateTime firstDayOfTheMonth = new DateTime(DateInCalendar.Year, DateInCalendar.Month, 1);

            for (var d = firstDayOfTheMonth; d < new DateTime(nextmonth.Year, nextmonth.Month, 1); d = d.AddDays(1))//iterating through current month days
            {
                if (d.DayOfWeek.ToString() == weeklyBackupDay.Name.ToString())
                {
                    weeks.Add(d);//adding all weekly backup dates of current month in the list
                }
            }

            return weeks;
        }
    }
}