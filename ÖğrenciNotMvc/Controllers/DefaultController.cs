using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ÖğrenciNotMvc.Models.EntityFrameWork;

namespace ÖğrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.tbl_dersler.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(tbl_dersler p)
        {
            db.tbl_dersler.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.tbl_dersler.Find(id);
            db.tbl_dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var ders = db.tbl_dersler.Find(id);
            return View("DersGetir", ders);
        }

        public ActionResult Güncelle(tbl_dersler p)
        {
            var ders = db.tbl_dersler.Find(p.DersID);
            ders.DersAD = p.DersAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

    }
}