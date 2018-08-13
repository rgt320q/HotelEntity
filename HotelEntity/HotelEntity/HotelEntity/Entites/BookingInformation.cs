using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Entites
{
    public class BookingInformation

    {
        //public BookingInformation()
        //{
        //    GuestInformation = new List<GuestInformation>();
        //    Payments = new List<Payments>();
        //}

        [Key]
        public int BookingId { get; set; }
        public DateTime Arrivaldate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string RoomNo { get; set; }
        public string Status { get; set; }
        public int? SumDays { get; set; }
        public int? ChildTotal { get; set; }
        public int? ChildWithFeeTotal { get; set; }
        public int? PersonQuantity { get; set; }
        public int? AllPersonTotal { get; set; }
        public string AccommodationType { get; set; }
        public string BoardType { get; set; }
        public string Breakfast { get; set; }
        public string Lunch { get; set; }
        public string Dinner { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<GuestInformation> GuestInformation { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
       
    }
}
