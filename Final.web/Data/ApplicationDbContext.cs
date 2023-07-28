using Final.web.Helpers;
using Final.web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final.web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Seeder.SeedUsers(builder)
            .SeedRoles(builder)
            .SeedUserRoles(builder);
        }





    }
    public class Seeder
    {
        public static Seeder SeedUsers(ModelBuilder builder)
        {
            try
            {

                User user = new User()
                {
                    Id = "b74ddd14-6340-4840-95c2-db12554843e9",
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    NormalizedEmail = "admin@gmail.com".ToUpper(),
                    NormalizedUserName = "Admin".ToUpper(),
                    EmailConfirmed = false,
                    UserType = Enums.UserType.Admin,

                };
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "Admin123");
                builder.Entity<User>().HasData(user);
                return new();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Seeder SeedRoles(ModelBuilder builder)
        {
            try
            {
                builder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = Constants.Roles.Admin, ConcurrencyStamp = "1", NormalizedName = Constants.Roles.Admin.ToUpper() }
                    );
                return new();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Seeder SeedUserRoles(ModelBuilder builder)
        {
            try
            {

                builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e9" }
                    );
                return new();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

