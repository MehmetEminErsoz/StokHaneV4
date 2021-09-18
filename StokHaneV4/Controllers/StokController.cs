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

        private DB0345WBEntt db = new DB0345WBEntt();
        public ActionResult Index(string kod,int? id)
        {
            var stoktablo = db.TabUrunGenel.Include(s => s.TabAlsatkul).Include(s => s.Tabirsaliye).Include(s => s.TabmiktarCins).Include(s => s.Taburun).Include(s => s.TabKullanici);

            if (kod != null)
            {

                //Önce gelen ürünü filtreledik sonra alım olanları aldık 
                var sorguparam = stoktablo.Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList().Min(s => s.Tabirsaliye.girdiTarih);

                var last = stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguparam).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList();

                var denm = stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguparam).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 1).OrderBy(s => s.Tabirsaliye.girdiTarih).Take(2).SingleOrDefault();


                //satım veya kullanım kodu

                //var sorguprm = stoktablo.Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 2 || s.TabAlsatkul.idalsatkul == 3).OrderBy(s => s.Tabirsaliye.girdiTarih).ToList().Min(s => s.Tabirsaliye.girdiTarih);
                //var lastt = stoktablo.Where(s => s.Tabirsaliye.girdiTarih == sorguprm).Where(s => s.Taburun.stokKod == kod).Where(s => s.TabAlsatkul.idalsatkul == 2 || s.TabAlsatkul.idalsatkul == 3).OrderBy(s => s.Tabirsaliye.girdiTarih).Take(1).SingleOrDefault();

                //var snv = denm.miktar - lastt.miktar;

                //denm.miktar = snv;
                db.SaveChanges();


                return View(last);
            }


            return View(stoktablo);


        }


        private void StokDus(int? Rasyonid)
        {var urunList = db.Tabrasyontarifi.Where(s => s.idRasyon == Rasyonid).Select(x => x.idUrun).ToList();
            foreach (var urunId in urunList)
            {
                var rasyontarif = db.Tabrasyontarifi.FirstOrDefault(y => y.idUrun == urunId);
                if (rasyontarif == null)
                    return;
                var stoktablo = db.TabUrunGenel.Where(y => y.idUrun == urunId).Include(s => s.TabAlsatkul).Include(s => s.Tabirsaliye).Include(s => s.TabmiktarCins).Include(s => s.Taburun).Include(s => s.TabKullanici).OrderBy(y => y.Tabirsaliye.girdiTarih).ToList();

                var toplamMiktar = stoktablo.Sum(x => x.miktarKalan);
                if (rasyontarif.TarifMiktar > toplamMiktar)
                    throw new Exception("Stokta yeterli ürün yok");

                double? kullanilanMiktar = 0;
                double? genelkullanılanmiktar = 0;
                var i = 0;
                double? eksikkalan = 0;
                var stoktanDusecekler = new List<TabUrunGenel>();
                while (kullanilanMiktar< rasyontarif.TarifMiktar)
                {
                    if ((rasyontarif.TarifMiktar - kullanilanMiktar) > stoktablo[i].miktarKalan)
                    {
                        kullanilanMiktar = stoktablo[i].miktarKalan;
                        
                        stoktablo[i].miktarKalan = stoktablo[i].miktarKalan -kullanilanMiktar;
                    }
                    else 
                    {

                        if (kullanilanMiktar>0)
                        {
                            stoktablo[i].miktarKalan = stoktablo[i].miktarKalan - eksikkalan;


                            kullanilanMiktar += eksikkalan;
                            
                        }
                        else
                        {
                            kullanilanMiktar = rasyontarif.TarifMiktar;
                            stoktablo[i].miktarKalan = stoktablo[i].miktarKalan - kullanilanMiktar;
                            
                        }
                        

                    }
                    //kullanilanMiktar = kullanilanMiktar + eksikkalan;
                    eksikkalan = rasyontarif.TarifMiktar - kullanilanMiktar;
                   
                    stoktanDusecekler.Add(stoktablo[i]);
                    db.SaveChanges();
                    //kullanilanMiktar += stoktablo[i].miktarKalan;
                    i++;
                }
            }
        }

        public ActionResult StokView()
        {
            StokDus(1);
            return View();
        }
    }
}