using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GiderlerController : Controller
    {
        // GET: Giderler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler= c.Giders.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult GiderlerEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GiderlerEkle(Gider k)
        {
            c.Giders.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GiderGetir(int id)
        {
            var gdr = c.Giders.Find(id);
            return View("GiderGetir", gdr);
        }
        public ActionResult GıderGuncelle( Gider g)
        {
            var gd = c.Giders.Find(g.Giderid);
            gd.Aciklama = g.Aciklama;
            gd.Tarih = g.Tarih;
            gd.Tutar = g.Tutar;
            gd.Aylar = g.Aylar;
            c.SaveChanges();
            return RedirectToAction("Index");
        
        
        }

        public ActionResult VisualizeGiderResult2()
        {
            return Json(Giderlistesi(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index5()
        {
            return View();
        }
        public List<sinif4> Giderlistesi()
        {
            List<sinif4> snf = new List<sinif4>();
            using (var c = new Context())
            {
                snf = c.Giders.Select(x => new sinif4
                {
                    Aylar = x.Aylar,
                    Tutar = (int)x.Tutar
                }).ToList();
            }
            return snf;
        }
    }
}