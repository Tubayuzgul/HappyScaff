using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HappyScaff.Models;

namespace HappyScaff.Controllers
{
    public class MakalelerController : Controller
    {
        private HappyScafEntities db = new HappyScafEntities();

        // GET: Makaleler/MakalelerIndex
        public ActionResult MakalelerIndex()
        {
            var makaleler = db.Makaleler.Include(m => m.Kategoriler);
            return View(makaleler.ToList());
        }

        /*
        // GET: Makaleler/MakalelerDetails/5
        public ActionResult MakalelerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makaleler makaleler = db.Makaleler.Find(id);
            if (makaleler == null)
            {
                return HttpNotFound();
            }
            return View(makaleler);
        }
        */

        // GET: Makaleler/MakalelerCreate
        public ActionResult MakalelerCreate()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriBaslik");
            return View();
        }

        // POST: Makaleler/MakalelerCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakalelerCreate([Bind(Include = "MakaleId,MakaleBaslik,MakaleIcerik,KategoriId,Kategoriler")] Makaleler makaleler)
        {
            if (ModelState.IsValid)
            {
                db.Makaleler.Add(makaleler);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Makaleler record");
                return RedirectToAction("MakalelerIndex");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriBaslik", makaleler.KategoriId);
            DisplayErrorMessage();
            return View(makaleler);
        }

        // GET: Makaleler/MakalelerEdit/5
        public ActionResult MakalelerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makaleler makaleler = db.Makaleler.Find(id);
            if (makaleler == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriBaslik", makaleler.KategoriId);
            return View(makaleler);
        }

        // POST: MakalelerMakaleler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakalelerEdit([Bind(Include = "MakaleId,MakaleBaslik,MakaleIcerik,KategoriId,Kategoriler")] Makaleler makaleler, int Id)
        {
            if (ModelState.IsValid)
            {
                makaleler.MakaleId = Id;
                db.Entry(makaleler).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Makaleler record");
                return RedirectToAction("MakalelerIndex");
            }
            ViewBag.KategoriId = new SelectList(db.Kategoriler, "KategoriId", "KategoriBaslik", makaleler.KategoriId);
            DisplayErrorMessage();
            return View(makaleler);
        }

        // GET: Makaleler/MakalelerDelete/5
        public ActionResult MakalelerDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Makaleler makaleler = db.Makaleler.Find(id);
            if (makaleler == null)
            {
                return HttpNotFound();
            }
            return View(makaleler);
        }

        // POST: Makaleler/MakalelerDelete/5
        [HttpPost, ActionName("MakalelerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MakalelerDeleteConfirmed(int id)
        {
            Makaleler makaleler = db.Makaleler.Find(id);
            db.Makaleler.Remove(makaleler);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Makaleler record");
            return RedirectToAction("MakalelerIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
