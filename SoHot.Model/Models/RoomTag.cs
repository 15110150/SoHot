﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("RoomTag")]
    public class RoomTag
    {
        [Key]
        [Column(Order = 1)]
        public int RoomID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("RoomID")]
        public virtual Room Room { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}