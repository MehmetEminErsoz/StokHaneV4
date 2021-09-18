using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StokHaneV4.Models;
using System.Web.Security;


namespace StokHaneV4.Controllers
{

    
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Index()
        {

           
            return View();
        }
        private DB0345WBEntt db = new DB0345WBEntt();
       


        public ActionResult istek(int? id)
        {
            List<TabRasyon> liste1 = db.TabRasyon.ToList();
            List<Tabrasyontarifi> liste2 = db.Tabrasyontarifi.ToList();
            ViewData["jointables"] = from rasyon in liste1
                                     where rasyon.idRasyon ==id
                                     join st in liste2 on rasyon.idRasyon equals st.idRasyon  into table1
                                     from st in table1.DefaultIfEmpty()
                                     select  new Class1 { list1 = rasyon, list2 = st };
            ViewBag.veri = id;
            return View(ViewData["jointables"]);
        }

        public ActionResult istekview()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult login()
        {

            





            return View();
        }

        public StokHaneV4.Models.TabKullanici bilgiler;
        [HttpPost]
        [AllowAnonymous]
        
        public ActionResult login(TabKullanici t)
        {
            bilgiler = db.TabKullanici.FirstOrDefault(x => x.eposta == t.eposta && x.kulsif == t.kulsif);

            if (bilgiler != null)
            {
                Session["id"] = bilgiler.idKullanici;
                Session.Add("asdf", bilgiler.eposta);
                FormsAuthentication.SetAuthCookie(bilgiler.kulisim +" "+bilgiler.kulsoyisim, false);

                return RedirectToAction("Index","Home");
                }
            else
            {
                ViewBag.hatalı = "Eposta veya şifre geçersiz/hatalı";
                return View();
            }
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();






            return RedirectToAction("login");
        }

        
       
    }
}