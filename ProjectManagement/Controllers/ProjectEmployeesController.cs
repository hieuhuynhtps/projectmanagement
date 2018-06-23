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
    public class ProjectEmployeesController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var tHAMGIAs = db.THAMGIAs.Include(t => t.DUAN).Include(t => t.NHANVIEN);
            return View(tHAMGIAs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMGIA tHAMGIA = db.THAMGIAs.Find(id);
            if (tHAMGIA == null)
            {
                return HttpNotFound();
            }
            return View(tHAMGIA);
        }

        public ActionResult Create()
        {
            ViewBag.MaDA = new SelectList(db.DUANs, "MaDA", "TenDA");
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaNV,MaDA,SoGio")] THAMGIA tHAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.THAMGIAs.Add(tHAMGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDA = new SelectList(db.DUANs, "MaDA", "TenDA", tHAMGIA.MaDA);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tHAMGIA.MaNV);
            return View(tHAMGIA);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THAMGIA tHAMGIA = db.THAMGIAs.Find(id);
            if (tHAMGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDA = new SelectList(db.DUANs, "MaDA", "TenDA", tHAMGIA.MaDA);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tHAMGIA.MaNV);
            return View(tHAMGIA);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaNV,MaDA,SoGio")] THAMGIA tHAMGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHAMGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDA = new SelectList(db.DUANs, "MaDA", "TenDA", tHAMGIA.MaDA);
            ViewBag.MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", tHAMGIA.MaNV);
            return View(tHAMGIA);
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
