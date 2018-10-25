using SoHot.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("Bills")]
    public class Bill : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int RoomID { get; set; }

        public int CustomerID { set; get; }

        public decimal Total { get; set; }

        [ForeignKey("RoomID")]
        public virtual Room Room { set; get; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { set; get; }
    }
}