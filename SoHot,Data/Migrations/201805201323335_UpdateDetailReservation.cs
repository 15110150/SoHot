namespace SoHot_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDetailReservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reservations", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "RoomID" });
            CreateTable(
                "dbo.ReservationRooms",
                c => new
                    {
                        Reservation_ID = c.Int(nullable: false),
                        Room_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_ID, t.Room_ID })
                .ForeignKey("dbo.Reservations", t => t.Reservation_ID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.Room_ID, cascadeDelete: true)
                .Index(t => t.Reservation_ID)
                .Index(t => t.Room_ID);
            
            AddColumn("dbo.RoomTypes", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Reservations", "RoomID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "RoomID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReservationRooms", "Room_ID", "dbo.Rooms");
            DropForeignKey("dbo.ReservationRooms", "Reservation_ID", "dbo.Reservations");
            DropIndex("dbo.ReservationRooms", new[] { "Room_ID" });
            DropIndex("dbo.ReservationRooms", new[] { "Reservation_ID" });
            DropColumn("dbo.RoomTypes", "Price");
            DropTable("dbo.ReservationRooms");
            CreateIndex("dbo.Reservations", "RoomID");
            AddForeignKey("dbo.Reservations", "RoomID", "dbo.Rooms", "ID", cascadeDelete: true);
        }
    }
}
