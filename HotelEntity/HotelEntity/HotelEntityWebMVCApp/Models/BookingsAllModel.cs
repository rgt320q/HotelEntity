using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class BookingsAllModel
    {
        public ICollection<BookingInformation> BookingInformations { get; set; }
        public ICollection<GuestInformation> GuestInformations { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}