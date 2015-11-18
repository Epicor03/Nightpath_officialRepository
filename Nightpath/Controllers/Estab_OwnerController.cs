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
    public class Estab_OwnerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estab_Owner
        public ActionResult Index()
        {
            return View(db.Estab_Owners.ToList());
        }

        // GET: Estab_Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estab_Owner estab_Owner = db.Estab_Owners.Find(id);
            if (estab_Owner == null)
            {
                return HttpNotFound();
            }
            return View(estab_Owner);
        }

        // GET: Estab_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estab_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID")] Estab_Owner estab_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Estab_Owners.Add(estab_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estab_Owner);
        }

        // GET: Estab_Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estab_Owner estab_Owner = db.Estab_Owners.Find(id);
            if (estab_Owner == null)
            {
                return HttpNotFound();
            }
            return View(estab_Owner);
        }

        // POST: Estab_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID")] Estab_Owner estab_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estab_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estab_Owner);
        }

        // GET: Estab_Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estab_Owner estab_Owner = db.Estab_Owners.Find(id);
            if (estab_Owner == null)
            {
                return HttpNotFound();
            }
            return View(estab_Owner);
        }

        // POST: Estab_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estab_Owner estab_Owner = db.Estab_Owners.Find(id);
            db.Estab_Owners.Remove(estab_Owner);
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
