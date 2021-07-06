using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.PersonelGorsel = "/Images/" + randomName;

                var path = "~/Images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));
                //string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                //string yol = "/Images/" + dosyaadi ;
                //Request.Files[0].SaveAs(Server.MapPath(yol));
                //p.PersonelGorsel = "/Images" + dosyaadi ;

            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.Departmanid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)

            {

                var extention = Path.GetExtension(Request.Files[0].FileName);

                var randomName = string.Format($"{DateTime.Now.Ticks}{extention}");

                //var randomName = string.Format($"{Guid.NewGuid().ToString().Replace("-", "")}{extention}");

                p.PersonelGorsel = "/Images/" + randomName;

                var path = "~/Images/" + randomName;

                Request.Files[0].SaveAs(Server.MapPath(path));

            }


            var prsn = c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}