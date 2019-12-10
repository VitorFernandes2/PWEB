using System;
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
using ERecarga.Validation;
using Microsoft.AspNet.Identity;

namespace ERecarga.Controllers
{
    public class FillStationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FillStation
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index()
        {
            var fillStations = db.FillStations.Include(f => f.Station);
            return View(fillStations.ToList());
        }

        // GET: FillStation/Details/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStation fillStation = db.FillStations.Find(id);
            if (fillStation == null)
            {
                return HttpNotFound();
            }
            return View(fillStation);
        }

        // GET: FillStation/Create
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            if (User.IsInRole("Admin"))
                ViewBag.StationIdList = ListStationByUserId.createallListItems(db);
            else
                ViewBag.StationIdList = ListStationByUserId.createListItems(db, userId);
            return View();
        }

        // POST: FillStation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create(FillStation fillStation)
        {

            fillStation.Open = true;

            if (ModelState.IsValid)
            {

                if (ValidateFillStation.AlreadyExistsFillStation(fillStation))
                {

                    ModelState.AddModelError(string.Empty, "O posto já existe na base de dados.");

                    var userId = User.Identity.GetUserId();

                    if (User.IsInRole("Admin"))
                        ViewBag.StationIdList = ListStationByUserId.createallListItems(db);
                    else
                        ViewBag.StationIdList = ListStationByUserId.createListItems(db, userId);

                    return View(fillStation);

                }

                db.FillStations.Add(fillStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fillStation);

        }

        // GET: FillStation/Edit/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStation fillStation = db.FillStations.Find(id);
            if (fillStation == null)
            {
                return HttpNotFound();
            }
            var userId = User.Identity.GetUserId();
            ViewBag.StationIdList = ListStationByUserIdEdit.createListItems(db, userId, fillStation.StationId);
            return View(fillStation);
        }

        // POST: FillStation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Type,Open,StationId")] FillStation fillStation)
        {
            if (ModelState.IsValid)
            {

                if (ValidateFillStation.AlreadyExistsFillStation(fillStation))
                {

                    ModelState.AddModelError(string.Empty, "O posto já existe na base de dados.");

                    var userId = User.Identity.GetUserId();

                    if (User.IsInRole("Admin"))
                        ViewBag.StationIdList = ListStationByUserId.createallListItems(db);
                    else
                        ViewBag.StationIdList = ListStationByUserId.createListItems(db, userId);

                    return View(fillStation);

                }

                db.Entry(fillStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationId = new SelectList(db.Stations, "Id", "OwnerId", fillStation.StationId);
            return View(fillStation);
        }

        // GET: FillStation/Delete/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FillStation fillStation = db.FillStations.Find(id);
            if (fillStation == null)
            {
                return HttpNotFound();
            }
            return View(fillStation);
        }

        // POST: FillStation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            FillStation fillStation = db.FillStations.Find(id);
            db.FillStations.Remove(fillStation);
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
