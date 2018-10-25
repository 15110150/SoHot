using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class RoomServiceViewModel
    {
       
        public int RoomID { set; get; }

        public int ServiceID { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public bool Status { set; get; }

        public virtual RoomViewModel Room { set; get; }

        public virtual ServiceViewModel Service { set; get; }
    }
}