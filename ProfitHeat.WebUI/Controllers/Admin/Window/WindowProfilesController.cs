using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Controllers.Admin.Window
{
    [Authorize(Roles = "admin")]
    public class WindowProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WindowProfiles
        public ActionResult Index()
        {
            var windowsProfiles = db.WindowsProfiles.Include(w => w.ManufacturerWindowProfile);
            return View(windowsProfiles.ToList());
        }

        // GET: WindowProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindowProfile windowProfile = db.WindowsProfiles.Find(id);
            if (windowProfile == null)
            {
                return HttpNotFound();
            }
            return View(windowProfile);
        }

        // GET: WindowProfiles/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerWindowProfileID = new SelectList(db.ManufacturerWindowProfiles, "ManufacturerWindowProfileID", "TitleCompany");
            return View();
        }

        // POST: WindowProfiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WindowProfileID,ManufacturerWindowProfileID,TitleMark,CountCameras,Thickness,HeatResistanceCoefficient")] WindowProfile windowProfile)
        {
            if (ModelState.IsValid)
            {
                db.WindowsProfiles.Add(windowProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerWindowProfileID = new SelectList(db.ManufacturerWindowProfiles, "ManufacturerWindowProfileID", "TitleCompany", windowProfile.ManufacturerWindowProfileID);
            return View(windowProfile);
        }

        // GET: WindowProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindowProfile windowProfile = db.WindowsProfiles.Find(id);
            if (windowProfile == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerWindowProfileID = new SelectList(db.ManufacturerWindowProfiles, "ManufacturerWindowProfileID", "TitleCompany", windowProfile.ManufacturerWindowProfileID);
            return View(windowProfile);
        }

        // POST: WindowProfiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WindowProfileID,ManufacturerWindowProfileID,TitleMark,CountCameras,Thickness,HeatResistanceCoefficient")] WindowProfile windowProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(windowProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerWindowProfileID = new SelectList(db.ManufacturerWindowProfiles, "ManufacturerWindowProfileID", "TitleCompany", windowProfile.ManufacturerWindowProfileID);
            return View(windowProfile);
        }

        // GET: WindowProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindowProfile windowProfile = db.WindowsProfiles.Find(id);
            if (windowProfile == null)
            {
                return HttpNotFound();
            }
            return View(windowProfile);
        }

        // POST: WindowProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WindowProfile windowProfile = db.WindowsProfiles.Find(id);
            db.WindowsProfiles.Remove(windowProfile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
