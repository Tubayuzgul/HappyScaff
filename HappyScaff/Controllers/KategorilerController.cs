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
    public class KategorilerController : Controller
    {
        private HappyScafEntities db = new HappyScafEntities();

        // GET: Kategoriler/KategorilerIndex
        public ActionResult KategorilerIndex()
        {
            return View(db.Kategoriler.ToList());
        }

        /*
        // GET: Kategoriler/KategorilerDetails/5
        public ActionResult KategorilerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }
        */

        // GET: Kategoriler/KategorilerCreate
        public ActionResult KategorilerCreate()
        {
            return View();
        }

        // POST: Kategoriler/KategorilerCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategorilerCreate([Bind(Include = "KategoriId,KategoriBaslik,KategoriIcerik,Makaleler")] Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {

                db.Kategoriler.Add(kategoriler);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Kategoriler record");
                return RedirectToAction("KategorilerIndex");
            }

            DisplayErrorMessage();
            return View(kategoriler);
        }

        // GET: Kategoriler/KategorilerEdit/5
        public ActionResult KategorilerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: KategorilerKategoriler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KategorilerEdit([Bind(Include = "KategoriId,KategoriBaslik,KategoriIcerik,Makaleler")] Kategoriler kategoriler, int Id)
        {
            if (ModelState.IsValid)
            {
                kategoriler.KategoriId = Id;
                db.Entry(kategoriler).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Kategoriler record");
                return RedirectToAction("KategorilerIndex");
            }
            DisplayErrorMessage();
            return View(kategoriler);
        }

        // GET: Kategoriler/KategorilerDelete/5
        public ActionResult KategorilerDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            if (kategoriler == null)
            {
                return HttpNotFound();
            }
            return View(kategoriler);
        }

        // POST: Kategoriler/KategorilerDelete/5
        [HttpPost, ActionName("KategorilerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult KategorilerDeleteConfirmed(int id)
        {
            Kategoriler kategoriler = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategoriler);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Kategoriler record");
            return RedirectToAction("KategorilerIndex");
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
