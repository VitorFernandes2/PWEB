namespace ERecarga.Migrations
{
    using ERecarga.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ERecarga.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ERecarga.Models.ApplicationDbContext";
        }

        protected override void Seed(ERecarga.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "Owner", "User" };

            foreach(var roles in roleNames)
            {

                if (!roleManager.RoleExists(roles))
                {

                    var role = new IdentityRole();
                    role.Name = roles;
                    roleManager.Create(role);

                }

            }

            var user = new ApplicationUser { UserName = "admin@admin.com", Email = "admin@admin.com" };
            var admin = userManager.Create(user, "Admin");
            if (admin.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
