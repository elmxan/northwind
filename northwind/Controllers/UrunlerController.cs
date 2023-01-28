using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace northwind.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        NorthwindEntities nw = new NorthwindEntities();
        public ActionResult Index()
        {
            List<Urunler> urunler = nw.Urunlers.ToList();




            List<Kategoriler> kategorilers = new List<Kategoriler>();
            nw.Kategorilers.ToList();
            ViewBag.llll = kategorilers;

            return View(urunler);
        }
        public ActionResult Add() 
        {
            List<Kategoriler> ktg =nw.Kategorilers.ToList();
            List<Tedarikciler> td=nw.Tedarikcilers.ToList();
            ViewBag.Kategoriler=ktg;
            ViewBag.Tedarikciler = td; 
                return View();

        }
        [HttpPost]
        public  ActionResult Add(string urunadi, decimal fiyat, short stok,int Kid, int tid)
        {
            Urunler u = new Urunler();
            u.UrunAdi = urunadi;
            u.BirimFiyati= fiyat;
            u.HedefStokDuzeyi= stok;
            u.KategoriID = Kid;
            //u.TedarikciID = tid;
            nw.SaveChanges();   


            return RedirectToAction("Index");   

        }
    }
}