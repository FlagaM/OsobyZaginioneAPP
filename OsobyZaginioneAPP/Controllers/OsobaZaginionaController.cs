using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OsobyZaginioneAPP.Models;

namespace OsobyZaginioneAPP.Controllers
{
    public class OsobaZaginionaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OsobaZaginiona
        public ActionResult Index(string searchString)
        {
            //string searchString = id; Search string wyszukiwanie/filtrowanie po płci
            var Szukanaosoba = from m in db.OsobaZaginionas
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Szukanaosoba = Szukanaosoba.Where(s => s.Plec.Contains(searchString));
            }
            //return View(db.OsobaZaginionas.ToList());
            return View(Szukanaosoba);
        }

        // GET: OsobaZaginiona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobaZaginiona osobaZaginiona = db.OsobaZaginionas.Find(id);
            if (osobaZaginiona == null)
            {
                return HttpNotFound();
            }
            return View(osobaZaginiona);
        }

        // GET: OsobaZaginiona/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OsobaZaginiona/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Opis,Data,Plec,Zdjęcie")] OsobaZaginiona osobaZaginiona)
        {
            if (ModelState.IsValid)
            {
                db.OsobaZaginionas.Add(osobaZaginiona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osobaZaginiona);
        }

        [Authorize(Users = "Admin1@osobazaginiona.pl")]
        // GET: OsobaZaginiona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobaZaginiona osobaZaginiona = db.OsobaZaginionas.Find(id);
            if (osobaZaginiona == null)
            {
                return HttpNotFound();
            }
            return View(osobaZaginiona);
        }

        // POST: OsobaZaginiona/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Opis,Data,Plec,Zdjęcie")] OsobaZaginiona osobaZaginiona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osobaZaginiona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osobaZaginiona);
        }

        // GET: OsobaZaginiona/Delete/5
        [Authorize(Users = "Admin1@osobazaginiona.pl")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OsobaZaginiona osobaZaginiona = db.OsobaZaginionas.Find(id);
            if (osobaZaginiona == null)
            {
                return HttpNotFound();
            }
            return View(osobaZaginiona);
        }

        // POST: OsobaZaginiona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OsobaZaginiona osobaZaginiona = db.OsobaZaginionas.Find(id);
            db.OsobaZaginionas.Remove(osobaZaginiona);
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
