﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context c = new Context();
        public ActionResult Index(int id)
        {
            Class1 cs = new Class1();
            //var degerler = c.Uruns.Where(x => x.Urunid == 1).ToList();
            cs.Deger1 = c.Uruns.Where(x => x.Urunid == id).ToList();
            cs.Deger2= c.Detays.Where(x => x.DetayID == id).ToList();
            return View(cs);
        } 

    }
}