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
using PagedList;

namespace ERecarga.Controllers
{
    public class FillStationTimeBreakController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FillStationTimeBreak
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index(int? pagina, string procura, string regiao, string intervalo)
        {
            var fillStationTimeBreaks = db.FillStationTimeBreaks.Include(f => f.FillStation).Include(f => f.TimeBreak);
            var po = fillStationTimeBreaks.ToList();

            if (!String.IsNullOrEmpty(procura))
            {
                po = po.Where(f => f.FillStation.Name.Contains(procura)).ToList();
            }

            if (!String.IsNullOrEmpty(regiao) && !regiao.Contains("*"))
            {
                int regionId = Int32.Parse(regiao);
                po = po.Where(f => f.FillStation.Station.RegionId == regionId).ToList();
            }

            if (!String.IsNullOrEmpty(intervalo) && !intervalo.Contains("*"))
            {
                int timeBreakId = Int32.Parse(intervalo);
                po = po.Where(f => f.TimeBreakId == timeBreakId).ToList();
            }

            int pag = (pagina ?? 1);

            var user = User.Identity.GetUserId();

            ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
            ViewBag.TimeBreakList = ListTimeBreakFilter.createListItems(db);

            return View(po.ToPagedList(pag, 5));
        }

        // GET: FillStationTimeBreak/Details/5
        [Authorize(Roles = "Owner, Admin")]
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
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create()
        {
            var user = User.Identity.GetUserId();

            if (User.IsInRole("Admin"))
                ViewBag.FillStationList = ListFillStationsByUserId.createAllListItems(db);
            else
                ViewBag.FillStationList = ListFillStationsByUserId.createListItems(db, user);
            ViewBag.TimeBreakList = ListTimeBreakFill.createListItems(db);
            return View();
        }

        // POST: FillStationTimeBreak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create(FillStationTimeBreak fillStationTimeBreak)
        {
            if (ModelState.IsValid)
            {

                if (ValidateFillStationTimeBreak.AlreadyExistsFillStationTimeBreak(fillStationTimeBreak))
                {

                    ModelState.AddModelError(string.Empty, "O posto já contém este intervalo.");

                    var userId = User.Identity.GetUserId();

                    if (User.IsInRole("Admin"))
                        ViewBag.FillStationList = ListFillStationsByUserId.createAllListItems(db);
                    else
                        ViewBag.FillStationList = ListFillStationsByUserId.createListItems(db, userId);
                    ViewBag.TimeBreakList = ListTimeBreakFill.createListItems(db);

                    return View(fillStationTimeBreak);

                }

                db.FillStationTimeBreaks.Add(fillStationTimeBreak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var user = User.Identity.GetUserId();
            if (User.IsInRole("Admin"))
                ViewBag.FillStationList = ListFillStationsByUserId.createAllListItems(db);
            else
                ViewBag.FillStationList = ListFillStationsByUserId.createListItems(db, user);
            ViewBag.TimeBreakList = ListTimeBreakFill.createListItems(db);
            return View(fillStationTimeBreak);
        }

        // GET: FillStationTimeBreak/Edit/5
        [Authorize(Roles = "Owner, Admin")]
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
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Edit([Bind(Include = "Id,FillStationId,TimeBreakId")] FillStationTimeBreak fillStationTimeBreak)
        {
            if (ModelState.IsValid)
            {

                if (ValidateFillStationTimeBreak.AlreadyExistsFillStationTimeBreak(fillStationTimeBreak))
                {

                    ModelState.AddModelError(string.Empty, "O posto já contém este intervalo.");

                    var userId = User.Identity.GetUserId();
                    int fillstation2 = db.FillStationTimeBreaks.Find(fillStationTimeBreak.Id).FillStationId;
                    int timebreak2 = db.FillStationTimeBreaks.Find(fillStationTimeBreak.Id).TimeBreakId;
                    ViewBag.FillStationId = ListFillStationsByUserIdEdit.createListItems(db, userId, fillstation2);
                    ViewBag.TimeBreakId = ListTimeBreakFillEdit.createListItems(db, timebreak2);

                    return View(fillStationTimeBreak);

                }

                db.Entry(fillStationTimeBreak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var user = User.Identity.GetUserId();
            int fillstation = db.FillStationTimeBreaks.Find(fillStationTimeBreak.Id).FillStationId;
            int timebreak = db.FillStationTimeBreaks.Find(fillStationTimeBreak.Id).TimeBreakId;
            ViewBag.FillStationId = ListFillStationsByUserIdEdit.createListItems(db, user, fillstation);
            ViewBag.TimeBreakId = ListTimeBreakFillEdit.createListItems(db, timebreak);
            return View(fillStationTimeBreak);
        }

        // GET: FillStationTimeBreak/Delete/5
        [Authorize(Roles = "Owner, Admin")]
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
        [Authorize(Roles = "Owner, Admin")]
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
