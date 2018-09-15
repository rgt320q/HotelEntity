using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class BookingsAllModel
    {
        public BookingInformation BookingInformation { get; set; }
        public GuestInformation GuestInformation { get; set; }
        public Payments Payments { get; set; }
        
    }
}