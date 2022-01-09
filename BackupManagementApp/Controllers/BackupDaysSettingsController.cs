using BackupManagementApp.Models;
using BackupManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackupManagementApp.Controllers
{
    public class BackupDaysSettingsController : Controller
    {
        // GET: BackupDaysSettings
        ApplicationDbContext _context;
        public BackupDaysSettingsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var viewModel = new BackupDaysSettingsViewModel
            {
                Day = _context.Days.SingleOrDefault(d => d.IsWeeklyTape==true),
                Days = _context.Days.ToList()
            };
            if(User.IsInRole(RoleName.CanManageTapes))               
                return View("Index",viewModel);

            return View("ReadOnlySettings", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BackupDaysSettingsViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BackupDaysSettingsViewModel
                {
                    Day = _context.Days.SingleOrDefault(d => d.IsWeeklyTape == true),
                    Days = _context.Days.ToList()
                };
                return View("Index", viewModel);
            }
            for (int i = 0; i < viewmodel.Days.Count(); i++)
            {
                var dayInDb = _context.Days.Single(c => c.Id == i + 1);
                dayInDb.IsDailyTape = viewmodel.Days[i].IsDailyTape;
            }

            var weeklyDay = _context.Days.Single(c => c.Id == viewmodel.Day.Id);
            ResetWeeklyState();
            weeklyDay.IsWeeklyTape = true;           
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [NonAction]
        public void ResetWeeklyState()
        {
            var days = _context.Days.ToList();
            foreach (var day in days)
            {
                day.IsWeeklyTape = false;
            }
            _context.SaveChanges();
        }
    }
}