using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class RoomViewModel
    {
        
        public int ID { set; get; }

        public string Name { set; get; }

        private bool IsAvailable { set; get; }

        public string Description { set; get; }

        public string Image { set; get; }

        public string MoreImages { set; get; }

        public decimal Price { set; get; }

        public string Tags { set; get; }

        public bool? HotFlag { set; get; }

        public int RoomTypeID { set; get; }

        public decimal? PromotionPrice { set; get; }

        public int? ViewCount { set; get; }

        public virtual RoomTypeViewModel RoomType { set; get; }

        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }

        public bool Status { set; get; }
    }
}