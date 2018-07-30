using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityWinFormApp
{
    public class HotelEntityProbs
    {
        public int RezervationID { get; set; }
        public DateTime Arrivaldate { get; set; }
        public DateTime DepartureDate { get; set; } 
        public int SumDays { get; set; }
        public int ChildTotal { get; set; }
        public int ChildeWithFeeTotal { get; set; }
        public int PersonQuantity { get; set; }
        public int AllPersonTotal { get; set; }

        public double DailyPersonPrice { get; set; }
        public double DailyGuestFee { get; set; }
        public double Extrasprice { get; set; }
        public double DiscountPrice { get; set; }
        public double ChildFee { get; set; }
        public double TotalPrice { get; set; }
        public double RoomPrice { get; set; }
        public double BreakfastPrice { get; set; }
        public double LunchPrice { get; set; }
        public double DinnerPrice { get; set; }

        public double ChildFeeTotal { get; set; }
        public double TotalAccommodationFee { get; set; }
        public double TotalRoomFee { get; set; }
        public double TotalBreakFastFee { get; set; }
        public double TotalLunchFee { get; set; }
        public double TotalDinnerFee { get; set; }
        public double Totaldayspersonfee { get; set; }

    }
}
