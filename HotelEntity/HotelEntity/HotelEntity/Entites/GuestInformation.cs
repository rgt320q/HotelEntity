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
    public class GuestInformation
    {
        [Key]
        public int GuestId { get; set; }
        [Required]       
        public string GuestName { get; set; }
        [Required]
        public string GuestSurName { get; set; }        
        public string GuestPhone { get; set; }
        [MaxLength(11)]
        public string GuestIdentNumber { get; set; }
        public string GuestCity { get; set; }
        public string GuestGender { get; set; }
        public string GuestEmail { get; set; }
        public DateTime GuestBirthDay { get; set; }
        public string GuestAddress { get; set; }
        public string GuestFatherName { get; set; }
        public string GuestMotherName { get; set; }
        public string GuestMartialStatus { get; set; }
        public string GuestIdentType { get; set; }
        public string GuestIdentSerialNo { get; set; }
        public string GuestCountry { get; set; }
        public string GuestDistrict { get; set; }
        public string GuestCarPlate { get; set; }
        public string GuestRezervationNote { get; set; }
        public int GuestsequenceNo { get; set; }
        public DateTime InsertDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }

        public int BookingId { get; set; }
        public virtual BookingInformation BookingInformation { get; set; }

        //public override string ToString()
        //{
        //    return GuestName;
        //}
    }
}
