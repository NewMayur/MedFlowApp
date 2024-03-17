using MedFlow.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedFlow.Web.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    var admin = new IdentityRole("admin");
        //    admin.NormalizedName = "admin";

        //    var intern = new IdentityRole("intern");
        //    intern.NormalizedName = "intern";

        //    var doctor = new IdentityRole("doctor");
        //    doctor.NormalizedName = "doctor";

        //    builder.Entity<IdentityRole>().HasData(admin, intern, doctor);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define custom roles
            var adminRole = new ApplicationRole
            {
                Name = "admin",
                NormalizedName = "admin",
                CanCreateTask = true,   // Example values for custom properties
                CanAssignTask = true    // Example values for custom properties
            };

            var internRole = new ApplicationRole
            {
                Name = "intern",
                NormalizedName = "intern",
                CanCreateTask = false,  // Example values for custom properties
                CanAssignTask = false   // Example values for custom properties
            };

            var doctorRole = new ApplicationRole
            {
                Name = "doctor",
                NormalizedName = "doctor",
                CanCreateTask = true,   // Example values for custom properties
                CanAssignTask = false   // Example values for custom properties
            };

            // Add custom roles to the database
            builder.Entity<ApplicationRole>().HasData(adminRole, internRole, doctorRole);

            // Configure custom role properties
            builder.Entity<ApplicationRole>(b =>
            {
                b.Property(r => r.CanCreateTask).IsRequired();
                b.Property(r => r.CanAssignTask).IsRequired();
            });
        }

    }
}
