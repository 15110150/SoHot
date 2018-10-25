using SoHot.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("Reservations")]
    public class Reservation : Auditable
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }
        [MaxLength(500)]
        public string Note { get; set; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int CustomerID { set; get; }

        public decimal Total { get; set; }

        public decimal? Deposit { get; set; }

        public bool IsPaid { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { set; get; }

        public virtual IEnumerable<DetailReservation> DetailReservations { set; get; }


    }
}
