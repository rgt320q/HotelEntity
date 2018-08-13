using HotelEntity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEntityWebMVCApp.Models
{
    public class ModelFactory
    {
        public BookingInformationModel Create(BookingInformation BookingInformation)
        {
            return new BookingInformationModel()
            {
                BookingId = BookingInformation.BookingId,
                Arrivaldate = BookingInformation.Arrivaldate,
                DepartureDate = BookingInformation.DepartureDate,
                RoomNo = BookingInformation.RoomNo,
                //SumDays = BookingInformation.SumDays,
                //AllPersonTotal = BookingInformation.AllPersonTotal,   
                GuestInformation=BookingInformation.GuestInformation.Select(g => Create(g)),
                Payments=BookingInformation.Payments.Select(p => Create(p))
            };
        }

        public GuestInformationModel Create(GuestInformation guestInformation)
        {
            return new GuestInformationModel()
            {
                GuestId=guestInformation.GuestId,
                GuestName=guestInformation.GuestName,
                GuestSurName=guestInformation.GuestSurName,
                GuestPhone=guestInformation.GuestPhone,
                //GuestsequenceNo=guestInformation.GuestsequenceNo
            };
        }

        public PaymentsModel Create(Payments payments)
        {
            return new PaymentsModel()
            {
                PaymentId=payments.PaymentId,
                //DailyGuestFee=payments.DailyGuestFee,
                //Extrasprice=payments.Extrasprice,
                //DiscountPrice=payments.DiscountPrice,
                //TotalPrice=payments.TotalPrice
            };
        }
    }
}