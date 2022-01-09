using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BackupManagementApp.Controllers
{
    public class HistoryController : Controller
    {

        ApplicationDbContext _context;
        public HistoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: History
        [Authorize]
        public ActionResult Index()
        {
            var history = _context.History.Include(h=>h.BackupSystem)
                                            .Include(h => h.BackupSystem)
                                            .Include(h => h.BackupTypes)
                                            .Include(h => h.Day)
                                            .Include(h => h.Month)
                                            .Include(h => h.Week).ToList();
            return View(history);
        }
    }
}