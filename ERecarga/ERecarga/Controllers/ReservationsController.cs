﻿using ERecarga.App_Code;
using ERecarga.DAL;
using ERecarga.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ERecarga.Controllers
{
    public class ReservationsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        public ActionResult Index()
        {
            return View(db.Reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View(ListReservationViewModel.createListItems(db));
        }

        // POST: Reservations/Create
        [HttpPost]
        public ActionResult Create(double? Price,
            DateTime? submitdate, int? TimeBreakId)
        {

            Reservation reservation = new Reservation();

            if (Price != null)
                reservation.Price = (double)Price;
            else
                return View(ListReservationViewModel.createListItems(db));

            if (TimeBreakId != null)
                reservation.FillStationTimeBreakId = (int)TimeBreakId;
            else
                return View(ListReservationViewModel.createListItems(db));

            if (submitdate != null)
                reservation.Day = (DateTime)submitdate;
            else
                return View(ListReservationViewModel.createListItems(db));

            if (User.IsInRole("User"))
            {
                reservation.UserId = User.Identity.GetUserId();
            }

            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ListReservationViewModel.createListItems(db));

        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
