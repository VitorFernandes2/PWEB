using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ERecarga.App_Code;
using ERecarga.DAL;
using ERecarga.Models;
using ERecarga.Validation;
using ERecarga.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace ERecarga.Controllers
{
    public class StationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Station
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Index(int? pagina, string procura, string region)
        {
            //var po = db.Stations.ToList();

            List<Station> po;

            if (User.IsInRole("Admin"))
            {
                po = db.Stations.ToList();
            }
            else
            {
                List<Station> selectListItems = new List<Station>();

                foreach (var item in db.Stations.ToList())
                {
                    if (item.OwnerId == User.Identity.GetUserId())
                        selectListItems.Add(item);
                }

                po = selectListItems;
            }

            if (!String.IsNullOrEmpty(procura))
            {
                po = po.Where(s => s.Name.Contains(procura)).ToList();
            }

            if (!String.IsNullOrEmpty(region) && !region.Contains("*"))
            {
                int regionId = Int32.Parse(region);

                po = po.Where(s => s.RegionId == regionId).ToList();

            }

            int pag = (pagina ?? 1);
            ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
            return View(po.ToPagedList(pag, 5));
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
            if (station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }


            return View(station);
        }

        // GET: Station/Create
        [Authorize(Roles = "Owner, Admin")]
        public ActionResult Create()
        {

            if (User.IsInRole("Admin"))
            {
                List<SelectListItem> lista = new List<SelectListItem>();

                string ownerid = null;
                foreach (var item2 in db.Roles)
                {
                    if (item2.Name == ("Owner"))
                        ownerid = item2.Id;
                }

                foreach (var item in db.Users.ToList())
                {
                    var roleid = item.Roles.Select(x => x.RoleId);

                    if(roleid.Count() != 0)
                        if(roleid.First() == ownerid)
                            lista.Add(new SelectListItem { Text = $"{item.Email}", Value = $"{item.Id}" });

                }

                ViewBag.userlist = new SelectList(lista, "Value", "Text");

            }

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
            if(!User.IsInRole("Admin"))
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
            if (station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
            if (station.OwnerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
