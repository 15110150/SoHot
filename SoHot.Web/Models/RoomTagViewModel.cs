using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class RoomTagViewModel
    {
       
        public int RoomID { set; get; }

        public string TagID { set; get; }

        public virtual RoomViewModel Room { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}