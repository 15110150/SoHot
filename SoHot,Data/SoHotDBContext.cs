using Microsoft.AspNet.Identity.EntityFramework;
using SoHot.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace SoHot_Data
{
    public class SoHotDBContext : IdentityDbContext<ApplicationUser>
    {
        public SoHotDBContext() : base("KSConnectionSHTeam")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Bill> Bills { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Reservation> Reservations { set; get; }
        public DbSet<RoomTag> RoomTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<RoomService> RoomServices { set; get; }
        public DbSet<RoomType> RoomTypes { set; get; }
        public DbSet<Service> Services { set; get; }
        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }
        public DbSet<DetailReservation> DetailReservations { set; get; }

        public static SoHotDBContext Create()
        {
            return new SoHotDBContext();
        }

        //public DbSet<ContactDetail> ContactDetails { set; get; }
        // public DbSet<Feedback> Feedbacks { set; get; }

        //public DbSet<ApplicationGroup> ApplicationGroups { set; get; }
        //public DbSet<ApplicationRole> ApplicationRoles { set; get; }
        //public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }
        //public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }



        protected override void OnModelCreating(DbModelBuilder builder)
        {
            // Configure Student & StudentAddress entity
         
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");
        }
    }
}

