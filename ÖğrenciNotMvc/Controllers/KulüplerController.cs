using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMvc.Models.EntityFrameWork;

namespace ÖğrenciNotMvc.Controllers
{
    public class KulüplerController : Controller
    {
        // GET: Kulüpler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulüpler = db.tbl_kulüpler.ToList();
            return View(kulüpler);
        }

        [HttpGet]
        public ActionResult YeniKulüp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulüp(tbl_kulüpler p)
        {
            db.tbl_kulüpler.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulüp = db.tbl_kulüpler.Find(id);
            db.tbl_kulüpler.Remove(kulüp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulüpGetir(int id)
        {
            var klp = db.tbl_kulüpler.Find(id);
            return View("KulüpGetir", klp);
        }

        public ActionResult Güncelle(tbl_kulüpler p)
        {
            var klp = db.tbl_kulüpler.Find(p.KulüpID);
            klp.KulüpAd = p.KulüpAd;
            db.SaveChanges();
            return RedirectToAction("Index","Kulüpler");
        }
    }
}