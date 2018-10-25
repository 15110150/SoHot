namespace SoHot_Data.Migrations
{
    using SoHot.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoHot_Data.SoHotDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoHot_Data.SoHotDBContext context)
        {
            Reservation reservation = new Reservation();
            Room room = new Room();

            room.RoomTypeID = 1;
            room.Name = "phong doi";
            room.Price = 0;
            room.Status = true;
            Room room1 = new Room();

            room1.RoomTypeID = 1;
            room1.Name = "phong don";
            room1.Price = 0;
            room1.Status = true;
            //reservation.Rooms.Add(room);
            //reservation.Rooms.Add(room1);
       
            reservation.CheckInDateTime = DateTime.Today;
            reservation.CheckOutDateTime = DateTime.Today;
            reservation.Quantity = 1;
            reservation.Price = 0;
            reservation.Total = 0;
            reservation.IsPaid = true;
            reservation.Status = true;
            reservation.CustomerID = 1;
            context.Reservations.Add(reservation);

        }

    }
}
