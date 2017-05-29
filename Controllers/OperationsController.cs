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
    public class OperationsController : Controller
    {
        private GabinetWetDBEntities3 db = new GabinetWetDBEntities3();

        // GET: Operations
        public ActionResult Index()
        {
            return View(db.Operations.ToList());
        }


        [HttpPost]
        public ActionResult Index(string ZnajdzZabieg)
        {

            var zabieg = from i in db.Operations
                          select i;
            //jeśli coś przesłano, to wyszukaj po tym
            if (!String.IsNullOrEmpty(ZnajdzZabieg))
            {
                zabieg = from i in db.Operations
                          where i.Nazwisko_wlasciciela.Equals(ZnajdzZabieg)
                          select i;
            }

            return View(zabieg.ToList());
        }
        // GET: Operations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // GET: Operations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imie_wlasciciela,Nazwisko_wlasciciela,Imie_zwierzecia,Gatunek,Rodzaj_operacji,Opis_operacji,Data_operacji")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Operations.Add(operations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operations);
        }

        // GET: Operations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imie_wlasciciela,Nazwisko_wlasciciela,Imie_zwierzecia,Gatunek,Rodzaj_operacji,Opis_operacji,Data_operacji")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operations);
        }

        // GET: Operations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operations operations = db.Operations.Find(id);
            if (operations == null)
            {
                return HttpNotFound();
            }
            return View(operations);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operations operations = db.Operations.Find(id);
            db.Operations.Remove(operations);
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
