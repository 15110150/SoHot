using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoHot.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public string FullName { set; get; }

 
        public string Address { set; get; }

        public DateTime? BirthDay { set; get; }

        //lớp user có sẵn
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual IEnumerable<Bill> Bills { set; get; }
    }
}

