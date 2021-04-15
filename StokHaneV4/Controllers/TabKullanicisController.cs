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
    public class TabKullanicisController : Controller
    {
        private DB0345Entities db = new DB0345Entities();

        // GET: TabKullanicis
        public ActionResult Index()
        {
            var tabKullanici = db.TabKullanici.Include(t => t.TabYetki);
            return View(tabKullanici.ToList());
        }

        // GET: TabKullanicis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabKullanici tabKullanici = db.TabKullanici.Find(id);
            if (tabKullanici == null)
            {
                return HttpNotFound();
            }
            return View(tabKullanici);
        }

        // GET: TabKullanicis/Create
        public ActionResult Create()
        {
            ViewBag.idyetki = new SelectList(db.TabYetki, "idYetki", "Yetkiadi");
            return View();
        }

        // POST: TabKullanicis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idKullanici,KulAdi,kulisim,kulsoyisim,eposta,tel,idyetki,sonerisim,kulsif")] TabKullanici tabKullanici)
        {
            if (ModelState.IsValid)
            {
                db.TabKullanici.Add(tabKullanici);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idyetki = new SelectList(db.TabYetki, "idYetki", "Yetkiadi", tabKullanici.idyetki);
            return View(tabKullanici);
        }

        // GET: TabKullanicis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabKullanici tabKullanici = db.TabKullanici.Find(id);
            if (tabKullanici == null)
            {
                return HttpNotFound();
            }
            ViewBag.idyetki = new SelectList(db.TabYetki, "idYetki", "Yetkiadi", tabKullanici.idyetki);
            return View(tabKullanici);
        }

        // POST: TabKullanicis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idKullanici,KulAdi,kulisim,kulsoyisim,eposta,tel,idyetki,sonerisim,kulsif")] TabKullanici tabKullanici)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabKullanici).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idyetki = new SelectList(db.TabYetki, "idYetki", "Yetkiadi", tabKullanici.idyetki);
            return View(tabKullanici);
        }

        // GET: TabKullanicis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabKullanici tabKullanici = db.TabKullanici.Find(id);
            if (tabKullanici == null)
            {
                return HttpNotFound();
            }
            return View(tabKullanici);
        }

        // POST: TabKullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabKullanici tabKullanici = db.TabKullanici.Find(id);
            db.TabKullanici.Remove(tabKullanici);
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
