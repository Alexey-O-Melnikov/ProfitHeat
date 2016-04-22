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
    public class TypeRoomsController : Controller
    {
        private StoreEFContext db = new StoreEFContext();

        // GET: TypeRooms
        public ActionResult Index()
        {
            return View(db.TypesRooms.ToList());
        }

        // GET: TypeRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRoom typeRoom = db.TypesRooms.Find(id);
            if (typeRoom == null)
            {
                return HttpNotFound();
            }
            return View(typeRoom);
        }

        // GET: TypeRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeRooms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeRoomID,ComfortableTemperature,AirChange")] TypeRoom typeRoom)
        {
            if (ModelState.IsValid)
            {
                db.TypesRooms.Add(typeRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeRoom);
        }

        // GET: TypeRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRoom typeRoom = db.TypesRooms.Find(id);
            if (typeRoom == null)
            {
                return HttpNotFound();
            }
            return View(typeRoom);
        }

        // POST: TypeRooms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeRoomID,ComfortableTemperature,AirChange")] TypeRoom typeRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeRoom);
        }

        // GET: TypeRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeRoom typeRoom = db.TypesRooms.Find(id);
            if (typeRoom == null)
            {
                return HttpNotFound();
            }
            return View(typeRoom);
        }

        // POST: TypeRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeRoom typeRoom = db.TypesRooms.Find(id);
            db.TypesRooms.Remove(typeRoom);
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
