using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class UrunController : Controller
    {
        stokTakipEntities db = new stokTakipEntities();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = db.urunler.ToList();
            return View(urunler);
        }


        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();
        }


        [HttpPost]
        public ActionResult YeniUrun(urunler ekle)
        {
            var ktg = db.kategoriler.Where(m => m.kategoriId == ekle.kategoriler.kategoriId).FirstOrDefault();
            ekle.kategoriler = ktg;
            db.urunler.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Sil(int id)
        {
            var urn = db.urunler.Find(id);
            db.urunler.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunGetir(int id)
        {
            var gelenUrun = db.urunler.Find(id);


            List<SelectListItem> degerler = (from i in db.kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.kategoriAd,
                                                 Value = i.kategoriId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;

            return View("UrunGetir",gelenUrun);
        }

        public ActionResult Guncelle(urunler p1)
        {
            var degerler = db.urunler.Find(p1.urunId);
            degerler.urunAd = p1.urunAd;
            degerler.urunMarkaAd = p1.urunMarkaAd;
            degerler.urunKategori = p1.urunKategori;
            //degerler.kategoriler.kategoriAd = p1.kategoriler.kategoriAd;
            var ktg = db.kategoriler.Where(m => m.kategoriId == p1.kategoriler.kategoriId).FirstOrDefault();
            degerler.urunKategori = ktg.kategoriId;
            degerler.urunStok = p1.urunStok;
            degerler.urunFiyat = p1.urunFiyat;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
       
}