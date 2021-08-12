using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using esitem.Entity;

namespace esitem.Controllers
{
    public class ÜrünController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ürün
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            var ürüns = db.Ürüns.Include(ü => ü.Category);
            return View(ürüns.ToList());
        }

        // GET: Ürün/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ürün ürün = db.Ürüns.Find(id);
            if (ürün == null)
            {
                return HttpNotFound();
            }
            return View(ürün);
        }

        // GET: Ürün/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Ürün/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Ürün ürün,HttpPostedFileBase File)
        {

            string path = System.IO.Path.Combine("/Content/image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            ürün.İmage = File.FileName.ToString();
            db.Ürüns.Add(ürün);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        // GET: Ürün/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ürün ürün = db.Ürüns.Find(id);
            if (ürün == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ürün.CategoryId);
            return View(ürün);
        }

        // POST: Ürün/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,İmage,Price,Stock,Slider,IsHome,IsFeatured,IsApproved,CategoryId")] Ürün ürün)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ürün).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", ürün.CategoryId);
            return View(ürün);
        }

        // GET: Ürün/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ürün ürün = db.Ürüns.Find(id);
            if (ürün == null)
            {
                return HttpNotFound();
            }
            return View(ürün);
        }

        // POST: Ürün/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ürün ürün = db.Ürüns.Find(id);
            db.Ürüns.Remove(ürün);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
