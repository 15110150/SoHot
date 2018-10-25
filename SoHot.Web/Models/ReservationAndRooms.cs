using SoHot.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class ReservationAndRooms
    {
        public ReservationViewModel ReservationViewModel { get; set; }
        public List<Room> Rooms { get; set; }
    }
}