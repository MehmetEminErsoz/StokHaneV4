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

    
    public class TabHanesController : Controller
    {
        private DB0345Entities1 db = new DB0345Entities1();

        // GET: TabHanes
        public ActionResult Index(string id)
        {
            var tabHane = db.TabHane.Include(t => t.Tabisletme);
            if (id!=null)
            {
                return View(tabHane.Where(s => s.Tabisletme.isletmeKod == id).ToList());
            }
            
            return View(tabHane.ToList());
        }

        // GET: TabHanes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabHane tabHane = db.TabHane.Find(id);
            if (tabHane == null)
            {
                return HttpNotFound();
            }
            return View(tabHane);
        }

        // GET: TabHanes/Create
        public ActionResult Create()
        {
            ViewBag.idisletme = new SelectList(db.Tabisletme, "idisletme", "isletmeKod");
            return View();
        }

        // POST: TabHanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTavukhane,idisletme,TavukhaneAdi")] TabHane tabHane)
        {
            if (ModelState.IsValid)
            {
                db.TabHane.Add(tabHane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idisletme = new SelectList(db.Tabisletme, "idisletme", "isletmeKod", tabHane.idisletme);
            return View(tabHane);
        }

        // GET: TabHanes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabHane tabHane = db.TabHane.Find(id);
            if (tabHane == null)
            {
                return HttpNotFound();
            }
            ViewBag.idisletme = new SelectList(db.Tabisletme, "idisletme", "isletmeKod", tabHane.idisletme);
            return View(tabHane);
        }

        // POST: TabHanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTavukhane,idisletme,TavukhaneAdi")] TabHane tabHane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabHane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idisletme = new SelectList(db.Tabisletme, "idisletme", "isletmeKod", tabHane.idisletme);
            return View(tabHane);
        }

        // GET: TabHanes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabHane tabHane = db.TabHane.Find(id);
            if (tabHane == null)
            {
                return HttpNotFound();
            }
            return View(tabHane);
        }

        // POST: TabHanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabHane tabHane = db.TabHane.Find(id);
            db.TabHane.Remove(tabHane);
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
