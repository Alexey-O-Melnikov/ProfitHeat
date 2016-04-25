using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProfitHeat.Domain;

namespace ProfitHeat.WebUI.Controllers.Admin
{
    public class ManufacturerRadiatorsController : Controller
    {
        private StoreEFContext db = new StoreEFContext();

        // GET: ManufacturerRadiators
        public ActionResult Index()
        {
            return View(db.ManufacturerRadiators.ToList());
        }

        // GET: ManufacturerRadiators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerRadiator manufacturerRadiator = db.ManufacturerRadiators.Find(id);
            if (manufacturerRadiator == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerRadiator);
        }

        // GET: ManufacturerRadiators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManufacturerRadiators/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManufacturerRadiatorID,TitleCompany")] ManufacturerRadiator manufacturerRadiator)
        {
            if (ModelState.IsValid)
            {
                db.ManufacturerRadiators.Add(manufacturerRadiator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturerRadiator);
        }

        // GET: ManufacturerRadiators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerRadiator manufacturerRadiator = db.ManufacturerRadiators.Find(id);
            if (manufacturerRadiator == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerRadiator);
        }

        // POST: ManufacturerRadiators/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManufacturerRadiatorID,TitleCompany")] ManufacturerRadiator manufacturerRadiator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturerRadiator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturerRadiator);
        }

        // GET: ManufacturerRadiators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManufacturerRadiator manufacturerRadiator = db.ManufacturerRadiators.Find(id);
            if (manufacturerRadiator == null)
            {
                return HttpNotFound();
            }
            return View(manufacturerRadiator);
        }

        // POST: ManufacturerRadiators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManufacturerRadiator manufacturerRadiator = db.ManufacturerRadiators.Find(id);
            db.ManufacturerRadiators.Remove(manufacturerRadiator);
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
