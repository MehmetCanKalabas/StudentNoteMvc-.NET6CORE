using ÖğrenciNotMvc.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMvc.Models;

namespace ÖğrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.tbl_notlar.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult YeniSınav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSınav(tbl_notlar p)
        {
            db.tbl_notlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var not = db.tbl_notlar.Find(id);
            return View("NotGetir", not);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model, tbl_notlar p, int Sınav1 = 0, int Sınav2 = 0, int Sınav3 = 0, int Proje = 0)
        {
            if (model.islem == "Hesapla")
            {
                //işlem1
                int ortalama = (Sınav1 + Sınav2 + Sınav3 + Proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem == "NotGüncelle")
            {
                var snv = db.tbl_notlar.Find(p);
                snv.Sınav1 = p.Sınav1;
                snv.Sınav2 = p.Sınav2;
                snv.Sınav3 = p.Sınav3;
                snv.Proje = p.Proje;
                snv.Ortalama = p.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index","Notlar");             
            }
            return View();
        }
    }
}