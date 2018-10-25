namespace SoHot_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableDetailRepo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationRooms", "Reservation_ID", "dbo.Reservations");
            DropForeignKey("dbo.ReservationRooms", "Room_ID", "dbo.Rooms");
            DropIndex("dbo.ReservationRooms", new[] { "Reservation_ID" });
            DropIndex("dbo.ReservationRooms", new[] { "Room_ID" });
            CreateTable(
                "dbo.DetailReservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReservationID, t.RoomID })
                .ForeignKey("dbo.Reservations", t => t.ReservationID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.ReservationID)
                .Index(t => t.RoomID);
            
            DropTable("dbo.ReservationRooms");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReservationRooms",
                c => new
                    {
                        Reservation_ID = c.Int(nullable: false),
                        Room_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_ID, t.Room_ID });
            
            DropForeignKey("dbo.DetailReservations", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.DetailReservations", "ReservationID", "dbo.Reservations");
            DropIndex("dbo.DetailReservations", new[] { "RoomID" });
            DropIndex("dbo.DetailReservations", new[] { "ReservationID" });
            DropTable("dbo.DetailReservations");
            CreateIndex("dbo.ReservationRooms", "Room_ID");
            CreateIndex("dbo.ReservationRooms", "Reservation_ID");
            AddForeignKey("dbo.ReservationRooms", "Room_ID", "dbo.Rooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ReservationRooms", "Reservation_ID", "dbo.Reservations", "ID", cascadeDelete: true);
        }
    }
}
