using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingBuddy.Models;

namespace ShoppingBuddy.Controllers
{
    public class day_of_weekController : Controller
    {
        private TafeBuddyEntities db = new TafeBuddyEntities();

        // GET: day_of_week
        public ActionResult Index()
        {
            return View(db.day_of_week.ToList());
        }

        // GET: day_of_week/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            day_of_week day_of_week = db.day_of_week.Find(id);
            if (day_of_week == null)
            {
                return HttpNotFound();
            }
            return View(day_of_week);
        }

        // GET: day_of_week/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: day_of_week/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DayCode,DayShortName,DayLongName")] day_of_week day_of_week)
        {
            if (ModelState.IsValid)
            {
                db.day_of_week.Add(day_of_week);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(day_of_week);
        }

        // GET: day_of_week/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            day_of_week day_of_week = db.day_of_week.Find(id);
            if (day_of_week == null)
            {
                return HttpNotFound();
            }
            return View(day_of_week);
        }

        // POST: day_of_week/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DayCode,DayShortName,DayLongName")] day_of_week day_of_week)
        {
            if (ModelState.IsValid)
            {
                db.Entry(day_of_week).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(day_of_week);
        }

        // GET: day_of_week/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            day_of_week day_of_week = db.day_of_week.Find(id);
            if (day_of_week == null)
            {
                return HttpNotFound();
            }
            return View(day_of_week);
        }

        // POST: day_of_week/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            day_of_week day_of_week = db.day_of_week.Find(id);
            db.day_of_week.Remove(day_of_week);
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
