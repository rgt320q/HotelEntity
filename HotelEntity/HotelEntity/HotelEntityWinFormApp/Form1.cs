using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelEntity.Entites;
using HotelEntity;
using HotelEntityWinFormApp.HotelEntityProbsFolder;

namespace HotelEntityWinFormApp
{
    public partial class Form1 : Form
    {
        Context db = Context.ContextNew();
        BookingInformation booking = new BookingInformation();
        GuestInformation guest = new GuestInformation();
        Payments payment = new Payments();

        //HotelEntityMethots Methots = new HotelEntityMethots();
        HotelEntityProbs hotelEntityProbs = new HotelEntityProbs();

        public Form1()
        {


            InitializeComponent();
            //RenewGridviews();
            //Bookingpayment();
            //PersonSumTotal();
            //cbIdentType.SelectedIndex = 0;
            //cbAccommodationType.SelectedIndex = 0;
            //cbBoardType.SelectedIndex = 0;
        }

        public void RenewGridviews()
        {
            var bookingall = from b in db.BookingInformation
                             join g in db.GuestInformation                             
                             on b.BookingId equals g.BookingId
                             join p in db.Payments
                             on b.BookingId equals p.BookingId
                             select new
                             {
                                 b.BookingId,
                                 b.Arrivaldate,
                                 b.DepartureDate,
                                 g.GuestName,
                                 g.GuestSurName,
                                 g.GuestPhone,
                                 g.GuestEmail,
                                 b.RoomNo,
                                 b.Status,
                                 b.SumDays,
                                 p.DailyPersonPrice,
                                 p.Extrasprice,
                                 p.DiscountPrice,
                                 p.TotalPrice
                             };

            dgwBooking.DataSource = bookingall.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDepartureDate.Value = DateTime.Today.AddDays(+1);
            RenewGridviews();
            Bookingpayment();
            PersonSumTotal();
            cbIdentType.SelectedIndex = 0;
            cbAccommodationType.SelectedIndex = 0;
            cbBoardType.SelectedIndex = 0;
        }

        //
        //Gün Sayısı Toplama
        //
        public void DayTotal()
        {
            //TimeSpan totaldays = dtpDepartureDate.Value.Subtract(dtpArrivalDate.Value);
            //tbSumDay.Text = totaldays.Days.ToString();
            //hotelEntityProbs.SumDays = Convert.ToInt16(totaldays.Days);

            hotelEntityProbs.Arrivaldate = Convert.ToDateTime(dtpArrivalDate.Text);
            hotelEntityProbs.DepartureDate = Convert.ToDateTime(dtpDepartureDate.Text);
            TimeSpan totaldays;
            totaldays = hotelEntityProbs.DepartureDate - hotelEntityProbs.Arrivaldate;
            hotelEntityProbs.SumDays = totaldays.Days;
            tbSumDay.Text = totaldays.Days.ToString();
        }

        //
        //Kişi Sayısı Hesaplama
        //
        public void PersonSumTotal()
        {
            hotelEntityProbs.ChildTotal = Convert.ToInt16(nudChildQuantity.Value);
            hotelEntityProbs.ChildeWithFeeTotal = Convert.ToInt16(nudChildFeeQuantity.Value);
            hotelEntityProbs.AllPersonTotal = Convert.ToInt16(nudPersonQuantity.Value) + hotelEntityProbs.ChildTotal + hotelEntityProbs.ChildeWithFeeTotal;
            tbTotalGuestSum.Text = hotelEntityProbs.AllPersonTotal.ToString();
        }

        private void cbBoardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoardType.SelectedIndex == 0)
            {
                cbBreakfast.SelectedIndex = 0;
                cbLunch.SelectedIndex = 1;
                cbDinner.SelectedIndex = 0;

                cbBreakfast.Enabled = false;
                cbLunch.Enabled = false;
                cbDinner.Enabled = false;

                Bookingpayment();
            }
            else if (cbBoardType.SelectedIndex == 1)
            {
                cbBreakfast.SelectedIndex = 0;
                cbLunch.SelectedIndex = 0;
                cbDinner.SelectedIndex = 0;

                cbBreakfast.Enabled = false;
                cbLunch.Enabled = false;
                cbDinner.Enabled = false;

                Bookingpayment();
            }
            else if (cbBoardType.SelectedIndex == 2)
            {
                cbBreakfast.SelectedIndex = 0;
                cbLunch.SelectedIndex = 1;
                cbDinner.SelectedIndex = 1;

                cbBreakfast.Enabled = false;
                cbLunch.Enabled = false;
                cbDinner.Enabled = false;

                Bookingpayment();
            }
            else if (cbBoardType.SelectedIndex == 3)
            {
                cbBreakfast.SelectedIndex = 1;
                cbLunch.SelectedIndex = 1;
                cbDinner.SelectedIndex = 1;

                cbBreakfast.Enabled = true;
                cbLunch.Enabled = true;
                cbDinner.Enabled = true;

                Bookingpayment();
            }
        }

        private void cbAccommodationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccommodationType.SelectedIndex == 0)
            {
                cbBoardType.Visible = false;
                cbBreakfast.Visible = false;
                cbLunch.Visible = false;
                cbDinner.Visible = false;
                lBoardType.Visible = false;
                lBreakfast.Visible = false;
                lLunch.Visible = false;
                lDinner.Visible = false;

                lRoomFee.Visible = false;
                tbRoomFee.Visible = false;

                lChildeFee.Visible = true;
                tbChildeFee.Visible = true;

                lChildeFeeTotal.Visible = true;
                tbChildeFeeTotal.Visible = true;

                lBreakfastPrice.Visible = false;
                tbBreakfastPrice.Visible = false;

                lLunchPrice.Visible = false;
                tbLunchPrice.Visible = false;

                lDinnerPrice.Visible = false;
                tbDinnerPrice.Visible = false;


                lUcretliCocukSayisi.Visible = true;
                nudChildFeeQuantity.Visible = true;

                nudChildFeeQuantity.Value = 0;
                nudChildQuantity.Value = 0;
                tbRoomNo.Text = "";
                nudPersonQuantity.Enabled = true;
                nudPersonQuantity.Value = 1;
            }
            else if (cbAccommodationType.SelectedIndex == 1)
            {
                cbBoardType.Visible = true;
                cbBreakfast.Visible = true;
                cbLunch.Visible = true;
                cbDinner.Visible = true;
                lBoardType.Visible = true;
                lBreakfast.Visible = true;
                lLunch.Visible = true;
                lDinner.Visible = true;

                lRoomFee.Visible = true;
                tbRoomFee.Visible = true;

                lChildeFee.Visible = false;
                tbChildeFee.Visible = false;

                lChildeFeeTotal.Visible = false;
                tbChildeFeeTotal.Visible = false;

                lBreakfastPrice.Visible = true;
                tbBreakfastPrice.Visible = true;

                lLunchPrice.Visible = true;
                tbLunchPrice.Visible = true;

                lDinnerPrice.Visible = true;
                tbDinnerPrice.Visible = true;

                lUcretliCocukSayisi.Visible = false;
                nudChildFeeQuantity.Visible = false;

                nudPersonQuantity.Enabled = false;

                cbBoardType.SelectedIndex = 3;
                nudChildFeeQuantity.Value = 0;
                nudChildQuantity.Value = 0;
                tbRoomNo.Text = "";
            }
            Bookingpayment();
        }

        private void cbBreakfast_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBreakfast.SelectedIndex == 0)
            {
                hotelEntityProbs.BreakfastPrice = 30;
            }
            else
            {
                hotelEntityProbs.BreakfastPrice = 0;
            }

            Bookingpayment();
        }

        private void cbLunch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLunch.SelectedIndex == 0)
            {
                hotelEntityProbs.LunchPrice = 40;
            }
            else
            {
                hotelEntityProbs.LunchPrice = 0;
            }

            Bookingpayment();
        }

        private void cbDinner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDinner.SelectedIndex == 0)
            {
                hotelEntityProbs.DinnerPrice = 40;
            }
            else
            {
                hotelEntityProbs.DinnerPrice = 0;
            }

            Bookingpayment();
        }

        //
        //Konaklama Ücreti Hesaplama
        //
        public void Bookingpayment()
        {
            if (cbAccommodationType.SelectedIndex == 0)
            {
                hotelEntityProbs.RoomPrice = 0;
                hotelEntityProbs.DailyPersonPrice = 180;
                hotelEntityProbs.DailyGuestFee = 0;
                hotelEntityProbs.DinnerPrice = 0;
                hotelEntityProbs.BreakfastPrice = 0;
                hotelEntityProbs.LunchPrice = 0;
                hotelEntityProbs.ChildFee = 0;

                if (nudChildFeeQuantity.Value >= 1)
                {
                    hotelEntityProbs.ChildFee = hotelEntityProbs.DailyPersonPrice / 2;
                }

                else
                {
                    hotelEntityProbs.ChildFee = 0;
                }


                hotelEntityProbs.PersonQuantity = Convert.ToInt16(nudPersonQuantity.Value);
                hotelEntityProbs.Extrasprice = Convert.ToDouble(tbExtrasPrice.Text);
                hotelEntityProbs.DiscountPrice = Convert.ToDouble(tbDiscountPrice.Text);

                hotelEntityProbs.ChildFeeTotal = hotelEntityProbs.ChildFee * hotelEntityProbs.SumDays * Convert.ToInt16(nudChildFeeQuantity.Value);

                hotelEntityProbs.Totaldayspersonfee = hotelEntityProbs.SumDays * hotelEntityProbs.PersonQuantity * hotelEntityProbs.DailyPersonPrice;

                hotelEntityProbs.TotalPrice = (hotelEntityProbs.Totaldayspersonfee + hotelEntityProbs.ChildFeeTotal + hotelEntityProbs.Extrasprice) - hotelEntityProbs.DiscountPrice;

                tbpTotalPrice.Text = hotelEntityProbs.TotalPrice.ToString("C2");
                tbBreakfastPrice.Text = hotelEntityProbs.BreakfastPrice.ToString("C2");
                tbLunchPrice.Text = hotelEntityProbs.LunchPrice.ToString("C2");
                tbDinnerPrice.Text = hotelEntityProbs.DinnerPrice.ToString("C2");
                tbDailyGuestFee.Text = hotelEntityProbs.DailyPersonPrice.ToString("C2");
                tbChildeFee.Text = hotelEntityProbs.ChildFee.ToString("C2");
                tbChildeFeeTotal.Text = hotelEntityProbs.ChildFeeTotal.ToString("C2");
                tbPersonFee.Text = hotelEntityProbs.Totaldayspersonfee.ToString("C2");
                tbRoomFee.Text = hotelEntityProbs.RoomPrice.ToString("C2");
                tbExtrasPrice.Text = hotelEntityProbs.Extrasprice.ToString();
                tbDiscountPrice.Text = hotelEntityProbs.DiscountPrice.ToString();
            }

            else if (cbAccommodationType.SelectedIndex == 1)

            {
                hotelEntityProbs.DailyPersonPrice = 0;
                hotelEntityProbs.DailyGuestFee = 60;

                hotelEntityProbs.PersonQuantity = Convert.ToInt16(nudPersonQuantity.Value);
                hotelEntityProbs.Extrasprice = Convert.ToDouble(tbExtrasPrice.Text);
                hotelEntityProbs.DiscountPrice = Convert.ToDouble(tbDiscountPrice.Text);

                hotelEntityProbs.TotalAccommodationFee = hotelEntityProbs.PersonQuantity * hotelEntityProbs.SumDays * hotelEntityProbs.DailyGuestFee;
                hotelEntityProbs.TotalRoomFee = hotelEntityProbs.RoomPrice * hotelEntityProbs.SumDays;
                hotelEntityProbs.TotalBreakFastFee = hotelEntityProbs.BreakfastPrice * hotelEntityProbs.PersonQuantity * hotelEntityProbs.SumDays;
                hotelEntityProbs.TotalLunchFee = hotelEntityProbs.LunchPrice * hotelEntityProbs.PersonQuantity * hotelEntityProbs.SumDays;
                hotelEntityProbs.TotalDinnerFee = hotelEntityProbs.DinnerPrice * hotelEntityProbs.PersonQuantity * hotelEntityProbs.SumDays;
                hotelEntityProbs.TotalPrice = (hotelEntityProbs.TotalAccommodationFee + hotelEntityProbs.TotalRoomFee + hotelEntityProbs.TotalBreakFastFee + hotelEntityProbs.TotalLunchFee + hotelEntityProbs.TotalDinnerFee + hotelEntityProbs.Extrasprice) - hotelEntityProbs.DiscountPrice;

                tbPersonFee.Text = hotelEntityProbs.TotalAccommodationFee.ToString("C2");
                tbpTotalPrice.Text = hotelEntityProbs.TotalPrice.ToString("C2");
                tbBreakfastPrice.Text = hotelEntityProbs.BreakfastPrice.ToString("C2");
                tbLunchPrice.Text = hotelEntityProbs.LunchPrice.ToString("C2");
                tbDinnerPrice.Text = hotelEntityProbs.DinnerPrice.ToString("C2");
                tbDailyGuestFee.Text = hotelEntityProbs.DailyGuestFee.ToString("C2");
                tbExtrasPrice.Text = hotelEntityProbs.Extrasprice.ToString();
                tbDiscountPrice.Text = hotelEntityProbs.DiscountPrice.ToString();
            }

        }

        //
        //Toolları Kapatma
        //
        public void CloseTools()
        {
            tbCity1.Enabled = false;
            tbgiName1.Enabled = false;
            tbgiSurname1.Enabled = false;
            tbgiIdentNumber1.Enabled = false;
            mtbMsfrKytTelefon1.Enabled = false;
            tbgiEmail1.Enabled = false;
            cbgender1.Enabled = false;
            dtpgiBirthDay1.Enabled = false;
            tbgiAddress1.Enabled = false;
            tbRezervationNote.Enabled = false;
            cbIdentType.Enabled = false;
            cbMaritalStatus.Enabled = false;
            tbgiIdentSerialNo1.Enabled = false;
            tbCountry1.Enabled = false;
            tbDistrict1.Enabled = false;
            tbgiFatherName1.Enabled = false;
            tbgiMotherName1.Enabled = false;
            tbCarPlate1.Enabled = false;
            cbStatus.Enabled = false;
        }

        //
        //Toolları Açma
        //
        public void ToolsOpen()
        {
            tbCity1.Enabled = true;
            tbgiName1.Enabled = true;
            tbgiSurname1.Enabled = true;
            tbgiIdentNumber1.Enabled = true;
            mtbMsfrKytTelefon1.Enabled = true;
            tbgiEmail1.Enabled = true;
            cbgender1.Enabled = true;
            dtpgiBirthDay1.Enabled = true;
            tbgiAddress1.Enabled = true;
            tbRezervationNote.Enabled = true;
            cbIdentType.Enabled = true;
            cbMaritalStatus.Enabled = true;
            tbgiIdentSerialNo1.Enabled = true;
            tbCountry1.Enabled = true;
            tbDistrict1.Enabled = true;
            tbgiFatherName1.Enabled = true;
            tbgiMotherName1.Enabled = true;
            tbCarPlate1.Enabled = true;
            cbStatus.Enabled = true;
        }

        //
        //Diğer Misafir Bilgisi Butonunun Durumu
        //
        private void OtherGuestsInfoButon()
        {
            if (Convert.ToInt16(tbTotalGuestSum.Text) > 1)
            {
                bGuestInfoOther.Visible = true;
            }
            else
            {
                bGuestInfoOther.Visible = false;
            }
        }

        //
        //Toolların içeriklerini temizleme ve düzenleme
        //
        public void ClearTools()
        {
            tbbiId.Clear();
            dtpArrivalDate.Value = DateTime.Today;
            dtpDepartureDate.Value = DateTime.Today;
            dtpDepartureDate.Value = DateTime.Today.AddDays(+1);
            cbStatus.Text = "Rezervation";
            nudPersonQuantity.Value = 1;
            nudChildQuantity.Value = 0;
            tbDailyGuestFee.Text = hotelEntityProbs.DailyGuestFee.ToString();
            tbDiscountPrice.Text = "0";
            tbExtrasPrice.Text = "0";
            tbRoomNo.Clear();
            tbCity1.Clear();
            tbgiName1.Clear();
            tbgiSurname1.Clear();
            tbgiIdentNumber1.Clear();
            mtbMsfrKytTelefon1.Clear();
            tbgiEmail1.Clear();
            cbgender1.SelectedIndex = 0;
            tbgiAddress1.Clear();
            tbChildeFeeTotal.Text = "0";
            nudChildFeeQuantity.Value = 0;
            tbRezervationNote.Clear();
            dtpgiBirthDay1.Value = DateTime.Today;
            tbgiIdentSerialNo1.Clear();
            cbMaritalStatus.SelectedIndex = 0;
            tbDistrict1.Clear();
            tbgiFatherName1.Clear();
            tbgiMotherName1.Clear();
            tbCarPlate1.Clear();
            cbIdentType.SelectedIndex = 0;
            cbMaritalStatus.SelectedIndex = 0;
            tbCountry1.Text = "TC";
            cbAccommodationType.SelectedIndex = 0;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbgiName1.Text == "" || tbgiSurname1.Text == "" || tbgiIdentNumber1.Text == "" || mtbMsfrKytTelefon1.Text == "")
            {
                MessageBox.Show("Ad, soyad, telefon yada kimlik numarası bilgilerinden biri eksik girildiğinde ekleme yapılamaz!");
                RenewGridviews();
                ClearTools();
                CloseTools();

                //Butonların Durumu
                bEdit.Visible = false;
                bCancel.Visible = false;
                bSave.Visible = false;
                bRezervationAdd.Visible = true;
            }
            else
            {

                booking.RoomNo = tbRoomNo.Text;
                booking.Status = cbStatus.Text; ;
                booking.Arrivaldate = dtpArrivalDate.Value;
                booking.DepartureDate = dtpDepartureDate.Value;
                booking.SumDays = hotelEntityProbs.SumDays;
                booking.PersonQuantity = hotelEntityProbs.PersonQuantity;
                booking.ChildWithFeeTotal = hotelEntityProbs.ChildeWithFeeTotal;
                booking.ChildTotal = hotelEntityProbs.ChildTotal;
                booking.AllPersonTotal = hotelEntityProbs.AllPersonTotal;
                booking.AccommodationType = cbAccommodationType.Text;
                booking.BoardType = cbBoardType.Text;
                booking.Breakfast = cbBreakfast.Text;
                booking.Lunch = cbLunch.Text;
                booking.Dinner = cbDinner.Text;
                booking.InsertDateTime = DateTime.Now;
                booking.UpdateDateTime = DateTime.Now;


                guest.GuestName = tbgiName1.Text.Trim();
                guest.GuestSurName = tbgiSurname1.Text.Trim();
                guest.GuestPhone = mtbMsfrKytTelefon1.Text.Trim(); ;
                guest.GuestIdentType = cbIdentType.Text;
                guest.GuestIdentNumber = tbgiIdentNumber1.Text;
                guest.GuestMartialStatus = cbMaritalStatus.Text;
                guest.GuestGender = cbgender1.Text;
                guest.GuestEmail = tbgiEmail1.Text.Trim();
                guest.GuestCarPlate = tbCarPlate1.Text.Trim();
                guest.GuestCountry = tbCountry1.Text.Trim();
                guest.GuestCity = tbCity1.Text.Trim();
                guest.GuestDistrict = tbDistrict1.Text.Trim();
                guest.GuestFatherName = tbgiFatherName1.Text.Trim();
                guest.GuestMotherName = tbgiMotherName1.Text.Trim();
                guest.GuestBirthDay = dtpgiBirthDay1.Value;
                guest.GuestIdentSerialNo = tbgiIdentSerialNo1.Text.Trim();
                guest.GuestAddress = tbgiAddress1.Text.Trim();
                guest.GuestRezervationNote = tbRezervationNote.Text.Trim();
                guest.GuestsequenceNo = 1;
                guest.InsertDateTime = DateTime.Now;
                guest.UpdateDateTime = DateTime.Now;


                payment.RoomPrice = hotelEntityProbs.RoomPrice;
                payment.DailyPersonPrice = hotelEntityProbs.DailyPersonPrice;
                payment.DailyGuestFee = hotelEntityProbs.DailyGuestFee;
                payment.ChildFee = hotelEntityProbs.ChildFee;
                payment.ChildFeeTotal = hotelEntityProbs.ChildFeeTotal;
                payment.BreakfastPrice = hotelEntityProbs.BreakfastPrice;
                payment.LunchPrice = hotelEntityProbs.LunchPrice;
                payment.DinnerPrice = hotelEntityProbs.DinnerPrice;
                payment.TotalBreakFastFee = hotelEntityProbs.TotalBreakFastFee;
                payment.TotalLunchFee = hotelEntityProbs.TotalLunchFee;
                payment.TotalDinnerFee = hotelEntityProbs.TotalDinnerFee;
                payment.Extrasprice = hotelEntityProbs.Extrasprice;
                payment.DiscountPrice = hotelEntityProbs.DiscountPrice;
                payment.TotalPrice = hotelEntityProbs.TotalPrice;
                payment.TotalAccommodationFee = hotelEntityProbs.TotalAccommodationFee;
                payment.Totaldayspersonfee = hotelEntityProbs.Totaldayspersonfee;
                payment.InsertDateTime = DateTime.Now;
                payment.UpdateDateTime = DateTime.Now;


                db.BookingInformation.Add(booking);
                db.GuestInformation.Add(guest);
                db.Payments.Add(payment);

                db.SaveChanges();

                RenewGridviews();
                ClearTools();
                CloseTools();

                //Butonların Durumu
                bEdit.Visible = false;
                bCancel.Visible = false;
                bSave.Visible = false;
                bRezervationAdd.Visible = true;
            }


        }

        private void bRezervationAdd_Click(object sender, EventArgs e)
        {
            //Butonların durumu
            bCancel.Visible = true;
            bRezervationAdd.Visible = false;
            bSave.Visible = true;
            bEdit.Visible = false;
            cbAccommodationType.SelectedIndex = 0;

            //Bilgi Tool ları durumu
            ToolsOpen();

            //Bilgi Tool larının içerikleri
            ClearTools();

            RenewGridviews();

        }

        private void dtpDepartureDate_ValueChanged(object sender, EventArgs e)
        {
            //Toplm Gün Hesaplama
            DayTotal();

            //Toplam Tutar Hesaplama
            Bookingpayment();

            //Oda Butonlarının bilgileri
            //RoomsButtonsInfo();


        }

        private void nudPersonQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nudPersonQuantity.Value <= 1)
            {
                nudPersonQuantity.Value = 1;
            }

            //Toplam Tutar Hesaplama
            Bookingpayment();

            //Kişi Sayısı Toplama
            PersonSumTotal();
        }

        private void nudChildFeeQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nudChildFeeQuantity.Value <= 0)
            {
                nudChildFeeQuantity.Value = 0;
            }

            //Toplam Tutar Hesaplama
            Bookingpayment();

            //Kişi Sayısı Toplama
            PersonSumTotal();
        }

        private void nudChildQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nudChildQuantity.Value <= 0)
            {
                nudChildQuantity.Value = 0;
            }

            //Toplam Tutar Hesaplama
            Bookingpayment();

            //Kişi Sayısı Toplama
            PersonSumTotal();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            //Butonların Durumu
            bEdit.Visible = false;
            bCancel.Visible = false;
            bSave.Visible = false;
            bRezervationAdd.Visible = true;
            bGuestInfoOther.Visible = false;

            //Bilgi Tool larının Durumu
            CloseTools();

            //Bilgi Tool larının içerikleri
            ClearTools();

            RenewGridviews();
        }

        private void tbExtrasPrice_TextChanged(object sender, EventArgs e)
        {
            //Toplam Tutar Hesaplama
            Bookingpayment();
        }

        private void tbDiscountPrice_TextChanged(object sender, EventArgs e)
        {
            //Toplam Tutar Hesaplama
            Bookingpayment();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (hotelEntityProbs.RezervationID >= 0)
            {
                var updatebookings = db.BookingInformation.Where(i => i.BookingId == hotelEntityProbs.RezervationID);

                foreach (var updatebooking in updatebookings)
                {
                    updatebooking.RoomNo = tbRoomNo.Text;
                    updatebooking.Status = cbStatus.Text;
                    updatebooking.Arrivaldate = dtpArrivalDate.Value;
                    updatebooking.DepartureDate = dtpDepartureDate.Value;
                    updatebooking.SumDays = hotelEntityProbs.SumDays;
                    updatebooking.PersonQuantity = hotelEntityProbs.PersonQuantity;
                    updatebooking.ChildWithFeeTotal = hotelEntityProbs.ChildeWithFeeTotal;
                    updatebooking.ChildTotal = hotelEntityProbs.ChildTotal;
                    updatebooking.AllPersonTotal = hotelEntityProbs.AllPersonTotal;
                    updatebooking.AccommodationType = cbAccommodationType.Text;
                    updatebooking.BoardType = cbBoardType.Text;
                    updatebooking.Breakfast = cbBreakfast.Text;
                    updatebooking.Lunch = cbLunch.Text;
                    updatebooking.Dinner = cbDinner.Text;
                    updatebooking.UpdateDateTime = DateTime.Now;
                }

                var updateguests = db.GuestInformation.Where(i => i.BookingInformation.BookingId == hotelEntityProbs.RezervationID);

                foreach (var updateguest in updateguests)
                {
                    updateguest.GuestName = tbgiName1.Text;
                    updateguest.GuestSurName = tbgiSurname1.Text;
                    updateguest.GuestPhone = mtbMsfrKytTelefon1.Text;
                    updateguest.GuestIdentType = cbIdentType.Text;
                    updateguest.GuestIdentNumber = tbgiIdentNumber1.Text;
                    updateguest.GuestMartialStatus = cbMaritalStatus.Text;
                    updateguest.GuestGender = cbgender1.Text;
                    updateguest.GuestEmail = tbgiEmail1.Text;
                    updateguest.GuestCarPlate = tbCarPlate1.Text;
                    updateguest.GuestCountry = tbCountry1.Text;
                    updateguest.GuestCity = tbCity1.Text;
                    updateguest.GuestDistrict = tbDistrict1.Text;
                    updateguest.GuestFatherName = tbgiFatherName1.Text;
                    updateguest.GuestMotherName = tbgiMotherName1.Text;
                    updateguest.GuestBirthDay = dtpgiBirthDay1.Value;
                    updateguest.GuestIdentSerialNo = tbgiIdentSerialNo1.Text;
                    updateguest.GuestAddress = tbgiAddress1.Text;
                    updateguest.GuestRezervationNote = tbRezervationNote.Text;
                    updateguest.UpdateDateTime = DateTime.Now;
                }

                var updatepayments = db.Payments.Where(i => i.BookingInformation.BookingId == hotelEntityProbs.RezervationID);

                foreach (var updatepayment in updatepayments)
                {
                    updatepayment.RoomPrice = hotelEntityProbs.RoomPrice;
                    updatepayment.DailyPersonPrice = hotelEntityProbs.DailyPersonPrice;
                    updatepayment.DailyGuestFee = hotelEntityProbs.DailyGuestFee;
                    updatepayment.ChildFee = hotelEntityProbs.ChildFee;
                    updatepayment.ChildFeeTotal = hotelEntityProbs.ChildFeeTotal;
                    updatepayment.BreakfastPrice = hotelEntityProbs.BreakfastPrice;
                    updatepayment.LunchPrice = hotelEntityProbs.LunchPrice;
                    updatepayment.DinnerPrice = hotelEntityProbs.DinnerPrice;
                    updatepayment.TotalBreakFastFee = hotelEntityProbs.TotalBreakFastFee;
                    updatepayment.TotalLunchFee = hotelEntityProbs.TotalLunchFee;
                    updatepayment.TotalDinnerFee = hotelEntityProbs.TotalDinnerFee;
                    updatepayment.Extrasprice = hotelEntityProbs.Extrasprice;
                    updatepayment.DiscountPrice = hotelEntityProbs.DiscountPrice;
                    updatepayment.TotalPrice = hotelEntityProbs.TotalPrice;
                    updatepayment.TotalAccommodationFee = hotelEntityProbs.TotalAccommodationFee;
                    updatepayment.Totaldayspersonfee = hotelEntityProbs.Totaldayspersonfee;
                    updatepayment.UpdateDateTime = DateTime.Now;
                }

                db.SaveChanges();

                RenewGridviews();
                ClearTools();
                CloseTools();

                //Butonların Durumu
                bEdit.Visible = false;
                bCancel.Visible = false;
                bSave.Visible = false;
                bRezervationAdd.Visible = true;
            }
            else
            {
                MessageBox.Show("Kayıt seçimi yapılmadı!");
            }
        }

        private void dgwBooking_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            hotelEntityProbs.RezervationID = Convert.ToInt32(dgwBooking.CurrentRow.Cells[0].Value);

            var selectbookings = db.BookingInformation.Where(i => i.BookingId == hotelEntityProbs.RezervationID);

            foreach (var selectbooking in selectbookings)
            {
                tbbiId.Text = hotelEntityProbs.RezervationID.ToString();
                tbRoomNo.Text = selectbooking.RoomNo;
                cbStatus.Text = selectbooking.Status;
                dtpArrivalDate.Value = selectbooking.Arrivaldate;
                dtpDepartureDate.Value = selectbooking.DepartureDate;
                tbSumDay.Text = selectbooking.SumDays.ToString();
                //nudPersonQuantity.Value = selectbooking.PersonQuantity;
                //nudChildFeeQuantity.Value = selectbooking.ChildWithFeeTotal;
                //nudChildQuantity.Value = selectbooking.ChildTotal;
                tbTotalGuestSum.Text = selectbooking.AllPersonTotal.ToString();
                cbAccommodationType.Text = selectbooking.AccommodationType;
                cbBoardType.Text = selectbooking.BoardType;
                cbBreakfast.Text = selectbooking.Breakfast;
                cbLunch.Text = selectbooking.Lunch;
                cbDinner.Text = selectbooking.Dinner;

            }

            var selectguests = db.GuestInformation.Where(i => i.BookingInformation.BookingId == hotelEntityProbs.RezervationID);

            foreach (var selectguest in selectguests)
            {
                tbgiName1.Text = selectguest.GuestName;
                tbgiSurname1.Text = selectguest.GuestSurName;
                mtbMsfrKytTelefon1.Text = selectguest.GuestPhone;
                cbIdentType.Text = selectguest.GuestIdentType;
                tbgiIdentNumber1.Text = selectguest.GuestIdentNumber;
                cbMaritalStatus.Text = selectguest.GuestMartialStatus;
                cbgender1.Text = selectguest.GuestGender;
                tbgiEmail1.Text = selectguest.GuestEmail;
                tbCarPlate1.Text = selectguest.GuestCarPlate;
                tbCountry1.Text = selectguest.GuestCountry;
                tbCity1.Text = selectguest.GuestCity;
                tbDistrict1.Text = selectguest.GuestDistrict;
                tbgiFatherName1.Text = selectguest.GuestFatherName;
                tbgiMotherName1.Text = selectguest.GuestMotherName;
                //dtpgiBirthDay1.Value = selectguest.GuestBirthDay;
                tbgiIdentSerialNo1.Text = selectguest.GuestIdentSerialNo;
                tbgiAddress1.Text = selectguest.GuestAddress;
                tbRezervationNote.Text = selectguest.GuestRezervationNote;
            }

            var selectpayments = db.Payments.Where(i => i.BookingInformation.BookingId == hotelEntityProbs.RezervationID);

            foreach (var selectpayment in selectpayments)
            {
                //tbRoomFee.Text = selectpayment.TotalRoomFee.ToString("C2");
                //tbDailyGuestFee.Text = selectpayment.DailyGuestFee.ToString("C2");
                //tbPersonFee.Text = selectpayment.DailyPersonPrice.ToString("C2");
                //tbChildeFee.Text = selectpayment.ChildFee.ToString("C2");
                //tbChildeFeeTotal.Text = selectpayment.ChildFeeTotal.ToString("C2");
                //tbBreakfastPrice.Text = selectpayment.BreakfastPrice.ToString("C2");
                //tbLunchPrice.Text = selectpayment.LunchPrice.ToString("C2");
                //tbDinnerPrice.Text = selectpayment.DinnerPrice.ToString("C2");
                //tbExtrasPrice.Text = selectpayment.Extrasprice.ToString();
                tbDiscountPrice.Text = selectpayment.DiscountPrice.ToString();
                tbpTotalPrice.Text = selectpayment.TotalPrice.ToString("C2");
            }


            //Bilgi Tool larının Durumu            
            ToolsOpen();

            //Butonların Durumu
            bEdit.Visible = true;
            bCancel.Visible = true;
            bSave.Visible = false;
            bRezervationAdd.Visible = false;
        }
        //    private void RoomsButtonsInfo()
        //{
        //    //    string Room102 = "";

        //    //bRoom102.Text = "- 102 -                        - 1 Çift -";

        //    var rooms102 = db.GuestInformation
        //        .Include(i => i.BookingInformation)
        //        .Where(i => i.BookingInformation.Arrivaldate <= i.BookingInformation.DepartureDate && i.BookingInformation.DepartureDate >= i.BookingInformation.Arrivaldate && i.BookingInformation.RoomNo == "102" && i.BookingInformation.Status != "CheckOut" && i.BookingInformation.Status != "Canceled" && i.BookingId == i.BookingInformation.BookingId && i.GuestsequenceNo == 1)
        //        .ToList();

        //    foreach (var item in rooms102)
        //    {
        //        bRoom102.Text = item.GuestName + " " + item.GuestSurName;
        //        textBox1.Text = item.GuestName;
        //    } 

        //    //textBox1.Text = rooms102.ToString();

        //}

        private void bRoom102_Click(object sender, EventArgs e)
        {
            tbRoomNo.Text = "102";
        }

        private void dtpArrivalDate_ValueChanged(object sender, EventArgs e)
        {
            DayTotal();
            Bookingpayment();
            //RoomsButtonsInfo();


        }

        //     private void RoomButtonsInfo()
        //{
        //    //102//

        //    string Room102 = "";

        //    bRoom102.Text = "- 102 -                        - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut102 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='102' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut102.ExecuteNonQuery();
        //    SqlDataReader oku102 = komut102.ExecuteReader();

        //    while (oku102.Read())
        //    {

        //        bRoom102.Text = "ODA 102 " + oku102["gi_name_1"].ToString() + " " + oku102["gi_surname_1"].ToString() + " " + oku102["bi_person_quantity"] + " Kişi " + oku102["bi_status"];
        //        Room102 = oku102["bi_status"].ToString();
        //    }

        //    if (bRoom102.Text != "- 102 -                        - 1 Çift -" && Room102 == "Rezervation")
        //    {
        //        bRoom102.BackColor = Color.YellowGreen;
        //        bRoom102.ForeColor = Color.White;
        //        bRoom102.Enabled = false;
        //    }
        //    else if (bRoom102.Text != "- 102 -                        - 1 Çift -" && Room102 == "CheckIn")
        //    {
        //        bRoom102.BackColor = Color.Red;
        //        bRoom102.ForeColor = Color.White;
        //        bRoom102.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom102.Text = "- 102 -                        - 1 Çift -";
        //        bRoom102.Enabled = true;
        //        bRoom102.BackColor = Color.White;
        //        bRoom102.ForeColor = Color.Black;
        //    }
        //    _connection.Close();

        //    //103//

        //    string Room103 = "";

        //    bRoom103.Text = "- 103 -                        - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut103 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='103' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut103.ExecuteNonQuery();
        //    SqlDataReader oku103 = komut103.ExecuteReader();

        //    while (oku103.Read())
        //    {

        //        bRoom103.Text = "ODA 103 " + oku103["gi_name_1"].ToString() + " " + oku103["gi_surname_1"].ToString() + " " + oku103["bi_person_quantity"] + " Kişi " + oku103["bi_status"];
        //        Room103 = oku103["bi_status"].ToString();
        //    }

        //    if (bRoom103.Text != "- 103 -                        - 1 Çift -" && Room103 == "Rezervation")
        //    {
        //        bRoom103.BackColor = Color.YellowGreen;
        //        bRoom103.ForeColor = Color.White;
        //        bRoom103.Enabled = false;
        //    }
        //    else if (bRoom103.Text != "- 103 -                        - 1 Çift -" && Room103 == "CheckIn")
        //    {
        //        bRoom103.BackColor = Color.Red;
        //        bRoom103.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom103.Text = "- 103 -                        - 1 Çift -";
        //        bRoom103.Enabled = true;
        //        bRoom103.BackColor = Color.White;
        //        bRoom103.ForeColor = Color.Black;
        //    }
        //    _connection.Close();

        //    //104//

        //    string Room104 = "";

        //    bRoom104.Text = "- 104 -                        - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut104 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='104' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut104.ExecuteNonQuery();
        //    SqlDataReader oku104 = komut104.ExecuteReader();

        //    while (oku104.Read())
        //    {

        //        bRoom104.Text = "ODA 104 " + oku104["gi_name_1"].ToString() + " " + oku104["gi_surname_1"].ToString() + " " + oku104["bi_person_quantity"] + " Kişi " + oku104["bi_status"];
        //        Room104 = oku104["bi_status"].ToString();
        //    }

        //    if (bRoom104.Text != "- 104 -                        - 1 Çift -" && Room104 == "Rezervation")
        //    {
        //        bRoom104.BackColor = Color.YellowGreen;
        //        bRoom104.ForeColor = Color.White;
        //        bRoom104.Enabled = false;
        //    }
        //    else if (bRoom104.Text != "- 104 -                        - 1 Çift -" && Room104 == "CheckIn")
        //    {
        //        bRoom104.BackColor = Color.Red;
        //        bRoom104.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom104.Text = "- 104 -                        - 1 Çift -";
        //        bRoom104.Enabled = true;
        //        bRoom104.ForeColor = Color.Black;
        //        bRoom104.BackColor = Color.White;
        //    }
        //    _connection.Close();

        //    //105//

        //    string Room105 = "";

        //    bRoom105.Text = "- 105 -                        - 1 Çift - 1 Tek";

        //    _connection.Open();
        //    SqlCommand komut105 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='105' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut105.ExecuteNonQuery();
        //    SqlDataReader oku105 = komut105.ExecuteReader();

        //    while (oku105.Read())
        //    {

        //        bRoom105.Text = "ODA 105 " + oku105["gi_name_1"].ToString() + " " + oku105["gi_surname_1"].ToString() + " " + oku105["bi_person_quantity"] + " Kişi " + oku105["bi_status"];
        //        Room105 = oku105["bi_status"].ToString();
        //    }

        //    if (bRoom105.Text != "- 105 -                        - 1 Çift - 1 Tek" && Room105 == "Rezervation")
        //    {
        //        bRoom105.BackColor = Color.YellowGreen;
        //        bRoom105.ForeColor = Color.White;
        //        bRoom105.Enabled = false;
        //    }
        //    else if (bRoom105.Text != "- 105 -                        - 1 Çift - 1 Tek" && Room105 == "CheckIn")
        //    {
        //        bRoom105.BackColor = Color.Red;
        //        bRoom105.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom105.Text = "- 105 -                        - 1 Çift - 1 Tek";
        //        bRoom105.Enabled = true;
        //        bRoom105.BackColor = Color.White;
        //        bRoom105.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //106//

        //    string Room106 = "";

        //    bRoom106.Text = "- 106 -                        - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut106 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='106'and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut106.ExecuteNonQuery();
        //    SqlDataReader oku106 = komut106.ExecuteReader();

        //    while (oku106.Read())
        //    {

        //        bRoom106.Text = "ODA 106 " + oku106["gi_name_1"].ToString() + " " + oku106["gi_surname_1"].ToString() + " " + oku106["bi_person_quantity"] + " Kişi " + oku106["bi_status"];
        //        Room106 = oku106["bi_status"].ToString();
        //    }

        //    if (bRoom106.Text != "- 106 -                        - 2 Tek -" && Room106 == "Rezervation")
        //    {
        //        bRoom106.BackColor = Color.YellowGreen;
        //        bRoom106.ForeColor = Color.White;
        //        bRoom106.Enabled = false;
        //    }
        //    else if (bRoom106.Text != "- 106 -                        - 2 Tek -" && Room106 == "CheckIn")
        //    {
        //        bRoom106.BackColor = Color.Red;
        //        bRoom106.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom106.Text = "- 106 -                        - 2 Tek -";
        //        bRoom106.Enabled = true;
        //        bRoom106.BackColor = Color.White;
        //        bRoom106.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //107//

        //    string Room107 = "";

        //    bRoom107.Text = "- 107 -                        - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut107 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='107' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut107.ExecuteNonQuery();
        //    SqlDataReader oku107 = komut107.ExecuteReader();

        //    while (oku107.Read())
        //    {

        //        bRoom107.Text = "ODA 107 " + oku107["gi_name_1"].ToString() + " " + oku107["gi_surname_1"].ToString() + " " + oku107["bi_person_quantity"] + " Kişi " + oku107["bi_status"];
        //        Room107 = oku107["bi_status"].ToString();
        //    }

        //    if (bRoom107.Text != "- 107 -                        - 2 Tek -" && Room107 == "Rezervation")
        //    {
        //        bRoom107.BackColor = Color.YellowGreen;
        //        bRoom107.ForeColor = Color.White;
        //        bRoom107.Enabled = false;
        //    }
        //    else if (bRoom107.Text != "- 107 -                        - 2 Tek -" && Room107 == "CheckIn")
        //    {
        //        bRoom107.BackColor = Color.Red;
        //        bRoom107.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom107.Text = "- 107 -                        - 2 Tek -";
        //        bRoom107.Enabled = true;
        //        bRoom107.BackColor = Color.White;
        //        bRoom107.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //201//

        //    string Room201 = "";

        //    bRoom201.Text = "- 201 -                       -1 Çift - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut201 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='201'and g.gi_guest_no='1' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut201.ExecuteNonQuery();
        //    SqlDataReader oku201 = komut201.ExecuteReader();

        //    while (oku201.Read())
        //    {

        //        bRoom201.Text = "ODA 201 " + oku201["gi_name_1"].ToString() + " " + oku201["gi_surname_1"].ToString() + " " + oku201["bi_person_quantity"] + " Kişi " + oku201["bi_status"];
        //        Room201 = oku201["bi_status"].ToString();
        //    }

        //    if (bRoom201.Text != "- 201 -                       -1 Çift - 2 Tek -" && Room201 == "Rezervation")
        //    {
        //        bRoom201.BackColor = Color.YellowGreen;
        //        bRoom201.ForeColor = Color.White;
        //        bRoom201.Enabled = false;
        //    }
        //    else if (bRoom201.Text != "- 201 -                       -1 Çift - 2 Tek -" && Room201 == "CheckIn")
        //    {
        //        bRoom201.BackColor = Color.Red;
        //        bRoom201.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom201.Text = "- 201 -                       -1 Çift - 2 Tek - ";
        //        bRoom201.Enabled = true;
        //        bRoom201.BackColor = Color.White;
        //        bRoom201.ForeColor = Color.Black;
        //    }
        //    _connection.Close();

        //    //202//

        //    string Room202 = "";

        //    bRoom202.Text = "- 202 -                        - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut202 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='202' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut202.ExecuteNonQuery();
        //    SqlDataReader oku202 = komut202.ExecuteReader();

        //    while (oku202.Read())
        //    {

        //        bRoom202.Text = "ODA 202 " + oku202["gi_name_1"].ToString() + " " + oku202["gi_surname_1"].ToString() + " " + oku202["bi_person_quantity"] + " Kişi " + oku202["bi_status"];
        //        Room202 = oku202["bi_status"].ToString();
        //    }

        //    if (bRoom202.Text != "- 202 -                        - 1 Çift -" && Room202 == "Rezervation")
        //    {
        //        bRoom202.BackColor = Color.YellowGreen;
        //        bRoom202.ForeColor = Color.White;
        //        bRoom202.Enabled = false;
        //    }
        //    else if (bRoom202.Text != "- 202 -                        - 1 Çift -" && Room202 == "CheckIn")
        //    {
        //        bRoom202.BackColor = Color.Red;
        //        bRoom202.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom202.Text = "- 202 -                        - 1 Çift -";
        //        bRoom202.Enabled = true;
        //        bRoom202.BackColor = Color.White;
        //        bRoom202.ForeColor = Color.Black;
        //    }

        //    _connection.Close();


        //    //203//

        //    string Room203 = "";

        //    bRoom203.Text = "- 203 -                       - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut203 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='203' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut203.ExecuteNonQuery();
        //    SqlDataReader oku203 = komut203.ExecuteReader();

        //    while (oku203.Read())
        //    {

        //        bRoom203.Text = "ODA 203 " + oku203["gi_name_1"].ToString() + " " + oku203["gi_surname_1"].ToString() + " " + oku203["bi_person_quantity"] + " Kişi " + oku203["bi_status"];
        //        Room203 = oku203["bi_status"].ToString();
        //    }

        //    if (bRoom203.Text != "- 203 -                       - 1 Çift -" && Room203 == "Rezervation")
        //    {
        //        bRoom203.BackColor = Color.YellowGreen;
        //        bRoom203.ForeColor = Color.White;
        //        bRoom203.Enabled = false;
        //    }
        //    else if (bRoom203.Text != "- 203 -                       - 1 Çift -" && Room203 == "CheckIn")
        //    {
        //        bRoom203.BackColor = Color.Red;
        //        bRoom203.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom203.Text = "- 203 -                       - 1 Çift -";
        //        bRoom203.Enabled = true;
        //        bRoom203.BackColor = Color.White;
        //        bRoom203.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //204//

        //    string Room204 = "";

        //    bRoom204.Text = "- 204 -                       - 1 Çift -";

        //    _connection.Open();
        //    SqlCommand komut204 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='204' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut204.ExecuteNonQuery();
        //    SqlDataReader oku204 = komut204.ExecuteReader();

        //    while (oku204.Read())
        //    {

        //        bRoom204.Text = "ODA 204 " + oku204["gi_name_1"].ToString() + " " + oku204["gi_surname_1"].ToString() + " " + oku204["bi_person_quantity"] + " Kişi " + oku204["bi_status"];
        //        Room204 = oku204["bi_status"].ToString();
        //    }

        //    if (bRoom204.Text != "- 204 -                       - 1 Çift -" && Room204 == "Rezervation")
        //    {
        //        bRoom204.BackColor = Color.YellowGreen;
        //        bRoom204.ForeColor = Color.White;
        //        bRoom204.Enabled = false;
        //    }
        //    else if (bRoom204.Text != "- 204 -                       - 1 Çift -" && Room204 == "CheckIn")
        //    {
        //        bRoom204.BackColor = Color.Red;
        //        bRoom204.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom204.Text = "- 204 -                       - 1 Çift -";
        //        bRoom204.Enabled = true;
        //        bRoom204.BackColor = Color.White;
        //        bRoom204.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //205//

        //    string Room205 = "";

        //    bRoom205.Text = "- 205 -                       - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut205 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='205' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut205.ExecuteNonQuery();
        //    SqlDataReader oku205 = komut205.ExecuteReader();

        //    while (oku205.Read())
        //    {

        //        bRoom205.Text = "ODA 205 " + oku205["gi_name_1"].ToString() + " " + oku205["gi_surname_1"].ToString() + " " + oku205["bi_person_quantity"] + " Kişi " + oku205["bi_status"];
        //        Room205 = oku205["bi_status"].ToString();
        //    }

        //    if (bRoom205.Text != "- 205 -                        - 1 Tek - 1 Çift -" && Room205 == "Rezervation")
        //    {
        //        bRoom205.BackColor = Color.YellowGreen;
        //        bRoom205.ForeColor = Color.White;
        //        bRoom205.Enabled = false;
        //    }
        //    else if (bRoom205.Text != "- 205 -                        - 1 Tek - 1 Çift -" && Room205 == "CheckIn")
        //    {
        //        bRoom205.BackColor = Color.Red;
        //        bRoom205.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom205.Text = "- 205 -                       - 1 Tek - 1 Çift -";
        //        bRoom205.Enabled = true;
        //        bRoom205.BackColor = Color.White;
        //        bRoom205.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //206//

        //    string Room206 = "";

        //    bRoom206.Text = "- 206 -                       - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut206 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='206' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut206.ExecuteNonQuery();
        //    SqlDataReader oku206 = komut206.ExecuteReader();

        //    while (oku206.Read())
        //    {

        //        bRoom206.Text = "ODA 206 " + oku206["gi_name_1"].ToString() + " " + oku206["gi_surname_1"].ToString() + " " + oku206["bi_person_quantity"] + " Kişi " + oku206["bi_status"];
        //        Room206 = oku206["bi_status"].ToString();
        //    }

        //    if (bRoom206.Text != "- 206 -                       - 1 Çift -" && Room206 == "Rezervation")
        //    {
        //        bRoom206.BackColor = Color.YellowGreen;
        //        bRoom206.ForeColor = Color.White;
        //        bRoom206.Enabled = false;
        //    }
        //    else if (bRoom206.Text != "- 206 -                       - 1 Çift -" && Room206 == "CheckIn")
        //    {
        //        bRoom206.BackColor = Color.Red;
        //        bRoom206.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom206.Text = "- 206 -                       - 1 Çift -";
        //        bRoom206.Enabled = true;
        //        bRoom206.BackColor = Color.White;
        //        bRoom206.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //207//

        //    string Room207 = "";

        //    bRoom207.Text = "- 207 -                       - 2 Tek -";

        //    _connection.Open();
        //    SqlCommand komut207 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='207' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut207.ExecuteNonQuery();
        //    SqlDataReader oku207 = komut207.ExecuteReader();

        //    while (oku207.Read())
        //    {

        //        bRoom207.Text = "ODA 207 " + oku207["gi_name_1"].ToString() + " " + oku207["gi_surname_1"].ToString() + " " + oku207["bi_person_quantity"] + " Kişi " + oku207["bi_status"];
        //        Room207 = oku207["bi_status"].ToString();
        //    }

        //    if (bRoom207.Text != "- 207 -                       - 2 Tek -" && Room207 == "Rezervation")
        //    {
        //        bRoom207.BackColor = Color.YellowGreen;
        //        bRoom207.ForeColor = Color.White;
        //        bRoom207.Enabled = false;
        //    }
        //    else if (bRoom207.Text != "- 207 -                       - 2 Tek -" && Room207 == "CheckIn")
        //    {
        //        bRoom207.BackColor = Color.Red;
        //        bRoom207.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom207.Text = "- 207 -                       - 2 Tek -";
        //        bRoom207.Enabled = true;
        //        bRoom207.BackColor = Color.White;
        //        bRoom207.ForeColor = Color.Black;
        //    }

        //    _connection.Close();

        //    //208//

        //    string Room208 = "";

        //    bRoom208.Text = "- 208 -                       - 1 Çift - 3 Tek -";

        //    _connection.Open();
        //    SqlCommand komut208 = new SqlCommand("SELECT g.gi_name_1,g.gi_surname_1,b.bi_room_number,b.bi_departure_date,b.bi_arrival_date,b.bi_person_quantity,b.bi_status,g.gi_guest_no FROM gy_booking_info b, gy_guest_info g WHERE b.id_booking_info=g.booking_info_id and b.bi_room_number='208' and g.gi_guest_no='1' and b.bi_status!='CheckOut' and b.bi_status!='Canceled' AND b.bi_arrival_date <= '" + dtpDepartureDate.Value.ToString("yyyy-MM-dd") + "'  AND b.bi_departure_date >= '" + dtpArrivalDate.Value.ToString("yyyy-MM-dd") + "'", _connection);
        //    komut208.ExecuteNonQuery();
        //    SqlDataReader oku208 = komut208.ExecuteReader();

        //    while (oku208.Read())
        //    {

        //        bRoom208.Text = "ODA 208 " + oku208["gi_name_1"].ToString() + " " + oku208["gi_surname_1"].ToString() + " " + oku208["bi_person_quantity"] + " Kişi " + oku208["bi_status"];
        //        Room208 = oku208["bi_status"].ToString();
        //    }

        //    if (bRoom208.Text != "- 208 -                       - 1 Çift - 3 Tek -" && Room208 == "Rezervation")
        //    {
        //        bRoom208.BackColor = Color.YellowGreen;
        //        bRoom208.ForeColor = Color.White;
        //        bRoom208.Enabled = false;
        //    }
        //    else if (bRoom208.Text != "- 208 -                       - 1 Çift - 3 Tek -" && Room208 == "CheckIn")
        //    {
        //        bRoom208.BackColor = Color.Red;
        //        bRoom208.Enabled = false;
        //    }
        //    else
        //    {
        //        bRoom208.Text = "- 208 -                       - 1 Çift - 3 Tek -";
        //        bRoom208.Enabled = true;
        //        bRoom208.BackColor = Color.White;
        //        bRoom208.ForeColor = Color.Black;
        //    }

        //    _connection.Close();


    }
    
}
