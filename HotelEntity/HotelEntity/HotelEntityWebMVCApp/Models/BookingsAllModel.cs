using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class BookingsAllModel
    {
        //public IEnumerable<BookingInformation> BookingInformations { get; set; }
        //public IEnumerable<GuestInformation> GuestInformations { get; set; }
        //public IEnumerable<Payments> Payments { get; set; }

        public int RoomNo { get; set; }
        public string GuestName { get; set; }
        public double PaymentTotal { get; set; }


    }
}