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
    public class TaburunsController : Controller
    {
        private DB0345WBEnt db = new DB0345WBEnt();

        // GET: Taburuns
        public ActionResult Index()
        {
            return View(db.Taburun.ToList());
        }

        // GET: Taburuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taburun taburun = db.Taburun.Find(id);
            if (taburun == null)
            {
                return HttpNotFound();
            }
            return View(taburun);
        }

        // GET: Taburuns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taburuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idurun,UrunAdi,stokKod")] Taburun taburun)
        {
            if (ModelState.IsValid)
            {
                db.Taburun.Add(taburun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taburun);
        }

        // GET: Taburuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taburun taburun = db.Taburun.Find(id);
            if (taburun == null)
            {
                return HttpNotFound();
            }
            return View(taburun);
        }

        // POST: Taburuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idurun,UrunAdi,stokKod")] Taburun taburun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taburun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taburun);
        }

        // GET: Taburuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Taburun taburun = db.Taburun.Find(id);
            if (taburun == null)
            {
                return HttpNotFound();
            }
            return View(taburun);
        }

        // POST: Taburuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Taburun taburun = db.Taburun.Find(id);
            db.Taburun.Remove(taburun);
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
