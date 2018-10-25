using SoHot.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("RoomTypes")]
    public class RoomType : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        public int MaxPeople { set; get; }

        public decimal Price { set; get; }

        public virtual IEnumerable<Room> Rooms { set; get; }

    }
}