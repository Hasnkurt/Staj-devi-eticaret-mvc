using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using esitem.Entity;

namespace esitem.Controllers
{
    public class AnasayfaController : Controller
    {
        DataContext db = new DataContext();
        public PartialViewResult _FeaturedÜrünList()
        {
            return PartialView(db.Ürüns.Where(i => i.IsApproved && i.IsFeatured).Take(5).ToList());
        }

        public ActionResult Search(string q)
        {
            var p = db.Ürüns.Where(i => i.IsApproved == true);
            if (!string.IsNullOrEmpty(q))
            {
                p = p.Where(i => i.Name.Contains(q) && i.Description.Contains(q));

            }
            return View(p.ToList());
        }
        
        public PartialViewResult Slider()
        {
            return PartialView(db.Ürüns.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        // GET: Anasayfa
        public ActionResult Index()
        {


            return View(db.Ürüns.Where(i => i.IsHome && i.IsApproved).ToList());
        }

        public ActionResult Üründetay(int id)
        {
            return View(db.Ürüns.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult Ürün()
        {
            return View(db.Ürüns.ToList());
        }

        public ActionResult ÜrünList(int id)
        {
            return View(db.Ürüns.Where(i=>i.CategoryId==id).ToList());
        }

        public ActionResult Page404 ()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Ürünler()
        { return View(); }
    }
}