using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMvc.Models.EntityFrameWork;

namespace ÖğrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogr = db.tbl_öğrenciler.ToList();
            return View(ogr);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kulüpler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulüpAd,
                                                 Value = i.KulüpID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(tbl_öğrenciler p)
        {
            var klp = db.tbl_kulüpler.Where(m => m.KulüpID == p.tbl_kulüpler.KulüpID).FirstOrDefault();
            p.tbl_kulüpler = klp;
            db.tbl_öğrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogr = db.tbl_öğrenciler.Find(id);
            db.tbl_öğrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ÖğrenciGetir(int id)
        {
            var ogr = db.tbl_öğrenciler.Find(id);

            List<SelectListItem> degerler = (from i in db.tbl_kulüpler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulüpAd,
                                                 Value = i.KulüpID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("ÖğrenciGetir", ogr);
        }

        public ActionResult Güncelle(tbl_öğrenciler p)
        {
            var ogr = db.tbl_öğrenciler.Find(p.ÖğrenciID);
            ogr.ÖğrAD = p.ÖğrAD;
            ogr.ÖğrSoyad = p.ÖğrSoyad;
            ogr.ÖğrFotoğraf = p.ÖğrFotoğraf;
            ogr.ÖğrCinsiyet = p.ÖğrCinsiyet;
            ogr.ÖğrKulüp = p.ÖğrKulüp;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }
    }
}
