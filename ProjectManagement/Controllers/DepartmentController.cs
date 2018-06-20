using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Department
        public ActionResult Index()
        {
            var pHONGBANs = db.PHONGBANs.Include(p => p.TRUSO_PHONG);
            return View(pHONGBANs.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.TRUSO_PHONGs, "MaPB", "TruSo");
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPB,TenPB,TrPhong,NgayNhanChuc")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.PHONGBANs.Add(pHONGBAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.TRUSO_PHONGs, "MaPB", "TruSo", pHONGBAN.MaPB);
            return View(pHONGBAN);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.TRUSO_PHONGs, "MaPB", "TruSo", pHONGBAN.MaPB);
            return View(pHONGBAN);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPB,TenPB,TrPhong,NgayNhanChuc")] PHONGBAN pHONGBAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHONGBAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.TRUSO_PHONGs, "MaPB", "TruSo", pHONGBAN.MaPB);
            return View(pHONGBAN);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            if (pHONGBAN == null)
            {
                return HttpNotFound();
            }
            return View(pHONGBAN);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHONGBAN pHONGBAN = db.PHONGBANs.Find(id);
            db.PHONGBANs.Remove(pHONGBAN);
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
