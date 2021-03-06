﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nightpath.DAL;
using Nightpath.Models;
using Microsoft.AspNet.Identity;

namespace Nightpath.Controllers
{
    public class EstablishmentsController : Controller
    {



        private ApplicationDbContext db = new ApplicationDbContext();

    
           public ActionResult Catalog()
           {
               @ViewBag.Establishments = db.Establishments.ToArray();
               @ViewBag.Regions = db.Regions.ToArray();
            return View();
        }

        
        
        
        // GET: Establishments
        public ActionResult Index()
        {
          
            var establishments = db.Establishments.Include(e => e.Region);
            return View(establishments.ToList());
        }

        // GET: Establishments/Details/5
        public ActionResult Details(int? id)
       
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }

        // GET: Establishments/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Regions, "ID", "RegionName");
            return View();
        }

        // POST: Establishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location,Schedule,NIF,ApplicationUserID,RegionID")] Establishment establishment)
        {
            if (ModelState.IsValid)
            {
                //GET ID
                string currentUserID = User.Identity.GetUserId();
                //Search in db for username with this id
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserID);
                db.Establishments.Add(establishment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "ID", "RegionName", establishment.RegionID);
            return View(establishment);
        }

        // GET: Establishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Regions, "ID", "RegionName", establishment.RegionID);
            return View(establishment);
        }

        // POST: Establishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,Schedule,NIF,ApplicationUserID,RegionID")] Establishment establishment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Regions, "ID", "RegionName", establishment.RegionID);
            return View(establishment);
        }

        // GET: Establishments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return HttpNotFound();
            }
            return View(establishment);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Establishment establishment = db.Establishments.Find(id);
            db.Establishments.Remove(establishment);
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
