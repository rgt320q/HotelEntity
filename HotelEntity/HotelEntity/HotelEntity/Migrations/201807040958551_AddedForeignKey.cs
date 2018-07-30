namespace HotelEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GuestInformations", "BookingInformation_BookingId", "dbo.BookingInformations");
            DropForeignKey("dbo.Payments", "BookingInformation_BookingId", "dbo.BookingInformations");
            DropIndex("dbo.GuestInformations", new[] { "BookingInformation_BookingId" });
            DropIndex("dbo.Payments", new[] { "BookingInformation_BookingId" });
            RenameColumn(table: "dbo.GuestInformations", name: "BookingInformation_BookingId", newName: "BookingId");
            RenameColumn(table: "dbo.Payments", name: "BookingInformation_BookingId", newName: "BookingId");
            AlterColumn("dbo.GuestInformations", "BookingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.GuestInformations", "BookingId");
            CreateIndex("dbo.Payments", "BookingId");
            AddForeignKey("dbo.GuestInformations", "BookingId", "dbo.BookingInformations", "BookingId", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "BookingId", "dbo.BookingInformations", "BookingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "BookingId", "dbo.BookingInformations");
            DropForeignKey("dbo.GuestInformations", "BookingId", "dbo.BookingInformations");
            DropIndex("dbo.Payments", new[] { "BookingId" });
            DropIndex("dbo.GuestInformations", new[] { "BookingId" });
            AlterColumn("dbo.Payments", "BookingId", c => c.Int());
            AlterColumn("dbo.GuestInformations", "BookingId", c => c.Int());
            RenameColumn(table: "dbo.Payments", name: "BookingId", newName: "BookingInformation_BookingId");
            RenameColumn(table: "dbo.GuestInformations", name: "BookingId", newName: "BookingInformation_BookingId");
            CreateIndex("dbo.Payments", "BookingInformation_BookingId");
            CreateIndex("dbo.GuestInformations", "BookingInformation_BookingId");
            AddForeignKey("dbo.Payments", "BookingInformation_BookingId", "dbo.BookingInformations", "BookingId");
            AddForeignKey("dbo.GuestInformations", "BookingInformation_BookingId", "dbo.BookingInformations", "BookingId");
        }
    }
}
