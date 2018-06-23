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
    public class EmployeesController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.PHONGBAN);
            return View(nHANVIENs.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.GioiTinh = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Nam", Value = "1"},
                    new SelectListItem { Text = "Nữ", Value = "0"},
                }, "Value", "Text"
            );
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoNV,TenNV,NgaySinh,DiaChi,GioiTinh,DienThoai,MaPB")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GioiTinh = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Nam", Value = "1"},
                    new SelectListItem { Text = "Nữ", Value = "0"},
                }, "Value", "Text", nHANVIEN.GioiTinh
            );
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nHANVIEN.MaPB);
            return View(nHANVIEN);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.GioiTinh = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Nam", Value = "1"},
                    new SelectListItem { Text = "Nữ", Value = "0"},

                }, "Value", "Text", nHANVIEN.GioiTinh
            );
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nHANVIEN.MaPB);
            return View(nHANVIEN);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoNV,TenNV,NgaySinh,DiaChi,GioiTinh,DienThoai,MaPB")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GioiTinh = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Nam", Value = "1"},
                    new SelectListItem { Text = "Nữ", Value = "0"},
                }, "Value", "Text", nHANVIEN.GioiTinh
            );
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", nHANVIEN.MaPB);
            return View(nHANVIEN);
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
