using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionBd.Context;
using AuctionBd.Models;

namespace AuctionBd.Controllers
{
    public class PersonalInformationsController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: PersonalInformations
        public ActionResult Index()
        {
            return View(db.PersonalInformations.ToList());
        }

        // GET: PersonalInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformations.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // GET: PersonalInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmailAddress,MobailNumber,Address")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                db.PersonalInformations.Add(personalInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalInformation);
        }

        // GET: PersonalInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformations.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // POST: PersonalInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmailAddress,MobailNumber,Address")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalInformation);
        }

        // GET: PersonalInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInformation personalInformation = db.PersonalInformations.Find(id);
            if (personalInformation == null)
            {
                return HttpNotFound();
            }
            return View(personalInformation);
        }

        // POST: PersonalInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalInformation personalInformation = db.PersonalInformations.Find(id);
            db.PersonalInformations.Remove(personalInformation);
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
