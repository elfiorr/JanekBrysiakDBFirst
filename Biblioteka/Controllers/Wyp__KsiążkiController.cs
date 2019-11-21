using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteka.Models;

namespace Biblioteka.Controllers
{
    public class Wyp__KsiążkiController : Controller
    {
        private UczniowieSzkolyEntities db = new UczniowieSzkolyEntities();

        // GET: Wyp__Książki
        public ActionResult Index()
        {
            return View(db.Wyp__Książki.ToList());
        }

        // GET: Wyp__Książki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyp__Książki wyp__Książki = db.Wyp__Książki.Find(id);
            if (wyp__Książki == null)
            {
                return HttpNotFound();
            }
            return View(wyp__Książki);
        }

        // GET: Wyp__Książki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wyp__Książki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tytuł")] Wyp__Książki wyp__Książki)
        {
            if (ModelState.IsValid)
            {
                db.Wyp__Książki.Add(wyp__Książki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wyp__Książki);
        }

        // GET: Wyp__Książki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyp__Książki wyp__Książki = db.Wyp__Książki.Find(id);
            if (wyp__Książki == null)
            {
                return HttpNotFound();
            }
            return View(wyp__Książki);
        }

        // POST: Wyp__Książki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tytuł")] Wyp__Książki wyp__Książki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wyp__Książki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wyp__Książki);
        }

        // GET: Wyp__Książki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wyp__Książki wyp__Książki = db.Wyp__Książki.Find(id);
            if (wyp__Książki == null)
            {
                return HttpNotFound();
            }
            return View(wyp__Książki);
        }

        // POST: Wyp__Książki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wyp__Książki wyp__Książki = db.Wyp__Książki.Find(id);
            db.Wyp__Książki.Remove(wyp__Książki);
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
