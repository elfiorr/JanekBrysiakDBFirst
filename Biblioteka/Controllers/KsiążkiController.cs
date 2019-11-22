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
    public class KsiążkiController : Controller
    {
        private BibliotekaEntities db = new BibliotekaEntities();

        // GET: Książki
        public ActionResult Index()
        {
            return View(db.Książki.ToList());
        }

        // GET: Książki/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Książki książki = db.Książki.Find(id);
            if (książki == null)
            {
                return HttpNotFound();
            }
            return View(książki);
        }

        // GET: Książki/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Książki/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TytułKsiążki")] Książki książki)
        {
            if (ModelState.IsValid)
            {
                db.Książki.Add(książki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(książki);
        }

        // GET: Książki/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Książki książki = db.Książki.Find(id);
            if (książki == null)
            {
                return HttpNotFound();
            }
            return View(książki);
        }

        // POST: Książki/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TytułKsiążki")] Książki książki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(książki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(książki);
        }

        // GET: Książki/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Książki książki = db.Książki.Find(id);
            if (książki == null)
            {
                return HttpNotFound();
            }
            return View(książki);
        }

        // POST: Książki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Książki książki = db.Książki.Find(id);
            db.Książki.Remove(książki);
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
