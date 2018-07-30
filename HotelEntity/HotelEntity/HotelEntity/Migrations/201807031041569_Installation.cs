namespace HotelEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Installation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingInformations",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Arrivaldate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        RoomNo = c.String(),
                        Status = c.String(),
                        SumDays = c.Int(nullable: false),
                        ChildTotal = c.Int(nullable: false),
                        ChildWithFeeTotal = c.Int(nullable: false),
                        PersonQuantity = c.Int(nullable: false),
                        AllPersonTotal = c.Int(nullable: false),
                        AccommodationType = c.String(),
                        BoardType = c.String(),
                        Breakfast = c.String(),
                        Lunch = c.String(),
                        Dinner = c.String(),
                        InsertDateTime = c.DateTime(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId);
            
            CreateTable(
                "dbo.GuestInformations",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        GuestName = c.String(nullable: false),
                        GuestSurName = c.String(nullable: false),
                        GuestPhone = c.String(nullable: false),
                        GuestIdentNumber = c.String(maxLength: 11),
                        GuestCity = c.String(),
                        GuestGender = c.String(),
                        GuestEmail = c.String(),
                        GuestBirthDay = c.DateTime(nullable: false),
                        GuestAddress = c.String(),
                        GuestFatherName = c.String(),
                        GuestMotherName = c.String(),
                        GuestMartialStatus = c.String(),
                        GuestIdentType = c.String(),
                        GuestIdentSerialNo = c.String(),
                        GuestCountry = c.String(),
                        GuestDistrict = c.String(),
                        GuestCarPlate = c.String(),
                        GuestRezervationNote = c.String(),
                        GuestsequenceNo = c.Int(nullable: false),
                        InsertDateTime = c.DateTime(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        BookingInformation_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.GuestId)
                .ForeignKey("dbo.BookingInformations", t => t.BookingInformation_BookingId)
                .Index(t => t.BookingInformation_BookingId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        DailyPersonPrice = c.Double(nullable: false),
                        DailyGuestFee = c.Double(nullable: false),
                        Extrasprice = c.Double(nullable: false),
                        DiscountPrice = c.Double(nullable: false),
                        ChildFee = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        RoomPrice = c.Double(nullable: false),
                        BreakfastPrice = c.Double(nullable: false),
                        LunchPrice = c.Double(nullable: false),
                        DinnerPrice = c.Double(nullable: false),
                        ChildFeeTotal = c.Double(nullable: false),
                        TotalAccommodationFee = c.Double(nullable: false),
                        TotalRoomFee = c.Double(nullable: false),
                        TotalBreakFastFee = c.Double(nullable: false),
                        TotalLunchFee = c.Double(nullable: false),
                        TotalDinnerFee = c.Double(nullable: false),
                        Totaldayspersonfee = c.Double(nullable: false),
                        InsertDateTime = c.DateTime(nullable: false),
                        UpdateDateTime = c.DateTime(nullable: false),
                        BookingInformation_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.BookingInformations", t => t.BookingInformation_BookingId)
                .Index(t => t.BookingInformation_BookingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingInformation_BookingId", "dbo.BookingInformations");
            DropForeignKey("dbo.GuestInformations", "BookingInformation_BookingId", "dbo.BookingInformations");
            DropIndex("dbo.Payments", new[] { "BookingInformation_BookingId" });
            DropIndex("dbo.GuestInformations", new[] { "BookingInformation_BookingId" });
            DropTable("dbo.Payments");
            DropTable("dbo.GuestInformations");
            DropTable("dbo.BookingInformations");
        }
    }
}
