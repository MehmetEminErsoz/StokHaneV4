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
    public class TabirsaliyesController : Controller
    {
        private DB0345Entities db = new DB0345Entities();

        // GET: Tabirsaliyes
        public ActionResult Index()
        {
            return View(db.Tabirsaliye.ToList());
        }

        // GET: Tabirsaliyes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabirsaliye tabirsaliye = db.Tabirsaliye.Find(id);
            if (tabirsaliye == null)
            {
                return HttpNotFound();
            }
            return View(tabirsaliye);
        }

        // GET: Tabirsaliyes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabirsaliyes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idirsaliye,irsaliyeKod,girdiTarih,firma,firma2,fiyat")] Tabirsaliye tabirsaliye)
        {
            if (ModelState.IsValid)
            {
                db.Tabirsaliye.Add(tabirsaliye);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabirsaliye);
        }

        // GET: Tabirsaliyes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabirsaliye tabirsaliye = db.Tabirsaliye.Find(id);
            if (tabirsaliye == null)
            {
                return HttpNotFound();
            }
            return View(tabirsaliye);
        }

        // POST: Tabirsaliyes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idirsaliye,irsaliyeKod,girdiTarih,firma,firma2,fiyat")] Tabirsaliye tabirsaliye)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabirsaliye).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabirsaliye);
        }

        // GET: Tabirsaliyes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabirsaliye tabirsaliye = db.Tabirsaliye.Find(id);
            if (tabirsaliye == null)
            {
                return HttpNotFound();
            }
            return View(tabirsaliye);
        }

        // POST: Tabirsaliyes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabirsaliye tabirsaliye = db.Tabirsaliye.Find(id);
            db.Tabirsaliye.Remove(tabirsaliye);
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
