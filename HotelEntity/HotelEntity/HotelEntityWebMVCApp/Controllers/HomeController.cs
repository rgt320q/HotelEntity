using HotelEntity.Entites;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Dynamic;
using System.Linq;
using System.Web.Mvc;
using HotelEntityWebMVCApp.Models;

namespace HotelEntityWebMVCApp.Controllers
{



    public class HomeController : Controller
    {
        Context _context = Context.ContextNew();

        // GET: Home
        public ActionResult Index()
        {
            //var model = _context.BookingInformation
            //    .Include(i => i.GuestInformation)
            //    .Include(i=>i.Payments)
            //    .Select(i=> new
            //    {
            //        i.BookingId,
            //        i.Arrivaldate,
            //        i.DepartureDate,
            //        i.RoomNo,
            //        i.AllPersonTotal,
            //        i.GuestInformation,
            //        i.Payments
            //    });

            //var model = _context.BookingInformation.Include(i => i.GuestInformation).Include(i => i.Payments).ToList();

            return View(_context.BookingInformation.ToList());

        }
    }
}

//var model = new BookingsAllModel();

//model.BookingInformations = _context.BookingInformation.ToList();
//model.GuestInformations = _context.GuestInformation.ToList();
//model.Payments = _context.Payments.ToList();



//var BookingVarid = 3;

//var BookingsAll = _context.BookingInformation.Single(b => b.BookingId == BookingVarid);

//_context.Entry(BookingsAll).Collection(g => g.GuestInformation).Load();
//_context.Entry(BookingsAll).Collection(p => p.Payments).Load();


//Payments payments = new Payments();
//BookingInformation bookinginfo = new BookingInformation();
//GuestInformation guestsinfo = new GuestInformation();




//model.ModelBookings = _context.BookingInformation.ToList();
//model.ModelPayments = _context.Payments.ToList();

//model.GuestName = guestsinfo.GuestName;
//model.GuestSurName = guestsinfo.GuestSurName;
//model.GuestPhone = guestsinfo.GuestPhone;
//model.GuestEmail = guestsinfo.GuestEmail;
//model.GuestIdentNumber = guestsinfo.GuestIdentNumber;
//model.GuestRezervationNote = guestsinfo.GuestRezervationNote;
//model.GuestsequenceNo = guestsinfo.GuestsequenceNo;
//model.GuestBirthDay = guestsinfo.GuestBirthDay;
//model.InsertDateTime = guestsinfo.InsertDateTime;
//model.UpdateDateTime = guestsinfo.UpdateDateTime;

//ViewBag.guests = guestsinfo.GuestName;
//ViewBag.guestsurename = guestsinfo.GuestSurName;
//ViewBag.Paymens = _context.Payments;