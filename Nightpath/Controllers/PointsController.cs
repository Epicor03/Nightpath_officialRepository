using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nightpath.DAL;
using Nightpath.Models;

namespace Nightpath.Controllers
{
    public class PointsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Points
        public ActionResult Index()
        {
            var points = db.Points.Include(p => p.Establishment);
            return View(points.ToList());
        }

        // GET: Points/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Points points = db.Points.Find(id);
            if (points == null)
            {
                return HttpNotFound();
            }
            return View(points);
        }

        // GET: Points/Create
        public ActionResult Create()
        {
            ViewBag.EstablishmentID = new SelectList(db.Establishments, "ID", "Name");
            return View();
        }

        // POST: Points/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EstablishmentID,ApplicationUserID,PointsNumber")] Points points)
        {
            if (ModelState.IsValid)
            {
                db.Points.Add(points);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstablishmentID = new SelectList(db.Establishments, "ID", "Name", points.EstablishmentID);
            return View(points);
        }

        // GET: Points/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Points points = db.Points.Find(id);
            if (points == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstablishmentID = new SelectList(db.Establishments, "ID", "Name", points.EstablishmentID);
            return View(points);
        }

        // POST: Points/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EstablishmentID,ApplicationUserID,PointsNumber")] Points points)
        {
            if (ModelState.IsValid)
            {
                db.Entry(points).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstablishmentID = new SelectList(db.Establishments, "ID", "Name", points.EstablishmentID);
            return View(points);
        }

        // GET: Points/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Points points = db.Points.Find(id);
            if (points == null)
            {
                return HttpNotFound();
            }
            return View(points);
        }

        // POST: Points/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Points points = db.Points.Find(id);
            db.Points.Remove(points);
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
