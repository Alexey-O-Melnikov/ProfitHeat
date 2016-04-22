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
    public class RadiatorsController : Controller
    {
        private StoreEFContext db = new StoreEFContext();

        // GET: Radiators
        public ActionResult Index()
        {
            return View(db.Radiators.ToList());
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
            return View();
        }

        // POST: Radiators/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RadiatorID,RadiatorType,Material,PowerSection")] Radiator radiator)
        {
            if (ModelState.IsValid)
            {
                db.Radiators.Add(radiator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(radiator);
        }

        // POST: Radiators/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RadiatorID,RadiatorType,Material,PowerSection")] Radiator radiator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(radiator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
