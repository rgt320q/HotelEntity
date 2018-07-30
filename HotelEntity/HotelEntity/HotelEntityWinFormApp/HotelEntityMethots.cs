using HotelEntity;
using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityWinFormApp.HotelEntityProbsFolder
{
    public class HotelEntityMethots
    {
        Form1 form1 = new Form1();
        Context db = new Context();
        BookingInformation booking = new BookingInformation();
        GuestInformation guest = new GuestInformation();
        Payments payment = new Payments();

        //public void RenewGridviews()
        //{
        //    form1.dgwBooking.DataSource = db.BookingInformation.ToList();
        //    form1.dgwGuest.DataSource = db.GuestInformation.ToList();
        //    form1.dgwPayment.DataSource = db.Payments.ToList();
        //}

    }
}
