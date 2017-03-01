using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace MiContact.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Email> Emails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Social> Social { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BasicInfo> BasicInfos { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<AspNetUsersProfile> AspNetUsersProfiles { get; set; }
        public DbSet<AspNetUsersImages> AspNetUsersImagess { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}