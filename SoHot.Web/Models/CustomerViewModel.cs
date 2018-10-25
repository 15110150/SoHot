using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoHot.Web.Models
{
    public class CustomerViewModel
    {
        public int ID { set; get; }

        public string Name { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public string PassportNumber { get; set; }

        public string FacebookID { get; set; }
        public DateTime? CreatedDate { set; get; }

        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

        public string UpdatedBy { set; get; }

        public bool Status { set; get; }
    }
}