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




    public class TabrasyontarifisController : Controller
    {
        private DB0345Entities db = new DB0345Entities();

        // GET: Tabrasyontarifis
        
        public ActionResult Index()
        {
            var tabrasyontarifi = db.Tabrasyontarifi.Include(t => t.TabRasyon).Include(t => t.Taburun);
            return View(tabrasyontarifi.ToList());
        }
       
        // GET: Tabrasyontarifis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabrasyontarifi tabrasyontarifi = db.Tabrasyontarifi.Find(id);
            if (tabrasyontarifi == null)
            {
                return HttpNotFound();
            }
            return View(tabrasyontarifi);
        }

        // GET: Tabrasyontarifis/Create
        public ActionResult Create()
        {
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi");
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi");
            return View();
        }

        // POST: Tabrasyontarifis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRasyonTarif,idRasyon,TarifMiktar,idUrun")] Tabrasyontarifi tabrasyontarifi)
        {
            if (ModelState.IsValid)
            {
                db.Tabrasyontarifi.Add(tabrasyontarifi);
                db.SaveChanges();
                return RedirectToAction("Index","TabRasyons");
                
            }
            
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabrasyontarifi.idRasyon);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabrasyontarifi.idUrun);
            return View(tabrasyontarifi);
        }

        // GET: Tabrasyontarifis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabrasyontarifi tabrasyontarifi = db.Tabrasyontarifi.Find(id);
            if (tabrasyontarifi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabrasyontarifi.idRasyon);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabrasyontarifi.idUrun);
            return View(tabrasyontarifi);
        }

        // POST: Tabrasyontarifis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRasyonTarif,idRasyon,TarifMiktar,idUrun")] Tabrasyontarifi tabrasyontarifi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabrasyontarifi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRasyon = new SelectList(db.TabRasyon, "idRasyon", "RasyonAdi", tabrasyontarifi.idRasyon);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabrasyontarifi.idUrun);
            return View(tabrasyontarifi);
        }

        // GET: Tabrasyontarifis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabrasyontarifi tabrasyontarifi = db.Tabrasyontarifi.Find(id);
            if (tabrasyontarifi == null)
            {
                return HttpNotFound();
            }
            return View(tabrasyontarifi);
        }

        // POST: Tabrasyontarifis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabrasyontarifi tabrasyontarifi = db.Tabrasyontarifi.Find(id);
            db.Tabrasyontarifi.Remove(tabrasyontarifi);
            db.SaveChanges();
            return RedirectToAction("Index","TabRasyons");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



       
        
        public ActionResult istenenindex(int? id)
        {
            
            var tabrasyontarifi = db.Tabrasyontarifi.Include(t => t.TabRasyon).Include(t => t.Taburun);
            var secilitarif = tabrasyontarifi.Where(s => s.idRasyon == id);

            return View(secilitarif.ToList());
        }
    }
}
