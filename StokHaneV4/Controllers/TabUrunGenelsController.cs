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
    public class TabUrunGenelsController : Controller
    {
        private DB0345Entities1 db = new DB0345Entities1();

        // GET: TabUrunGenels
        public ActionResult Index(int? id)
        {
            var tabUrunGenel = db.TabUrunGenel.Include(t => t.TabAlsatkul).Include(t => t.Tabirsaliye).Include(t => t.TabmiktarCins).Include(t => t.Taburun);
            if (id!=null)
            {
                tabUrunGenel.Where(s => s.idirsaliye == id).ToList();
                return View(tabUrunGenel.Where(s => s.idirsaliye == id).ToList());
            }
            


            return View(tabUrunGenel.ToList());
        }

        // GET: TabUrunGenels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUrunGenel tabUrunGenel = db.TabUrunGenel.Find(id);
            if (tabUrunGenel == null)
            {
                return HttpNotFound();
            }
            return View(tabUrunGenel);
        }

        // GET: TabUrunGenels/Create
        public ActionResult Create()
        {
            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur");
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod");
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu");
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi");
            return View();
        }

        // POST: TabUrunGenels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idurungenel,idUrun,idirsaliye,miktar,idmiktarcins,idalsatkul,fiyat")] TabUrunGenel tabUrunGenel)
        {
            if (ModelState.IsValid)
            {
                db.TabUrunGenel.Add(tabUrunGenel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur", tabUrunGenel.idalsatkul);
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod", tabUrunGenel.idirsaliye);
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu", tabUrunGenel.idmiktarcins);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabUrunGenel.idUrun);
            return View(tabUrunGenel);
        }

        // GET: TabUrunGenels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUrunGenel tabUrunGenel = db.TabUrunGenel.Find(id);
            if (tabUrunGenel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur", tabUrunGenel.idalsatkul);
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod", tabUrunGenel.idirsaliye);
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu", tabUrunGenel.idmiktarcins);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabUrunGenel.idUrun);
            return View(tabUrunGenel);
        }

        // POST: TabUrunGenels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idurungenel,idUrun,idirsaliye,miktar,idmiktarcins,idalsatkul,fiyat")] TabUrunGenel tabUrunGenel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabUrunGenel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur", tabUrunGenel.idalsatkul);
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod", tabUrunGenel.idirsaliye);
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu", tabUrunGenel.idmiktarcins);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabUrunGenel.idUrun);
            return View(tabUrunGenel);
        }

        // GET: TabUrunGenels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabUrunGenel tabUrunGenel = db.TabUrunGenel.Find(id);
            if (tabUrunGenel == null)
            {
                return HttpNotFound();
            }
            return View(tabUrunGenel);
        }

        // POST: TabUrunGenels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabUrunGenel tabUrunGenel = db.TabUrunGenel.Find(id);
            
            db.TabUrunGenel.Remove(tabUrunGenel);
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
