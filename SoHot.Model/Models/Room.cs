using SoHot.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("Rooms")]
    public class Room : Auditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public string Description { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [Column(TypeName = "xml")]
        public string MoreImages { set; get; }

        public decimal Price { set; get; }

        public string Tags { set; get; }

        public bool? HotFlag { set; get; }

        public int RoomTypeID { set; get; }

        public decimal? PromotionPrice { set; get; }


        public int? ViewCount { set; get; }

        [ForeignKey("RoomTypeID")]
        public virtual RoomType RoomType { set; get; }

        public virtual IEnumerable<DetailReservation> DetailReservations { set; get; }

    }
}