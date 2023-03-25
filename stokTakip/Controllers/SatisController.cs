using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakip.Models.Entity;

namespace stokTakip.Controllers
{
    public class SatisController : Controller
    {
        stokTakipEntities db = new stokTakipEntities();
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(satislar p1)
        {
            db.satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
        }


    }
}