using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoHot.Model.Models
{
    [Table("DetailReservations")]
    public class DetailReservation
    {
        [Key]
        [Column(Order = 1)]
        public int ReservationID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int RoomID { set; get; }


        [ForeignKey("ReservationID")]
        public virtual Reservation Reservation { set; get; }

        [ForeignKey("RoomID")]
        public virtual Room Room { set; get; }

    }
}
