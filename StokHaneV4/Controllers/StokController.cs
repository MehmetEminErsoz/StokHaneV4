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
    public class StokController : Controller
    {
        // GET: Stok

        private DB0345ENTWB db = new DB0345ENTWB();
        public ActionResult Index(string kod,int? id)
        {
            var stoktablo = db.TabUrunGenel.Include(s => s.TabAlsatkul).Include(s => s.Tabirsaliye).Include(s => s.TabmiktarCins).Include(s => s.Taburun).Include(s => s.TabKullanici);

            if (kod != null)
            {

                //Önce gelen ürünü filtreledik sonra alım olanları aldık 
                var sorguparam = stoktablo.Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList().Min(s=>s.Tabirsaliye.girdiTarih);
                
                var last= stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguparam).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList();

                var denm= stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguparam).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).Take(2).SingleOrDefault();


                //satım veya kullanım kodu

                var sorguprm = stoktablo.Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 2 || s.TabAlsatkul.idalsatkul == 3).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList().Min(s => s.Tabirsaliye.girdiTarih);
                var lastt = stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguprm).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 2 || s.TabAlsatkul.idalsatkul == 3).OrderBy(s => s.Tabirsaliye.girdiTarih).Take(1).SingleOrDefault();

                var snv = denm.miktar - lastt.miktar;

              denm.miktar = snv;
                db.SaveChanges();


                return View(last);
            }
            

            return View(stoktablo);


        }
    }
}