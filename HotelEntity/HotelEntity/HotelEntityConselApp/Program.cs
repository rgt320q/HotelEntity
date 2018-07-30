using HotelEntity.Entites;
using HotelEntityWebMVCApp.Models;
using System;
using System.Linq;

namespace HotelEntityConselApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Context _context = new Context();
            DateTime tarih = DateTime.Now;
            BookingInformationModel bkinf = new BookingInformationModel();

            BookingInformation bookinginf = new BookingInformation();

            bookinginf.Arrivaldate = tarih;
            bookinginf.DepartureDate = tarih.AddDays(+1);
            bookinginf.InsertDateTime = tarih;
            bookinginf.UpdateDateTime = tarih;
            bookinginf.AllPersonTotal = 10;

            GuestInformation guestinf = new GuestInformation();
            guestinf.GuestName = "Barak";
            guestinf.GuestSurName = "Obama";
            guestinf.GuestPhone = "5312232322";
            guestinf.InsertDateTime = tarih;
            guestinf.UpdateDateTime = tarih;
            guestinf.GuestBirthDay = tarih;

            Payments pay = new Payments();
            pay.InsertDateTime = tarih;
            pay.UpdateDateTime = tarih;
            pay.DailyGuestFee = 44.58;
            pay.TotalPrice = 60.88;
                      
            _context.BookingInformation.Add(bookinginf);
            _context.GuestInformation.Add(guestinf);
            _context.Payments.Add(pay);

            _context.SaveChanges();

            Console.WriteLine("***************");
            Console.WriteLine("Kayıt Girildi!");
            Console.WriteLine("***************");

            //var bknfgd = _context.BookingInformation.Include(g => g.GuestInformation).Include(p => p.Payments);

            //foreach (var item in bknfgd)
            //{

            //    foreach (var item2 in item.GuestInformation)
            //    {
            //        item2.GuestName;
            //    }
            //}




            //var bookings = _context.BookingInformation
            //    .Include(i => i.GuestInformation)
            //    .Include(i => i.Payments)
            //    .Select(i => new
            //     {
            //         i.BookingId,
            //         i.Arrivaldate,
            //         i.DepartureDate,
            //         i.RoomNo,
            //         i.AllPersonTotal,
            //         i.GuestInformation,
            //         i.Payments
            //     });



            var BookingsAll = (from Booking in _context.BookingInformation
                               join Guest in _context.GuestInformation
                               on Booking.BookingId equals Guest.BookingId
                               join Payment in _context.Payments
                               on Booking.BookingId equals Payment.BookingId
                               select new
                               {
                                   ID = Booking.BookingId,
                                   ArrivalDates = Booking.Arrivaldate,
                                   DepartureDates = Booking.DepartureDate,
                                   BookingInsertDate = Booking.InsertDateTime,
                                   BookingUpdateDate = Booking.UpdateDateTime,
                                   GuestTotal = Booking.AllPersonTotal,

                                   GuestNames = Guest.GuestName,
                                   GuestSurNames = Guest.GuestSurName,
                                   GuestInsertDate = Guest.InsertDateTime,
                                   GuestUpdateDate = Guest.UpdateDateTime,

                                   DailyGuestFees = Payment.DailyGuestFee,
                                   TotalFee = Payment.TotalPrice

                               }).ToList();

            foreach (var BookingsAllItem in BookingsAll)
            {
                Console.WriteLine("Misafir Numarası={0} Misafir Adı={1} Tutar={2}", BookingsAllItem.ID, BookingsAllItem.GuestNames, BookingsAllItem.TotalFee);
            }



            //var guests = con.GuestInformation.ToList();

            //foreach (var guest in guests)
            //{
            //    Console.WriteLine("Misafir No={0} | Misafir Adı={1} | Misafir Soyadı={2}",guest.Id,guest.GuestName,guest.GuestSureName);
            //}

            //Console.WriteLine("   ");
            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("   ");


            //var guest1 = con.GuestInformation.Find(4);

            //Console.WriteLine("Misaifir No:{0} | Misafir Adı:{1}",guest1.Id,guest1.GuestName);

            //if (guest1!=null)
            //{
            //    con.GuestInformation.Remove(guest1);
            //}

            //con.SaveChanges();

            //Console.WriteLine("   ");
            //Console.WriteLine("Misafir Bilgisi Silindi!");
            //Console.WriteLine("   ");


            //foreach (var guest in con.GuestInformation)
            //{
            //    Console.WriteLine("Misafir No={0} | Misafir Adı={1} | Misafir Soyadı={2}", guest.Id, guest.GuestName, guest.GuestSureName);
            //}



            //var guest = con.GuestInformation.Find();



            //var pay = con.Payments.ToList();

            //foreach (var payment in pay)
            //{

            //    Console.WriteLine("Fiyat No: {0} Günlük Fiyat:{1}", payment.Id, payment.DailyPersonPrice);

            //}

            //Console.WriteLine("-----------------------------------");


            //foreach (var payment in pay)
            //{
            //    payment.DailyPersonPrice *= 1.25;
            //    Console.WriteLine("Fiyat No: {0} Günlük Fiyat:{1}",payment.Id,payment.DailyPersonPrice);
            //}
            //con.SaveChanges();

            //var payment = con.Payments.Find(2);

            //Console.WriteLine("Ödeme No: {2} Günlük Kişi Başı:{0} Toplam:{1}", payment.DailyPersonPrice, payment.TotalPrice, payment.Id);

            //payment.DailyPersonPrice /= 2;
            //payment.TotalPrice= payment.TotalPrice+(payment.TotalPrice * 1.5);



            //Console.WriteLine("Ödeme No: {2} Günlük Kişi Başı:{0} Toplam:{1}", payment.DailyPersonPrice, payment.TotalPrice, payment.Id);

            //con.SaveChanges();


            //var guest1 = con.GuestInformation.Find(2);

            //Console.WriteLine("Misafir No:{0} Misafir Adı:{1} Misafir Soyadı:{2}",guest1.Id,guest1.GuestName,guest1.GuestSureName);

            //guest1.GuestName = "Şerafettin";
            //guest1.GuestSureName = "Şahin";

            //Console.WriteLine("Misafir No:{0} Misafir Adı:{1} Misafir Soyadı:{2}", guest1.Id, guest1.GuestName, guest1.GuestSureName);

            //con.SaveChanges();



            //var guests = con.GuestInformation.ToList();

            //foreach (var guest in guests)
            //{
            //    Console.WriteLine("Guest Id:{0} Guest Name:{1}", guest.Id, guest.GuestName );
            //}

            //var bookings = con.BookingInformation.ToList();

            //foreach (var booking in bookings)
            //{
            //    Console.WriteLine("Booking Id:{0}",booking.Id);
            //}

            //var payments = con.Payments.ToList();

            //foreach (var payment in payments)
            //{
            //    Console.WriteLine("Payment Id:{0}",payment.Id);
            //}

            //DateTime tarih = DateTime.Now;

            //List<BookingInformation> bookings = new List<BookingInformation>()
            //{
            //    new BookingInformation() {PersonQuantity=1,SumDays=1,AllPersonTotal=1,Arrivaldate=tarih,DepartureDate=tarih,InsertDateTime=tarih,UpdateDateTime=tarih},
            //    //new BookingInformation() {PersonQuantity=1,SumDays=1,AllPersonTotal=1},
            //    //new BookingInformation() {PersonQuantity=3,SumDays=1,AllPersonTotal=3},
            //    //new BookingInformation() {PersonQuantity=4,SumDays=1,AllPersonTotal=4}
            //};

            //foreach (var bookingslist in bookings)
            //{
            //    context.BookingInformation.Add(bookingslist);
            //}

            //List<Payments> payment = new List<Payments>()
            //{
            //    new Payments() {DailyPersonPrice=0, TotalPrice=0,InsertDateTime=tarih,UpdateDateTime=tarih},
            //    //new Payments() {DailyPersonPrice=200.0000,TotalPrice=200.0000},
            //    //new Payments() {DailyPersonPrice=300.0000,TotalPrice=300.0000},
            //    //new Payments() {DailyPersonPrice=150.0000,TotalPrice=150.0000}
            //};

            //foreach (var paymentslist in payment)
            //{
            //    context.Payments.Add(paymentslist);
            //}

            //List<GuestInformation> guests = new List<GuestInformation>()
            //{
            //    new GuestInformation() {GuestName="Mehmet",GuestSureName="Ak",InsertDateTime=tarih,UpdateDateTime=tarih,GuestBirthDay=tarih},
            //    //new GuestInformation() {GuestName="Mehmet",GuestSureName="Ay"},
            //    //new GuestInformation() {GuestName="Ayşe",GuestSureName="YOK"},
            //    //new GuestInformation() {GuestName="Nebile",GuestSureName="Yim"}
            //};

            //foreach (var guestslist in guests)
            //{
            //    context.GuestInformation.Add(guestslist);
            //}

            //context.SaveChanges();

            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine("Ekleme Yapıldı!");
            //Console.WriteLine("-----------------------------------");            


            //var guestss = context.GuestInformation.ToList();

            //foreach (var guest in guestss)
            //{
            //    Console.WriteLine("Guest Id:{0} Guest Name:{1}", guest.GuestId, guest.GuestName);
            //}

            //var bookingss = context.BookingInformation.ToList();

            //foreach (var booking in bookingss)
            //{
            //    Console.WriteLine("Booking Id:{0}", booking.BookingId);
            //}

            //var payments = context.Payments.ToList();

            //foreach (var paymentt in payments)
            //{
            //    Console.WriteLine("Payment Id:{0}", paymentt.PaymentId);
            //}

            Console.ReadLine();
        }
    }
}
