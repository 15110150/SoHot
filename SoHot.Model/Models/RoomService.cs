using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("RoomServices")]
    public class RoomService
    {
        [Key]
        [Column(Order = 1)]
        public int RoomID { set; get; }

        [Key]
        [Column(Order = 2)]
        public int ServiceID { set; get; }

        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        public bool Status { set; get; }

        [ForeignKey("RoomID")]
        public virtual Room Room { set; get; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { set; get; }
    }
}