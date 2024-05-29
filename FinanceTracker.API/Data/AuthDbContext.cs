using FinanceTracker.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var userRoleId = "8c95b8af-c8f9-42ff-8870-70838b59b79as";
            var adminRoleId = "fbae08af-ff34-432e-8002-1382e0122927";

            // Create User and Admin Roles:
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = userRoleId
                },
                new IdentityRole()
                {
                    Id= adminRoleId,
                    Name= "Admin",
                    NormalizedName = "Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create an AdminUser
            var adminUserId = "d698bb4d-6065-476b-b323-58ba34b961a0";
            var adminUser = new ApplicationUser()
            {
                Id = adminUserId,
                UserName = "yairmalka9@gmail.com",
                Email = "yairmalka9@gmail.com",
                NormalizedEmail = "yairmalka9@gmail.com".ToUpper(),
                NormalizedUserName = "yairmalka9@gmail.com".ToUpper(),
                FirstName = "Yair",
                LastName = "Malka"

            };

            adminUser.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(adminUser, "Dispatch2024@");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            //Give roles to AdminUser:

            var adminUserRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId,
                },

                new()
                {
                    UserId = adminUserId,
                    RoleId = userRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminUserRoles);
        }
    }
}
