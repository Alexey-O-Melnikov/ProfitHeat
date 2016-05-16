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
    [Authorize(Roles = "admin")]
    public class RadiatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Radiators
        public ActionResult Index()
        {
            var radiators = db.Radiators.Include(r => r.ManufacturerRadiator).Include(r => r.Material);
            return View(radiators.ToList());
        }

        // GET: Radiators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiator radiator = db.Radiators.Find(id);
            if (radiator == null)
            {
                return HttpNotFound();
            }
            return View(radiator);
        }

        // GET: Radiators/Create
        public ActionResult Create()
        {
            ViewBag.ManufacturerRadiatorID = new SelectList(db.ManufacturerRadiators, "ManufacturerRadiatorID", "TitleCompany");
            ViewBag.MaterialRadiatorID = new SelectList(db.MaterialRadiators, "MaterialRadiatorID", "TitleMaterialRadiator");
            return View();
        }

        // POST: Radiators/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadiatorID,ManufacturerRadiatorID,MaterialRadiatorID,TitleModel,ThermalPower")] Radiator radiator)
        {
            if (ModelState.IsValid)
            {
                db.Radiators.Add(radiator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManufacturerRadiatorID = new SelectList(db.ManufacturerRadiators, "ManufacturerRadiatorID", "TitleCompany", radiator.ManufacturerRadiatorID);
            ViewBag.MaterialRadiatorID = new SelectList(db.MaterialRadiators, "MaterialRadiatorID", "TitleMaterialRadiator", radiator.MaterialRadiatorID);
            return View(radiator);
        }

        // GET: Radiators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiator radiator = db.Radiators.Find(id);
            if (radiator == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManufacturerRadiatorID = new SelectList(db.ManufacturerRadiators, "ManufacturerRadiatorID", "TitleCompany", radiator.ManufacturerRadiatorID);
            ViewBag.MaterialRadiatorID = new SelectList(db.MaterialRadiators, "MaterialRadiatorID", "TitleMaterialRadiator", radiator.MaterialRadiatorID);
            return View(radiator);
        }

        // POST: Radiators/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadiatorID,ManufacturerRadiatorID,MaterialRadiatorID,TitleModel,ThermalPower")] Radiator radiator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radiator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManufacturerRadiatorID = new SelectList(db.ManufacturerRadiators, "ManufacturerRadiatorID", "TitleCompany", radiator.ManufacturerRadiatorID);
            ViewBag.MaterialRadiatorID = new SelectList(db.MaterialRadiators, "MaterialRadiatorID", "TitleMaterialRadiator", radiator.MaterialRadiatorID);
            return View(radiator);
        }

        // GET: Radiators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Radiator radiator = db.Radiators.Find(id);
            if (radiator == null)
            {
                return HttpNotFound();
            }
            return View(radiator);
        }

        // POST: Radiators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Radiator radiator = db.Radiators.Find(id);
            db.Radiators.Remove(radiator);
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
