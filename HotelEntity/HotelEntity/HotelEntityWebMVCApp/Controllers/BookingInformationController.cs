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
            var model = db.BookingInformation
                  .Include(i => i.GuestInformation)
                  .Include(i => i.Payments).ToList();           

            return View(model);
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
            var model = Tuple.Create<BookingInformation, GuestInformation, Payments>(new BookingInformation(), new GuestInformation(), new Payments());
            return View(model);
        }

        // POST: BookingInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Prefix ="Item1")]BookingInformation Model1, [Bind(Prefix ="Item2")]GuestInformation Model2, [Bind(Prefix ="Item3")]Payments Model3)
        {
            if (ModelState.IsValid)
            {
                Model1.Arrivaldate = DateTime.Now;
                Model1.DepartureDate = DateTime.Now.AddDays(1);
                Model1.SumDays = 1;
                Model1.InsertDateTime = DateTime.Now;
                Model1.UpdateDateTime = DateTime.Now;
                Model2.InsertDateTime = DateTime.Now;
                Model2.UpdateDateTime = DateTime.Now;
                Model3.InsertDateTime = DateTime.Now;
                Model3.InsertDateTime = DateTime.Now;

                db.BookingInformation.Add(Model1);
                db.GuestInformation.Add(Model2);
                db.Payments.Add(Model3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        // GET: BookingInformation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.BookingInformation
                  .Include(i => i.GuestInformation)
                  .Include(i => i.Payments).FirstOrDefault(i=>i.BookingId==id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: BookingInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingInformation bookingInformation)
        {
            if (ModelState.IsValid)
            {
               var bookingupdate= db.BookingInformation
                    .Include(i=>i.GuestInformation)
                    .Include(i=>i.Payments).Where(i=>i.BookingId==bookingInformation.BookingId)
                    .FirstOrDefault();

                bookingupdate.Arrivaldate = bookingInformation.Arrivaldate;
                bookingupdate.DepartureDate = bookingInformation.DepartureDate;
                bookingupdate.RoomNo = bookingInformation.RoomNo;
                bookingupdate.Status = bookingInformation.Status;
                bookingupdate.SumDays = bookingInformation.SumDays;
                bookingupdate.ChildTotal = bookingInformation.ChildTotal;



                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View("edit");
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
