using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StokHaneV4.Models;

namespace StokHaneV4.Controllers
{
    public class TabLogRasyonsController : Controller
    {
        private DB0345WBEnt db = new DB0345WBEnt();

        // GET: TabLogRasyons
        public ActionResult Index()
        {
            var tabLogRasyon = db.TabLogRasyon.Include(t => t.TabHane).Include(t => t.TabKullanici).Include(t => t.TabRasyon);
            return View(tabLogRasyon.ToList());
        }

        // GET: TabLogRasyons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabLogRasyon tabLogRasyon = db.TabLogRasyon.Find(id);
            if (tabLogRasyon == null)
            {
                return HttpNotFound();
            }
            return View(tabLogRasyon);
        }

        // GET: TabLogRasyons/Create
        public ActionResult Create()
        {
            ViewBag.İdHane = new SelectList(db.TabHane, "idTavukhane", "TavukhaneAdi");
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idKullanici", "KulAdi");
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi");
            ViewBag.idRasyonTarif = new SelectList(db.Tabrasyontarifi, "idRasyonTarif", "idRasyonTarif");
            return View();
        }

        // POST: TabLogRasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idislem,idRasyon,idRasyonTarif,İdHane,idKullanici,islemTarihi")] TabLogRasyon tabLogRasyon)
        {
            if (ModelState.IsValid)
            {
                db.TabLogRasyon.Add(tabLogRasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.İdHane = new SelectList(db.TabHane, "idTavukhane", "TavukhaneAdi", tabLogRasyon.İdHane);
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idKullanici", "KulAdi", tabLogRasyon.idKullanici);
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabLogRasyon.idRasyon);
            
            return View(tabLogRasyon);
        }

        // GET: TabLogRasyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabLogRasyon tabLogRasyon = db.TabLogRasyon.Find(id);
            if (tabLogRasyon == null)
            {
                return HttpNotFound();
            }
            ViewBag.İdHane = new SelectList(db.TabHane, "idTavukhane", "TavukhaneAdi", tabLogRasyon.İdHane);
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idKullanici", "KulAdi", tabLogRasyon.idKullanici);
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabLogRasyon.idRasyon);
            
            return View(tabLogRasyon);
        }

        // POST: TabLogRasyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idislem,idRasyon,idRasyonTarif,İdHane,idKullanici,islemTarihi")] TabLogRasyon tabLogRasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabLogRasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.İdHane = new SelectList(db.TabHane, "idTavukhane", "TavukhaneAdi", tabLogRasyon.İdHane);
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idKullanici", "KulAdi", tabLogRasyon.idKullanici);
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabLogRasyon.idRasyon);
            
            return View(tabLogRasyon);
        }

        // GET: TabLogRasyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabLogRasyon tabLogRasyon = db.TabLogRasyon.Find(id);
            if (tabLogRasyon == null)
            {
                return HttpNotFound();
            }
            return View(tabLogRasyon);
        }

        // POST: TabLogRasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabLogRasyon tabLogRasyon = db.TabLogRasyon.Find(id);
            db.TabLogRasyon.Remove(tabLogRasyon);
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
