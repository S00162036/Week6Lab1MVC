namespace S00162036Rad2017Mvc1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00162036Rad2017Mvc1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "S00162036Rad2017Mvc1.Models.ApplicationDbContext";
        }

        protected override void Seed(S00162036Rad2017Mvc1.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "ClubAdmin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "member" }
                );

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "S00162036@mail.itsligo.ie",
                    EmailConfirmed = true,
                    dateJoined = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    firstName = "Glenn",
                    surName = "Gilmartin",
                    PasswordHash = ps.HashPassword("Admin#1")
                });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "ITS FC Admin",
                    Email = "rad2017@outlook.com",
                    EmailConfirmed = true,
                    dateJoined = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    firstName = "Rad",
                    surName = "Paulner",
                    PasswordHash = ps.HashPassword("radP2017$1")
                });

            context.SaveChanges(); // Takes data and pushes it out to database

            // Searches database for the Admin email
            ApplicationUser admin = manager.FindByEmail("S00162036@mail.itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin", "member", "ClubAdmin" });
            }

        }
    }
}
