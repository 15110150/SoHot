using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoHot.Web.Models
{
    public class RoomTypeViewModel
    {
     
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }

        public string Description { set; get; }

        public string Alias { set; get; }

        public string Image { set; get; }
        public int MaxPeople { set; get; }
        public decimal Price { set; get; }
        public virtual IEnumerable<RoomViewModel> Rooms { set; get; }
        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }
        [Required]
        public bool Status { set; get; }
    }
}