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
using ERecarga.ViewModels;
using Microsoft.AspNet.Identity;

namespace ERecarga.Controllers
{
    public class StationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Station
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index()
        {
            return View(db.Stations.ToList());
        }

        // GET: Station/Details/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Station/Create
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create()
        {
            return View(new StationViewModel(db));
        }

        // POST: Station/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create(Station station)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            station.OwnerId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {

                if (ValidateStation.AlreadyExistsStation(station))
                {

                    ModelState.AddModelError(string.Empty, "A estação já existe na base de dados.");

                    StationViewModel viewModel = new StationViewModel(db);
                    viewModel.Name = station.Name;
                    ViewBag.ListRegions = ListRegionsById.createListItems(db, station.RegionId);
                    return View(viewModel);

                }

                db.Stations.Add(station);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(new StationViewModel(db));
        }

        // GET: Station/Edit/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListRegions = ListRegionsById.createListItems(db, station.RegionId);
            return View(station);
        }

        // POST: Station/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit(Station station)
        {

            station.OwnerId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {

                if (ValidateStation.AlreadyExistsStation(station))
                {

                    ModelState.AddModelError(string.Empty, "A estação já existe na base de dados.");

                    ViewBag.ListRegions = ListRegionsById.createListItems(db, station.RegionId);
                    return View(station);

                }

                db.Entry(station).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(station);
        }

        // GET: Station/Delete/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = db.Stations.Find(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Station/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Station station = db.Stations.Find(id);
            db.Stations.Remove(station);
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
