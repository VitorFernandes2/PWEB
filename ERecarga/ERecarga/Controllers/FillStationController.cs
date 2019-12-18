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
using ERecarga.Validation;
using Microsoft.AspNet.Identity;
using PagedList;

namespace ERecarga.Controllers
{
    public class FillStationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FillStation
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index(int? pagina, string procura, string regiao)
        {
            var fillStations = db.FillStations.Include(f => f.Station);
            //var po = fillStations.ToList();
            List<FillStation> po;

            if (User.IsInRole("Admin"))
            {
                po = fillStations.ToList();
            }
            else
            {
                List<FillStation> selectListItems = new List<FillStation>();

                foreach (var item in fillStations.ToList())
                {
                    foreach(var sation in db.Stations.ToList())
                    {

                        if(item.StationId == sation.Id && sation.OwnerId == User.Identity.GetUserId())
                            selectListItems.Add(item);

                    }

                }

                po = selectListItems;
            }


            if (!String.IsNullOrEmpty(procura))
            {
                po = po.Where(s => s.Station.Name.Contains(procura)).ToList();
            }

            if (!String.IsNullOrEmpty(regiao) && !regiao.Contains("*"))
            {
                int regionId = Int32.Parse(regiao);
                po = po.Where(s => s.Station.RegionId == regionId).ToList();
            }


            ViewBag.ListRegions = ListRegionsFilter.createListItems(db);

            int pag = (pagina ?? 1);
            return View(po.ToPagedList(pag, 5));
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
            if (fillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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

            if (fillStation.Price == 0)
            {
                if (User.IsInRole("Admin"))
                    ViewBag.StationIdList = ListStationByUserId.createallListItems(db);
                else
                    ViewBag.StationIdList = ListStationByUserId.createListItems(db, User.Identity.GetUserId());

                return View(fillStation);
            }

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
            if (fillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
            if (fillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
