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
            var model = db.BookingInformation.Where(i=>i.Status!= "CheckOut")
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments).ToList();

            

            return View(model);

        }

        public ActionResult List()
        {
            var model = db.BookingInformation
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments).ToList();

            return View(model);
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var model = db.BookingInformation
                .Where(i=>i.BookingId==id)
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments).FirstOrDefault();

            if (id==null)
            {
                return new HttpNotFoundResult();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookingInformation booking, GuestInformation guest,Payments payment)
        {
            if (booking==null||guest==null||payment==null)
            {
                return new HttpNotFoundResult();
            }


            var updateBooking = db.BookingInformation.FirstOrDefault(i => i.BookingId == booking.BookingId);

            updateBooking.UpdateDateTime=DateTime.Now;
            updateBooking.Arrivaldate = booking.Arrivaldate;
            updateBooking.DepartureDate = booking.DepartureDate;
            updateBooking.Status = booking.Status;
            updateBooking.AccommodationType = booking.AccommodationType;
            updateBooking.AllPersonTotal = booking.AllPersonTotal;
            updateBooking.BoardType = booking.BoardType;
            updateBooking.Breakfast = booking.Breakfast;
            updateBooking.ChildTotal = booking.ChildTotal;
            updateBooking.ChildWithFeeTotal = booking.ChildWithFeeTotal;
            updateBooking.Dinner = booking.Dinner;
            updateBooking.Lunch = booking.Lunch;
            updateBooking.PersonQuantity = booking.PersonQuantity;
            updateBooking.RoomNo = booking.RoomNo;
            updateBooking.SumDays = booking.SumDays;


            var updateGuest = db.GuestInformation.FirstOrDefault(i => i.BookingId == guest.BookingId);

            updateGuest.UpdateDateTime=DateTime.Now;

            updateGuest.GuestAddress = guest.GuestAddress;
            updateGuest.GuestBirthDay = guest.GuestBirthDay;
            updateGuest.GuestCarPlate = guest.GuestCarPlate;
            updateGuest.GuestCity = guest.GuestCity;
            updateGuest.GuestCountry = guest.GuestCountry;
            updateGuest.GuestDistrict = guest.GuestDistrict;
            updateGuest.GuestEmail = guest.GuestEmail;
            updateGuest.GuestFatherName = guest.GuestFatherName;
            updateGuest.GuestGender = guest.GuestGender;
            updateGuest.GuestIdentNumber = guest.GuestIdentNumber;
            updateGuest.GuestIdentSerialNo = guest.GuestIdentSerialNo;
            updateGuest.GuestIdentType = guest.GuestIdentType;
            updateGuest.GuestMartialStatus = guest.GuestMartialStatus;
            updateGuest.GuestMotherName = guest.GuestMotherName;
            updateGuest.GuestName = guest.GuestName;
            updateGuest.GuestPhone = guest.GuestPhone;
            updateGuest.GuestRezervationNote = guest.GuestRezervationNote;
            updateGuest.GuestSurName = guest.GuestSurName;

            var updatePayment = db.Payments.FirstOrDefault(i => i.BookingId == payment.BookingId);

            updatePayment.UpdateDateTime=DateTime.Now;
            updatePayment.TotalPrice = payment.TotalPrice;
            updatePayment.BreakfastPrice = payment.BreakfastPrice;
            updatePayment.ChildFee = payment.ChildFee;
            updatePayment.ChildFeeTotal = payment.ChildFeeTotal;
            updatePayment.DailyGuestFee = payment.DailyGuestFee;
            updatePayment.DailyPersonPrice = payment.DailyPersonPrice;
            updatePayment.DinnerPrice = payment.DinnerPrice;
            updatePayment.DiscountPrice = payment.DiscountPrice;
            updatePayment.Extrasprice = payment.Extrasprice;
            updatePayment.LunchPrice = payment.LunchPrice;
            updatePayment.RoomPrice = payment.RoomPrice;
            updatePayment.TotalAccommodationFee = payment.TotalAccommodationFee;
            updatePayment.TotalBreakFastFee = payment.TotalBreakFastFee;
            updatePayment.TotalDinnerFee = payment.TotalDinnerFee;
            updatePayment.TotalLunchFee = payment.TotalLunchFee;
            updatePayment.TotalRoomFee = payment.TotalRoomFee;
            updatePayment.Totaldayspersonfee = payment.Totaldayspersonfee;

            db.SaveChanges();

            return Redirect("Index");
        }


    }
}

