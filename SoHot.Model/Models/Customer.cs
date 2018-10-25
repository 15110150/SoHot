using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoHot.Model.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required]
        [MaxLength(50)]
        public string Phone { set; get; }

        [MaxLength(50)]
        public string Email { set; get; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public string PassportNumber { get; set; }

        public string FacebookID { get; set; }
        public DateTime? CreatedDate { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        [MaxLength(256)]
        public string UpdatedBy { set; get; }

        public bool Status { set; get; }
    }
}