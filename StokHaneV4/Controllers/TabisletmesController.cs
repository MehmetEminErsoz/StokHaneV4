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
    public class TabisletmesController : Controller
    {
        private DB0345Entities1 db = new DB0345Entities1();

        // GET: Tabisletmes
        public ActionResult Index()
        {
           
            return View(db.Tabisletme.ToList());
        }

        // GET: Tabisletmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabisletme tabisletme = db.Tabisletme.Find(id);
            if (tabisletme == null)
            {
                return HttpNotFound();
            }
            return View(tabisletme);
        }

        // GET: Tabisletmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabisletmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idisletme,isletmeKod,isletmeAdi")] Tabisletme tabisletme)
        {
            if (ModelState.IsValid)
            {
                db.Tabisletme.Add(tabisletme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabisletme);
        }

        // GET: Tabisletmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabisletme tabisletme = db.Tabisletme.Find(id);
            if (tabisletme == null)
            {
                return HttpNotFound();
            }
            return View(tabisletme);
        }

        // POST: Tabisletmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idisletme,isletmeKod,isletmeAdi")] Tabisletme tabisletme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabisletme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabisletme);
        }

        // GET: Tabisletmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabisletme tabisletme = db.Tabisletme.Find(id);
            if (tabisletme == null)
            {
                return HttpNotFound();
            }
            return View(tabisletme);
        }

        // POST: Tabisletmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabisletme tabisletme = db.Tabisletme.Find(id);
            db.Tabisletme.Remove(tabisletme);
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
