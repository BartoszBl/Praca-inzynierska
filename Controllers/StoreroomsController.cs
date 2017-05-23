using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Praca_dyplomowa.Models;

namespace Praca_dyplomowa.Controllers
{
    [Authorize]
    public class StoreroomsController : Controller
    {
        private GabinetWetDBEntities3 db = new GabinetWetDBEntities3();

        // GET: Storerooms
        public ActionResult Index()
        {
            return View(db.Storeroom.ToList());
        }

        // GET: Storerooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storeroom storeroom = db.Storeroom.Find(id);
            if (storeroom == null)
            {
                return HttpNotFound();
            }
            return View(storeroom);
        }

        // GET: Storerooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Storerooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa_leku,Data_waznosci,Ilosc")] Storeroom storeroom)
        {
            if (ModelState.IsValid)
            {
                db.Storeroom.Add(storeroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storeroom);
        }

        // GET: Storerooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storeroom storeroom = db.Storeroom.Find(id);
            if (storeroom == null)
            {
                return HttpNotFound();
            }
            return View(storeroom);
        }

        // POST: Storerooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa_leku,Data_waznosci,Ilosc")] Storeroom storeroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storeroom);
        }

        // GET: Storerooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storeroom storeroom = db.Storeroom.Find(id);
            if (storeroom == null)
            {
                return HttpNotFound();
            }
            return View(storeroom);
        }

        // POST: Storerooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Storeroom storeroom = db.Storeroom.Find(id);
            db.Storeroom.Remove(storeroom);
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
