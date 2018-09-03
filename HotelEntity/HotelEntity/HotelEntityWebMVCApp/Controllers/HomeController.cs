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
        Context db = Context.ContextNew();

        // GET: Home
        public ActionResult Index()
        {
            var model = db.BookingInformation
                .Include(i => i.GuestInformation)
                .Include(i => i.Payments);
            
            return View(model);

        }
    }
}

