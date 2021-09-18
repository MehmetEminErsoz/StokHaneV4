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
        private DB0345WBEntt db = new DB0345WBEntt();
        
        // GET: TabUrunGenels
        public ActionResult Index(string kod,int? id)
        {
            var tabUrunGenel = db.TabUrunGenel.Include(t => t.TabAlsatkul).Include(t => t.Tabirsaliye).Include(t => t.TabmiktarCins).Include(t => t.Taburun).Include(t=>t.TabKullanici1);

            

            if (id!=null)
            {
               

                tabUrunGenel.Where(s => s.idirsaliye == id).ToList();
                return View(tabUrunGenel.Where(s => s.idirsaliye == id).ToList());
            }
            if (kod != null)
            {
                tabUrunGenel.Where(s => s.idirsaliye == id).ToList();
                return View(tabUrunGenel.Where(s=> s.Taburun.stokKod == kod).ToList());
            }


            return View(tabUrunGenel.Where(s=>s.Aktiflik==true || s.Aktiflik==null).ToList());
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
        public ActionResult Create([Bind(Include = "idurungenel,idUrun,idirsaliye,miktarKalan,miktar,idmiktarcins,idalsatkul,fiyat,eposta,idKullanici,Aktiflik")] TabUrunGenel tabUrunGenel)
        {
            
            int kulid = Convert.ToInt32(Session["id"]);
            if (ModelState.IsValid)
            {
                
                tabUrunGenel.miktarKalan = tabUrunGenel.miktar;
                tabUrunGenel.idkullanici = kulid;
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
            TabUrunGenel tabUrunGenel = db.TabUrunGenel.Find(id);


            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (tabUrunGenel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur", tabUrunGenel.idalsatkul);
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod", tabUrunGenel.idirsaliye);
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu", tabUrunGenel.idmiktarcins);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabUrunGenel.idUrun);
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idkullanici", "eposta", tabUrunGenel.idkullanici);
            
            return View(tabUrunGenel);
        }

        // POST: TabUrunGenels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "idurungenel,idUrun,idirsaliye,miktarKalan,miktar,idmiktarcins,idalsatkul,fiyat,eposta,idKullanici,kulisim,kulsoyisim,Aktiflik")] TabUrunGenel tabUrunGenel,bool CB1)
        {




            if (ModelState.IsValid)
            {


                if (CB1 == true)
                {

                    tabUrunGenel.Aktiflik = true;
                }
                else if (CB1 == false)
                {
                    tabUrunGenel.Aktiflik = false;
                }

                db.Entry(tabUrunGenel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idalsatkul = new SelectList(db.TabAlsatkul, "idalsatkul", "alsatkultur", tabUrunGenel.idalsatkul);
            ViewBag.idirsaliye = new SelectList(db.Tabirsaliye, "idirsaliye", "irsaliyeKod", tabUrunGenel.idirsaliye);
            ViewBag.idmiktarcins = new SelectList(db.TabmiktarCins, "idmiktarcins", "miktarturu", tabUrunGenel.idmiktarcins);
            ViewBag.idUrun = new SelectList(db.Taburun, "idurun", "UrunAdi", tabUrunGenel.idUrun);
            ViewBag.idKullanici = new SelectList(db.TabKullanici, "idKullanici", "eposta", tabUrunGenel.idkullanici);
            
           
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
           
            tabUrunGenel.Aktiflik = false;
            //db.TabUrunGenel.Remove(tabUrunGenel);
            db.Entry(tabUrunGenel).State = EntityState.Modified;
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
