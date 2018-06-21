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
    public class ProjectController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var dUANs = db.DUANs.Include(d => d.PHONGBAN);
            return View(dUANs.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        public ActionResult Create()
        {
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDA,TenDA,DiaDiem,MaPB")] DUAN dUAN)
        {
            if (ModelState.IsValid)
            {
                db.DUANs.Add(dUAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", dUAN.MaPB);
            return View(dUAN);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", dUAN.MaPB);
            return View(dUAN);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDA,TenDA,DiaDiem,MaPB")] DUAN dUAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dUAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPB = new SelectList(db.PHONGBANs, "MaPB", "TenPB", dUAN.MaPB);
            return View(dUAN);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DUAN dUAN = db.DUANs.Find(id);
            if (dUAN == null)
            {
                return HttpNotFound();
            }
            return View(dUAN);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DUAN dUAN = db.DUANs.Find(id);
            db.DUANs.Remove(dUAN);
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
