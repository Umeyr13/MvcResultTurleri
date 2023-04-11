using MvcResultTurleri.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcResultTurleri.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
             
            //return RedirectToAction("Index"); başka sayfaya yönlendirme
        }

        public RedirectResult Index2()
        {
           // return Redirect("/Home/Index"); //başka sayfaya yönlendirme
           return Redirect("https://www.google.com.tr");
        }

        public JsonResult Index3()
        {
            Urun urun = new Urun();
            urun.Id = 1;
            urun.Adi = "Çikolata";
            urun.Fiyati = 20;
            urun.Aciklama = "Yeni ürün";
            return Json(urun,JsonRequestBehavior.AllowGet);

            /*
                {Id:1,Adi:Çikolata ...}
             
            */
        }

        static List <string> veriler = new List<string>();
        public ActionResult Index4()
        {
            ViewBag.liste = veriler;
            return View();
        }

        [HttpPost]
        public ActionResult Index4(string ad, string soyad)
        {
            veriler.Add(ad + " " + soyad);
            return new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary (new {action="Index4", controller ="Home", kod = Guid.NewGuid().ToString()
            }) );
        }


        public ActionResult Dosyalar()
        {

            return View();
        }
        
        public FileResult PdfDosyaGoster()
        {
            string dosya = Server.MapPath("~/Dosyalar/Yeni Microsoft Word Belgesi.pdf");
            return new FilePathResult(dosya, "application/ pdf");
        }

        public FileStreamResult MetinDosyasıIndir()
        {
            MemoryStream memo = new MemoryStream();
            string metin = "Deneme Yazısı";
             byte[] bytes = Encoding.UTF8.GetBytes(metin);
            memo.Write(bytes, 0, bytes.Length);//ofset adresini belirttik
            memo.Position = 0;//dosyayı kapatmak gibi birşey
            
            FileStreamResult sonuc = new FileStreamResult(memo,"text/plain");
            sonuc.FileDownloadName = "Deneme.txt";
            return sonuc;
        }

        public PartialViewResult KategoriGetir()
        {
            return PartialView("_KategorilerPartialPage");
        }

        public PartialViewResult KategoriGetir2()
        {
            List<string> kategoriler = new List<string>()
                {
                    "Teknoloji","Giyim","Gıda","Temizlik"
                };
            return PartialView("_PartialPageKategoriler2",kategoriler);
        }

        public JavaScriptResult Mesaj()
        {
            string mesaj = "alert('Merhaba Dünya')";
            return JavaScript(mesaj);
        }

        public JavaScriptResult ButtonMesaj()
        {
            string buttonMesaj = "function button_click(){alert('Merhaba Dünya ')}";
            return JavaScript(buttonMesaj);
        }
    }
}