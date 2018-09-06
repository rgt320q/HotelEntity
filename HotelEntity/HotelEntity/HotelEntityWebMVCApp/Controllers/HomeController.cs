using HotelEntity.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Linq;
using System.Web.Mvc;
using HotelEntityWebMVCApp.Models;
using System;

namespace HotelEntityWebMVCApp.Controllers
{



    public class HomeController : Controller
    {
        Context db = Context.ContextNew();

        // GET: Home
        public ActionResult Index()
        {
            var model = db.BookingInformation
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments);           

            return View(model);

        }

        public ActionResult List()
        {
            var model = db.BookingInformation
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments);

            return View(model.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingsAllModel bookingsAll)
        {
            if (ModelState.IsValid)

            {
                bookingsAll.BookingInformation.InsertDateTime = DateTime.Now;
                bookingsAll.GuestInformation.InsertDateTime = DateTime.Now;                
                bookingsAll.Payments.InsertDateTime = DateTime.Now;

                bookingsAll.GuestInformation.GuestsequenceNo = 1;


                db.BookingInformation.Add(bookingsAll.BookingInformation);
                db.GuestInformation.Add(bookingsAll.GuestInformation);
                db.Payments.Add(bookingsAll.Payments);

                db.SaveChanges();
            }

            return Redirect("Index");
        }
    }
}

