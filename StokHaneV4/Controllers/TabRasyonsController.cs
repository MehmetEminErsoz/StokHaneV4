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
    public class TabRasyonsController : Controller
    {
        private DB0345WBEntt db = new DB0345WBEntt();

        // GET: TabRasyons
        public ActionResult Index()
        {
           
            return View(db.TabRasyon.ToList());
        }

        // GET: TabRasyons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabRasyon tabRasyon = db.TabRasyon.Find(id);
            if (tabRasyon == null)
            {
                return HttpNotFound();
            }
            TempData["veri"] = tabRasyon.RasyonAdi;
            ViewBag.cekar = tabRasyon.RasyonAdi;

            List<TabRasyon> liste1 = db.TabRasyon.ToList();
            List<Tabrasyontarifi> liste2 = db.Tabrasyontarifi.ToList();
            ViewData["jointables"] = from rasyon in liste1
                                     where rasyon.idRasyon == id
                                     join st in liste2 on rasyon.idRasyon equals st.idRasyon into table1
                                     from st in table1.DefaultIfEmpty()
                                     select new Class1 { list1 = rasyon, list2 = st };
            TabRasyon tbrasyon = db.TabRasyon.Find(id);

            

            ViewBag.rasyonno = id;
            
            return View(tabRasyon);
        }

        
        public ActionResult istek(int? id)
        {
            List<TabRasyon> liste1 = db.TabRasyon.ToList();
            List<Tabrasyontarifi> liste2 = db.Tabrasyontarifi.ToList();
            ViewData["jointables"] = from rasyon in liste1
                                     where rasyon.idRasyon == id
                                     join st in liste2 on rasyon.idRasyon equals st.idRasyon into table1
                                     from st in table1.DefaultIfEmpty()
                                     select new Class1 { list1 = rasyon, list2 = st };
            TabRasyon tbrasyon = db.TabRasyon.Find(id);
            
            //ViewBag.tbrasyonadi= tbrasyon.RasyonAdi;
            return View(ViewData["jointables"]);
        }

        // GET: TabRasyons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabRasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idRasyon,RasyonAdi")] TabRasyon tabRasyon)
        {
            if (ModelState.IsValid)
            {
                db.TabRasyon.Add(tabRasyon);
                db.SaveChanges();
                return RedirectToAction("Create","Tabrasyontarifis");
            }
            ViewBag.rasad = tabRasyon.RasyonAdi;
            return View(tabRasyon);
        }

        // GET: TabRasyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabRasyon tabRasyon = db.TabRasyon.Find(id);
            if (tabRasyon == null)
            {
                return HttpNotFound();
            }
            return View(tabRasyon);
        }

        // POST: TabRasyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idRasyon,RasyonAdi")] TabRasyon tabRasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabRasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabRasyon);
        }

        // GET: TabRasyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabRasyon tabRasyon = db.TabRasyon.Find(id);
            if (tabRasyon == null)
            {
                return HttpNotFound();
            }
            return View(tabRasyon);
        }

        // POST: TabRasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabRasyon tabRasyon = db.TabRasyon.Find(id);
            db.Tabrasyontarifi.RemoveRange(tabRasyon.Tabrasyontarifi);
           

            db.TabRasyon.Remove(tabRasyon);
           
            
                
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
