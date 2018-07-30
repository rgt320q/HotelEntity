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
    public class PaymentController : Controller
    {
        private Context db = new Context();

        // GET: Payment
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.BookingInformation);
            return View(payments.ToList());
        }

        // GET: Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        // GET: Payment/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "RoomNo");
            return View();
        }

        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentId,DailyPersonPrice,DailyGuestFee,Extrasprice,DiscountPrice,ChildFee,TotalPrice,RoomPrice,BreakfastPrice,LunchPrice,DinnerPrice,ChildFeeTotal,TotalAccommodationFee,TotalRoomFee,TotalBreakFastFee,TotalLunchFee,TotalDinnerFee,Totaldayspersonfee,InsertDateTime,UpdateDateTime,BookingId")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "RoomNo", payments.BookingId);
            return View(payments);
        }

        // GET: Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "RoomNo", payments.BookingId);
            return View(payments);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,DailyPersonPrice,DailyGuestFee,Extrasprice,DiscountPrice,ChildFee,TotalPrice,RoomPrice,BreakfastPrice,LunchPrice,DinnerPrice,ChildFeeTotal,TotalAccommodationFee,TotalRoomFee,TotalBreakFastFee,TotalLunchFee,TotalDinnerFee,Totaldayspersonfee,InsertDateTime,UpdateDateTime,BookingId")] Payments payments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.BookingInformation, "BookingId", "RoomNo", payments.BookingId);
            return View(payments);
        }

        // GET: Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payments payments = db.Payments.Find(id);
            if (payments == null)
            {
                return HttpNotFound();
            }
            return View(payments);
        }

        // POST: Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payments payments = db.Payments.Find(id);
            db.Payments.Remove(payments);
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
