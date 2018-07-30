using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelEntity;
using HotelEntity.Entites;
using HotelEntityWebMVCApp.Models;

namespace HotelEntityWebMVCApp.Controllers
{
    public class BookingInformationController : Controller
    {
        private Context db = new Context();
        //BookingInformationModel BookingInformationmodel = new BookingInformationModel();

        //GET: BookingInformation
        public ActionResult Index()
        {
            //var model = db.BookingInformation
            //       .Include(i => i.GuestInformation)
            //       .Include(i => i.Payments)
            //       .Select(i => new
            //       {
            //           i.BookingId,
            //           i.Arrivaldate,
            //           i.DepartureDate,
            //           i.RoomNo,
            //           i.AllPersonTotal,
            //           i.GuestInformation,
            //           i.Payments
            //       });

            return View(db.BookingInformation.ToList());
        }


        // GET: BookingInformation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInformation bookingInformation = db.BookingInformation.Find(id);
            if (bookingInformation == null)
            {
                return HttpNotFound();
            }
            return View(bookingInformation);
        }

        // GET: BookingInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,Arrivaldate,DepartureDate,RoomNo,Status,SumDays,ChildTotal,ChildWithFeeTotal,PersonQuantity,AllPersonTotal,AccommodationType,BoardType,Breakfast,Lunch,Dinner,InsertDateTime,UpdateDateTime")] BookingInformation bookingInformation)
        {
            if (ModelState.IsValid)
            {
                db.BookingInformation.Add(bookingInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingInformation);
        }

        // GET: BookingInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInformation bookingInformation = db.BookingInformation.Find(id);
            if (bookingInformation == null)
            {
                return HttpNotFound();
            }
            return View(bookingInformation);
        }

        // POST: BookingInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,Arrivaldate,DepartureDate,RoomNo,Status,SumDays,ChildTotal,ChildWithFeeTotal,PersonQuantity,AllPersonTotal,AccommodationType,BoardType,Breakfast,Lunch,Dinner,InsertDateTime,UpdateDateTime")] BookingInformation bookingInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingInformation);
        }

        // GET: BookingInformation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInformation bookingInformation = db.BookingInformation.Find(id);
            if (bookingInformation == null)
            {
                return HttpNotFound();
            }
            return View(bookingInformation);
        }

        // POST: BookingInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingInformation bookingInformation = db.BookingInformation.Find(id);
            db.BookingInformation.Remove(bookingInformation);
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
