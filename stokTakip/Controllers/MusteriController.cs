using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class MusteriController : Controller
    {
        stokTakipEntities db = new stokTakipEntities();

        // GET: Musteri
        public ActionResult Index()
        {
            var degerler = db.musteriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MusteriEkle(musteriler ekle)
        {
            db.musteriler.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var musteri = db.musteriler.Find(id);
            db.musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var degerler = db.musteriler.Find(id);
            return View("MusteriGetir",degerler);
        }

        public ActionResult Guncelle(musteriler p1)
        {
            var degerler = db.musteriler.Find(p1.musteriId);
            degerler.musteriAd = p1.musteriAd;

            degerler.musteriSoyad = p1.musteriSoyad;
           
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}