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
    public class GlassesController : Controller
    {
        private StoreEFContext db = new StoreEFContext();

        // GET: Glasses
        public ActionResult Index()
        {
            return View(db.Glases.ToList());
        }

        // GET: Glasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glases.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // GET: Glasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glasses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlassID,Type,HeatResistanceCoefficient")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                db.Glases.Add(glass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glass);
        }

        // GET: Glasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glases.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // POST: Glasses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlassID,Type,HeatResistanceCoefficient")] Glass glass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glass);
        }

        // GET: Glasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glass glass = db.Glases.Find(id);
            if (glass == null)
            {
                return HttpNotFound();
            }
            return View(glass);
        }

        // POST: Glasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glass glass = db.Glases.Find(id);
            db.Glases.Remove(glass);
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
