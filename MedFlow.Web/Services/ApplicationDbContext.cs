using MedFlow.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedFlow.Web.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var intern = new IdentityRole("intern");
            intern.NormalizedName = "intern";

            var doctor = new IdentityRole("doctor");
            doctor.NormalizedName = "doctor";

            builder.Entity<IdentityRole>().HasData(admin, intern, doctor);
        }
    }
}
