using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class ReservationViewModel
    {

        public int ID { set; get; }

        public DateTime CheckInDateTime { get; set; }

        public DateTime CheckOutDateTime { get; set; }

        public string Note { get; set; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int CustomerID { set; get; }

        public int RoomID { get; set; }

        public decimal Total { get; set; }

        public decimal? Deposit { get; set; }

        public bool IsPaid { get; set; }

        public virtual RoomViewModel Room { set; get; }

        public virtual CustomerViewModel Customer { set; get; }
        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}