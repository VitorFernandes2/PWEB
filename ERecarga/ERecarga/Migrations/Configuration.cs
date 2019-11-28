namespace ERecarga.Migrations
{
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

        }
    }
}
