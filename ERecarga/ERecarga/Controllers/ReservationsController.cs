using ERecarga.App_Code;
using ERecarga.DAL;
using ERecarga.Models;
using ERecarga.Validation;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ERecarga.Controllers
{
    public class ReservationsController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        [Authorize(Roles = "Owner, Admin, User")]
        public ActionResult Index(int? pagina, string procura, string regiao, string intervalo)
        {
            if (!User.IsInRole("User"))
            {
                var po = db.Reservations.ToList();

                if (!String.IsNullOrEmpty(procura))
                {
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Name.Contains(procura)).ToList();
                }

                if (!String.IsNullOrEmpty(regiao) && !regiao.Contains("*"))
                {
                    int regionId = Int32.Parse(regiao);
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Station.RegionId == regionId).ToList();
                }

                if (!String.IsNullOrEmpty(intervalo) && !intervalo.Contains("*"))
                {
                    int timeBreakId = Int32.Parse(intervalo);
                    po = po.Where(f => f.FillStationTimeBreak.TimeBreakId == timeBreakId).ToList();
                }

                ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
                ViewBag.TimeBreakList = ListTimeBreakFilter.createListItems(db);

                int pag = (pagina ?? 1);
                return View(po.ToPagedList(pag, 5));
            }
            else
            {
                var po = db.Reservations.ToList().Where(m => m.UserId == User.Identity.GetUserId());

                if (!String.IsNullOrEmpty(procura))
                {
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Name.Contains(procura)).ToList();
                }

                if (!String.IsNullOrEmpty(regiao) && !regiao.Contains("*"))
                {
                    int regionId = Int32.Parse(regiao);
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Station.RegionId == regionId).ToList();
                }

                if (!String.IsNullOrEmpty(intervalo) && !intervalo.Contains("*"))
                {
                    int timeBreakId = Int32.Parse(intervalo);
                    po = po.Where(f => f.FillStationTimeBreak.TimeBreakId == timeBreakId).ToList();
                }

                ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
                ViewBag.TimeBreakList = ListTimeBreakFilter.createListItems(db);

                int pag = (pagina ?? 1);
                return View(po.ToPagedList(pag, 5));
            }
        }

        // GET: Reservations/Details/5
        [Authorize(Roles = "Owner, Admin, User")]
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
        [Authorize(Roles = "Owner, Admin, User")]
        public ActionResult Create(int? pagina)
        {

            var po = ListReservationViewModel.createListItems(db);

            ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
            ViewBag.TimeBreakList = ListTimeBreakFilter.createListItems(db);

            int pag = (pagina ?? 1);
            return View(po.ToPagedList(pag, 5));
        }

        // POST: Reservations/Create
        [HttpPost]
        [Authorize(Roles = "Owner, Admin, User")]
        public ActionResult Create(double? Price,
            DateTime? submitdate, int? TimeBreakId, int? pagina, string procura, string regiao, string intervalo)
        {

            int pag = 0;

            if (!String.IsNullOrEmpty(procura) || !String.IsNullOrEmpty(regiao) || !String.IsNullOrEmpty(intervalo))
            {

                var po = ListReservationViewModel.createListItems(db);
                ViewBag.ListRegions = ListRegionsFilter.createListItems(db);
                ViewBag.TimeBreakList = ListTimeBreakFilter.createListItems(db);

                if (!String.IsNullOrEmpty(procura))
                {
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Name.Contains(procura)).ToList();
                }

                if (!String.IsNullOrEmpty(regiao) && !regiao.Contains("*"))
                {
                    int regionId = Int32.Parse(regiao);
                    po = po.Where(f => f.FillStationTimeBreak.FillStation.Station.RegionId == regionId).ToList();
                }

                if (!String.IsNullOrEmpty(intervalo) && !intervalo.Contains("*"))
                {
                    int timeBreakId = Int32.Parse(intervalo);
                    po = po.Where(f => f.FillStationTimeBreak.TimeBreakId == timeBreakId).ToList();
                }

                pag = (pagina ?? 1);
                return View(po.ToPagedList(pag, 5));

            }

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

            if (ModelState.IsValid && !ValidateReservation.AlreadyExistsReservation(reservation))
            {
                // ver se o utilizador tem dinheiro suficiente
                var userId = User.Identity.GetUserId();
                foreach (BankInfo item in db.BankInfos.ToList())
                {

                    if (item.UserId == userId)
                    {

                        if (reservation.Price < item.Quant)
                        {
                            item.Quant = item.Quant - reservation.Price;

                            //// atualizar a base de dados
                            db.Reservations.Add(reservation);
                            db.SaveChanges();

                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Não tem dinheiro suficiente.");
                            pag = (pagina ?? 1);
                            return View(ListReservationViewModel.createListItems(db).ToPagedList(pag, 5));
                        }

                        break;
                    }

                }

                //// atualizar a base de dados
                //db.Reservations.Add(reservation);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "A reserva já existe na base de dados.");
            }

            pag = (pagina ?? 1);
            return View(ListReservationViewModel.createListItems(db).ToPagedList(pag, 5));

        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "Owner, Admin, User")]
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
        [Authorize(Roles = "Owner, Admin, User")]
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
