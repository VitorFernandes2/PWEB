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

namespace ERecarga.Controllers
{
    public class TimeBreakController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeBreak
        public ActionResult Index()
        {
            return View(db.TimeBreaks.ToList());
        }

        // GET: TimeBreak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBreak timeBreak = db.TimeBreaks.Find(id);
            if (timeBreak == null)
            {
                return HttpNotFound();
            }
            return View(timeBreak);
        }

        // GET: TimeBreak/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeBreak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeBreakId,Begin,End")] TimeBreak timeBreak)
        {
            if (ModelState.IsValid)
            {
                db.TimeBreaks.Add(timeBreak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeBreak);
        }

        // GET: TimeBreak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBreak timeBreak = db.TimeBreaks.Find(id);
            if (timeBreak == null)
            {
                return HttpNotFound();
            }
            return View(timeBreak);
        }

        // POST: TimeBreak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeBreakId,Begin,End")] TimeBreak timeBreak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeBreak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeBreak);
        }

        // GET: TimeBreak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBreak timeBreak = db.TimeBreaks.Find(id);
            if (timeBreak == null)
            {
                return HttpNotFound();
            }
            return View(timeBreak);
        }

        // POST: TimeBreak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeBreak timeBreak = db.TimeBreaks.Find(id);
            db.TimeBreaks.Remove(timeBreak);
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
