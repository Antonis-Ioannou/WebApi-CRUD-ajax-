namespace Project.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Project.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Product p1 = new Product("Bananas", 5);
            Product p2 = new Product("Apples", 3);
            Product p3 = new Product("Kiwis", 4);
            Product p4 = new Product("Strawberries", 7);
            Product p5 = new Product("Grapes", 6);
            context.Product.AddOrUpdate( x=> x.Name, p1, p2, p3, p4, p5 );
            context.SaveChanges();


            //create roles
            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(x => x.Name == "Subscriber"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Subscriber" };
                manager.Create(role);
            }

            //adding users
            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1!")
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(x => x.UserName == "antonis@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "antonis@gmail.com",
                    Email = "antonis@gmail.com",
                    PasswordHash = PasswordHash.HashPassword("Admin1!")
                };
                manager.Create(user);
                manager.AddToRole(user.Id, "Subscriber");
            }

        }
    }
}
 