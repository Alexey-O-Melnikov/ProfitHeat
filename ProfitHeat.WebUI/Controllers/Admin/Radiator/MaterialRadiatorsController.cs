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
    public class MaterialRadiatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaterialRadiators
        public ActionResult Index()
        {
            return View(db.MaterialRadiators.ToList());
        }

        // GET: MaterialRadiators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRadiator materialRadiator = db.MaterialRadiators.Find(id);
            if (materialRadiator == null)
            {
                return HttpNotFound();
            }
            return View(materialRadiator);
        }

        // GET: MaterialRadiators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialRadiators/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialRadiatorID,TitleMaterialRadiator")] MaterialRadiator materialRadiator)
        {
            if (ModelState.IsValid)
            {
                db.MaterialRadiators.Add(materialRadiator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialRadiator);
        }

        // GET: MaterialRadiators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRadiator materialRadiator = db.MaterialRadiators.Find(id);
            if (materialRadiator == null)
            {
                return HttpNotFound();
            }
            return View(materialRadiator);
        }

        // POST: MaterialRadiators/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialRadiatorID,TitleMaterialRadiator")] MaterialRadiator materialRadiator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialRadiator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialRadiator);
        }

        // GET: MaterialRadiators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialRadiator materialRadiator = db.MaterialRadiators.Find(id);
            if (materialRadiator == null)
            {
                return HttpNotFound();
            }
            return View(materialRadiator);
        }

        // POST: MaterialRadiators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialRadiator materialRadiator = db.MaterialRadiators.Find(id);
            db.MaterialRadiators.Remove(materialRadiator);
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
