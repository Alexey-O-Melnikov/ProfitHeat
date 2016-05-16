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
    public class ManufacturerWindowProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManufacturerWindowProfiles
        public ActionResult Index()
        {
            return View(db.ManufacturerWindowProfiles.ToList());
        }

        // GET: ManufacturerWindowProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerWindowProfile manufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(id);
            if (manufacturerWindowProfile == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerWindowProfile);
        }

        // GET: ManufacturerWindowProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerWindowProfiles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufacturerWindowProfileID,TitleCompany")] ManufacturerWindowProfile manufacturerWindowProfile)
        {
            if (ModelState.IsValid)
            {
                db.ManufacturerWindowProfiles.Add(manufacturerWindowProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturerWindowProfile);
        }

        // GET: ManufacturerWindowProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerWindowProfile manufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(id);
            if (manufacturerWindowProfile == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerWindowProfile);
        }

        // POST: ManufacturerWindowProfiles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufacturerWindowProfileID,TitleCompany")] ManufacturerWindowProfile manufacturerWindowProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturerWindowProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturerWindowProfile);
        }

        // GET: ManufacturerWindowProfiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerWindowProfile manufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(id);
            if (manufacturerWindowProfile == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerWindowProfile);
        }

        // POST: ManufacturerWindowProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufacturerWindowProfile manufacturerWindowProfile = db.ManufacturerWindowProfiles.Find(id);
            db.ManufacturerWindowProfiles.Remove(manufacturerWindowProfile);
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
