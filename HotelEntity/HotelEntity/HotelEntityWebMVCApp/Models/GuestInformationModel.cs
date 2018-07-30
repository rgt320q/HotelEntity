using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class GuestInformationModel
    {
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestSurName { get; set; }
        public string GuestPhone { get; set; }
        //public string GuestIdentNumber { get; set; }        
        //public string GuestGender { get; set; }
        //public string GuestEmail { get; set; }       
        //public string GuestAddress { get; set; }
        //public string GuestRezervationNote { get; set; }
        public int GuestsequenceNo { get; set; }
    }
}