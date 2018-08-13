using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelEntity.Entites;

namespace HotelEntity.Entites
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public double? DailyPersonPrice { get; set; }
        public double? DailyGuestFee { get; set; }
        public double? Extrasprice { get; set; }
        public double? DiscountPrice { get; set; }
        public double? ChildFee { get; set; }
        public double TotalPrice { get; set; }
        public double? RoomPrice { get; set; }
        public double? BreakfastPrice { get; set; }
        public double? LunchPrice { get; set; }
        public double? DinnerPrice { get; set; }
        public double? ChildFeeTotal { get; set; }
        public double? TotalAccommodationFee { get; set; }
        public double? TotalRoomFee { get; set; }
        public double? TotalBreakFastFee { get; set; }
        public double? TotalLunchFee { get; set; }
        public double? TotalDinnerFee { get; set; }
        public double? Totaldayspersonfee { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public int BookingId { get; set; }
        public virtual BookingInformation BookingInformation { get; set; }

    }
}
