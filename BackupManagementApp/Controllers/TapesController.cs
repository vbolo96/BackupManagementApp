using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BackupManagementApp.ViewModels;

namespace BackupManagementApp.Controllers
{
    public class TapesController : Controller
    {
        public ApplicationDbContext _context;
        public TapesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Tapes
        public ActionResult Index()
        {
            //using eager loading "Include" to add backupsystem and types in the same query -> performance optimization
            var tapes = _context.Tapes.Include(c => c.BackupSystem).Include(c=>c.BackupTypes).ToList();
            if (User.IsInRole(RoleName.CanManageTapes))
                return View("List",tapes);
                      
            return View("ReadOnlyList",tapes);
        }

        [Authorize(Roles=RoleName.CanManageTapes)]
        public ActionResult Edit(int id)
        {            
            var tape = _context.Tapes.SingleOrDefault(c => c.Id == id);
            if (tape == null)
                return HttpNotFound();
            var viewModel = new TapeFormViewModel(tape)
            {
                BackupTypes = _context.BackupTypes.ToList(),
                BackupSystems = _context.BackupSystems.ToList(),
                Days = _context.Days.ToList(),
                Weeks = _context.Weeks.ToList(),
                Months = _context.Months.ToList()
            };

            return View("TapeForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageTapes)]
        public ActionResult New()
        {
            
            var viewModel = new TapeFormViewModel
            {              
                BackupTypes = _context.BackupTypes.ToList(),
                BackupSystems = _context.BackupSystems.ToList(),
                Days = _context.Days.ToList(),
                Weeks = _context.Weeks.ToList(),
                Months = _context.Months.ToList()
            };
            return View("TapeForm", viewModel);          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Tape tape)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TapeFormViewModel(tape)
                {
                    BackupTypes = _context.BackupTypes.ToList(),
                    BackupSystems = _context.BackupSystems.ToList(),
                    Days = _context.Days.ToList(),
                    Weeks = _context.Weeks.ToList(),
                    Months = _context.Months.ToList()
                };
                return View("TapeForm", viewModel);
            }
            if (tape.Id == 0)//it means we are adding a new tape
            {              
                _context.Tapes.Add(tape);
            }
            else
            {
                var tapeInDb = _context.Tapes.Single(c => c.Id == tape.Id);//we are editing the  existing one from parameter
                tapeInDb.BarCode = tape.BarCode;
                tapeInDb.BackupSystemId = tape.BackupSystemId;
                tapeInDb.BackupTypesId = tape.BackupTypesId;
                tapeInDb.DayId = tape.DayId;
                tapeInDb.WeekId = tape.WeekId;
                tapeInDb.MonthId = tape.MonthId;
                tapeInDb.Details = tape.Details;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Tapes");
        }
        [Authorize(Roles = RoleName.CanManageTapes)]
        public ActionResult Delete(int id)
        {
            var tape = _context.Tapes.SingleOrDefault(c => c.Id == id);
            _context.Tapes.Remove(tape);
            _context.SaveChanges();
            return RedirectToAction("Index","Tapes");
        }
    }
}