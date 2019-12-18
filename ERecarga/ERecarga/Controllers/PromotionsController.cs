using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERecarga.DAL;
using ERecarga.Models;
using ERecarga.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace ERecarga.Controllers
{
    public class PromotionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promotions
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index(int? pagina)
        {
            var promotions = db.Promotions.Include(p => p.FillStation);
            //var po = promotions.ToList();
            List<Promotion> po;

            if (User.IsInRole("Admin"))
            {
                po = promotions.ToList();
            }
            else
            {
                List<Promotion> selectListItems = new List<Promotion>();

                foreach (var item in promotions.ToList())
                {
                    foreach (var fillstat in db.FillStations.ToList())
                    {
                        foreach (var sation in db.Stations.ToList())
                        {

                            if (fillstat.StationId == sation.Id && item.FillStationId == fillstat.Id && sation.OwnerId == User.Identity.GetUserId())
                                selectListItems.Add(item);

                        }
                    }
                }

                po = selectListItems;
            }
            

            int pag = (pagina ?? 1);
            return View(po.ToPagedList(pag, 5));
        }

        // GET: Promotions/Details/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = db.Promotions.Find(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            if (promotion.FillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(promotion);
        }

        // GET: Promotions/Create
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create()
        {
            //ViewBag.FillStationId = new SelectList(db.FillStations, "Id", "Name");
            //return View(new PromotionViewModel(db));

            if (User.IsInRole("Admin"))
                return View(new PromotionViewModel(db));
            else
                return View(new PromotionViewModel(db,User.Identity.GetUserId()));

        }

        // POST: Promotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create([Bind(Include = "Id,FillStationId,Price,PromotionStart,PromotionEnd")] Promotion promotion)
        {

            if (promotion.Price == 0)
            {
                return View(new PromotionViewModel(db));
            }

            if (ModelState.IsValid)
            {
                db.Promotions.Add(promotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FillStationId = new SelectList(db.FillStations, "Id", "Name", promotion.FillStationId);
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = db.Promotions.Find(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            if (promotion.FillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.FillStationId = new SelectList(db.FillStations, "Id", "Name", promotion.FillStationId);
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit([Bind(Include = "Id,FillStationId,Price,PromotionStart,PromotionEnd")] Promotion promotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FillStationId = new SelectList(db.FillStations, "Id", "Name", promotion.FillStationId);
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotion promotion = db.Promotions.Find(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            if (promotion.FillStation.Station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Promotion promotion = db.Promotions.Find(id);
            db.Promotions.Remove(promotion);
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
