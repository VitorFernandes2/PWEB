﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERecarga.App_Code;
using ERecarga.DAL;
using ERecarga.Models;
using Microsoft.AspNet.Identity;

namespace ERecarga.Controllers
{
    public class FillStationTimeBreakController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FillStationTimeBreak
        public ActionResult Index()
        {
            var fillStationTimeBreaks = db.FillStationTimeBreaks.Include(f => f.FillStation).Include(f => f.TimeBreak);
            return View(fillStationTimeBreaks.ToList());
        }

        // GET: FillStationTimeBreak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStationTimeBreak fillStationTimeBreak = db.FillStationTimeBreaks.Find(id);
            if (fillStationTimeBreak == null)
            {
                return HttpNotFound();
            }
            return View(fillStationTimeBreak);
        }

        // GET: FillStationTimeBreak/Create
        public ActionResult Create()
        {
            var user = User.Identity.GetUserId();
            ViewBag.FillStationList = ListFillStationsByUserId.createListItems(db, user);
            ViewBag.TimeBreakList = ListTimeBreakFill.createListItems(db);
            return View();
        }

        // POST: FillStationTimeBreak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FillStationTimeBreak fillStationTimeBreak)
        {
            if (ModelState.IsValid)
            {
                db.FillStationTimeBreaks.Add(fillStationTimeBreak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var user = User.Identity.GetUserId();
            ViewBag.FillStationList = ListFillStationsByUserId.createListItems(db, user);
            ViewBag.TimeBreakList = ListTimeBreakFill.createListItems(db); 
            return View(fillStationTimeBreak);
        }

        // GET: FillStationTimeBreak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStationTimeBreak fillStationTimeBreak = db.FillStationTimeBreaks.Find(id);
            if (fillStationTimeBreak == null)
            {
                return HttpNotFound();
            }
            var user = User.Identity.GetUserId();
            int fillstation = db.FillStationTimeBreaks.Find(id).FillStationId;
            int timebreak = db.FillStationTimeBreaks.Find(id).TimeBreakId;
            ViewBag.FillStationId = ListFillStationsByUserIdEdit.createListItems(db, user, fillstation);
            ViewBag.TimeBreakId = ListTimeBreakFillEdit.createListItems(db, timebreak);
            return View(fillStationTimeBreak);
        }

        // POST: FillStationTimeBreak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FillStationId,TimeBreakId")] FillStationTimeBreak fillStationTimeBreak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fillStationTimeBreak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FillStationId = new SelectList(db.FillStations, "Id", "Name", fillStationTimeBreak.FillStationId);
            ViewBag.TimeBreakId = new SelectList(db.TimeBreaks, "TimeBreakId", "TimeBreakId", fillStationTimeBreak.TimeBreakId);
            return View(fillStationTimeBreak);
        }

        // GET: FillStationTimeBreak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStationTimeBreak fillStationTimeBreak = db.FillStationTimeBreaks.Find(id);
            if (fillStationTimeBreak == null)
            {
                return HttpNotFound();
            }

            return View(fillStationTimeBreak);
        }

        // POST: FillStationTimeBreak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FillStationTimeBreak fillStationTimeBreak = db.FillStationTimeBreaks.Find(id);
            db.FillStationTimeBreaks.Remove(fillStationTimeBreak);
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
