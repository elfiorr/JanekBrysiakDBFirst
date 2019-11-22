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
    public class WypożyczającyController : Controller
    {
        private BibliotekaEntities db = new BibliotekaEntities();

        // GET: Wypożyczający
        public ActionResult Index()
        {
            var wypożyczający = db.Wypożyczający.Include(w => w.Książki);
            return View(wypożyczający.ToList());
        }

        // GET: Wypożyczający/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypożyczający wypożyczający = db.Wypożyczający.Find(id);
            if (wypożyczający == null)
            {
                return HttpNotFound();
            }
            return View(wypożyczający);
        }

        // GET: Wypożyczający/Create
        public ActionResult Create()
        {
            ViewBag.TytułKsiążkiId = new SelectList(db.Książki, "Id", "TytułKsiążki");
            return View();
        }

        // POST: Wypożyczający/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imię,Nazwisko,TytułKsiążkiId,NumerTelefonu,AdresMailowy")] Wypożyczający wypożyczający)
        {
            if (ModelState.IsValid)
            {
                db.Wypożyczający.Add(wypożyczający);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TytułKsiążkiId = new SelectList(db.Książki, "Id", "TytułKsiążki", wypożyczający.TytułKsiążkiId);
            return View(wypożyczający);
        }

        // GET: Wypożyczający/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypożyczający wypożyczający = db.Wypożyczający.Find(id);
            if (wypożyczający == null)
            {
                return HttpNotFound();
            }
            ViewBag.TytułKsiążkiId = new SelectList(db.Książki, "Id", "TytułKsiążki", wypożyczający.TytułKsiążkiId);
            return View(wypożyczający);
        }

        // POST: Wypożyczający/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imię,Nazwisko,TytułKsiążkiId,NumerTelefonu,AdresMailowy")] Wypożyczający wypożyczający)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wypożyczający).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TytułKsiążkiId = new SelectList(db.Książki, "Id", "TytułKsiążki", wypożyczający.TytułKsiążkiId);
            return View(wypożyczający);
        }

        // GET: Wypożyczający/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wypożyczający wypożyczający = db.Wypożyczający.Find(id);
            if (wypożyczający == null)
            {
                return HttpNotFound();
            }
            return View(wypożyczający);
        }

        // POST: Wypożyczający/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wypożyczający wypożyczający = db.Wypożyczający.Find(id);
            db.Wypożyczający.Remove(wypożyczający);
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
