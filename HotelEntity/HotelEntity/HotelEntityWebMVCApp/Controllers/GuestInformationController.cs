using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelEntity.Entites;

namespace HotelEntityWebMVCApp.Controllers
{
    public class GuestInformationController : Controller
    {
        private Context db = new Context();

        // GET: GuestInformation
        public ActionResult Index()
        {
            
            var guestInformation = db.GuestInformation.Include(g => g.BookingInformation);
            return View(guestInformation.ToList());
        }

        // GET: GuestInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestInformation guestInformation = db.GuestInformation.Find(id);
            if (guestInformation == null)
            {
                return HttpNotFound();
            }
            return View(guestInformation);
        }

        // GET: GuestInformation/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId");
            return View();
        }

        // POST: GuestInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestName,GuestSurName,GuestPhone,GuestIdentNumber,GuestGender,GuestEmail,GuestIdentType,GuestCountry,GuestCity,GuestDistrict,GuestAddress,GuestRezervationNote,BookingId")] GuestInformation guestInformation)
        {
            if (ModelState.IsValid)
            {
                guestInformation.GuestsequenceNo = 1;
                guestInformation.InsertDateTime = DateTime.Now;
                guestInformation.UpdateDateTime = DateTime.Now;

                db.GuestInformation.Add(guestInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "BookingId", guestInformation.BookingId);
            return View(guestInformation);
        }

        // GET: GuestInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestInformation guestInformation = db.GuestInformation.Find(id);
            if (guestInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "BookingId", guestInformation.BookingId);
            return View(guestInformation);
        }

        // POST: GuestInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestName, GuestSurName, GuestPhone, GuestIdentNumber, GuestGender, GuestEmail, GuestIdentType, GuestCountry, GuestCity, GuestDistrict, GuestAddress, GuestRezervationNote, BookingId")] GuestInformation guestInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "BookingId", guestInformation.BookingId);
            return View(guestInformation);
        }

        // GET: GuestInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestInformation guestInformation = db.GuestInformation.Find(id);
            if (guestInformation == null)
            {
                return HttpNotFound();
            }
            return View(guestInformation);
        }

        // POST: GuestInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestInformation guestInformation = db.GuestInformation.Find(id);
            db.GuestInformation.Remove(guestInformation);
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
