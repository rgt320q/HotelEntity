using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class BookingInformationModel
    {
        public int BookingId { get; set; }
        public DateTime Arrivaldate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string RoomNo { get; set; }
        public int SumDays { get; set; }
        //public int ChildTotal { get; set; }
        //public int ChildWithFeeTotal { get; set; }
        //public int PersonQuantity { get; set; }
        public int AllPersonTotal { get; set; }
        //public string AccommodationType { get; set; }
        //public string BoardType { get; set; }
        //public string Breakfast { get; set; }
        //public string Lunch { get; set; }
        //public string Dinner { get; set; }

        public IEnumerable<GuestInformationModel> GuestInformation { get; set; }
        public IEnumerable<PaymentsModel> Payments { get; set; }


    }
}