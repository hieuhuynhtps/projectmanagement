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

        public ActionResult Index()
        {
            var pHONGBANs = db.PHONGBANs.Include(p => p.TRUSO_PHONG);
            return View(pHONGBANs.ToList());
        }

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

        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.TRUSO_PHONGs, "MaPB", "TruSo");
            return View();
        }

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
