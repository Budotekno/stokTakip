using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        stokTakipEntities db = new stokTakipEntities();
        public ActionResult Index()
        {
            var degerler = db.kategoriler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(kategoriler ekle)
        {

            if(!ModelState.IsValid)
            {
                return View();
            }
            db.kategoriler.Add(ekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var kategori = db.kategoriler.Find(id);
            db.kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


       
        public ActionResult KategoriGetir(int id)
        {
            var gelenDeger = db.kategoriler.Find(id);
            return View("KategoriGetir", gelenDeger);
        }

        public ActionResult Guncelle(kategoriler p1)
        {
            var degerler = db.kategoriler.Find(p1.kategoriId);
            degerler.kategoriAd = p1.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


       


    }
}
