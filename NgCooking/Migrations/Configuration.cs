namespace NgCooking.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.IO;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<NgCooking.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.Users.AddOrUpdate(
            //  p => p.Id,
            //  new Communaute { surname = "Andrew Peters" },
            //  new Communaute { FullName = "Brice Lambson" },
            //  new Communaute { FullName = "Rowan Miller" }
            //);
            //

            //using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\categories.json"))
            //{
            //    json = r.ReadToEnd();
            //    dynamic array = JsonConvert.DeserializeObject(json);
            //    foreach (dynamic item in array)
            //    {
            //        context.Categories.AddOrUpdate(
            //            cat => cat.id, new Categories
            //            {
            //                id = item.id,
            //                nameToDisplay = item.nameToDisplay,
            //            });

            //    }
            //}
            string json = "";
            using (StreamReader r1 = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\communaute.json"))
            {
                json = r1.ReadToEnd();
                dynamic array1 = JsonConvert.DeserializeObject(json);
                CustomUserStore store = new CustomUserStore(context);
                Microsoft.AspNet.Identity.UserManager<Communaute, int> AddUser = new UserManager<Communaute, int>(store);

                foreach (dynamic item in array1)
                {
                    AddUser.Create(new Communaute()
                    {
                        SecurityStamp = Guid.NewGuid().ToString(),
                        firstname = item.firstname,
                        surname = item.surname,
                        level = item.level,
                        picture = item.picture,
                        birth = item.birth,
                        bio = item.bio,
                        city = item.city,
                        Email = item.email,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = true,
                        AccessFailedCount = 0,
                        UserName = item.email,
                    }, "C17c17/");

                    //context.Users.AddOrUpdate(
                    //    p => p.Id, new Communaute
                    //    {
                    //        //SecurityStamp = Guid.NewGuid().ToString(),
                    //        firstname = item.firstname,
                    //        surname = item.surname,
                    //        level = item.level,
                    //        picture = item.picture,
                    //        birth = item.birth,
                    //        bio = item.bio,
                    //        city = item.city,
                    //        Email = item.email,
                    //        EmailConfirmed = true,
                    //        PhoneNumberConfirmed = false,
                    //        TwoFactorEnabled = false,
                    //        LockoutEnabled = true,
                    //        AccessFailedCount = 0,
                    //        UserName = item.email,
                    //    });
                }
            }


            //using (StreamReader r2 = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\ingredients.json"))
            //{
            //    json = r2.ReadToEnd();
            //    dynamic array2 = JsonConvert.DeserializeObject(json);
            //    foreach (dynamic item in array2)
            //    {
            //        context.Ingredients.AddOrUpdate(x => x.id,
            //            new Ingredients()
            //            {
            //                id = item.id,
            //                name = item.name,
            //                isAvailable = item.isAvailable,
            //                picture = item.picture,
            //                calories = item.calories,
            //                category = item.category
            //            });
            //    }
            //}

            //using (StreamReader r3 = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\recettes.json"))
            //{
            //    json = r3.ReadToEnd();
            //    dynamic array3 = JsonConvert.DeserializeObject(json);
            //    foreach (dynamic item in array3)
            //    {
            //        context.Recettes.AddOrUpdate(x => x.id,
            //            new Recettes
            //            {
            //                id = item.id,
            //                name = item.name,
            //                creatorId = item.creatorId,
            //                isAvailable = item.isAvailable,
            //                picture = item.picture,
            //                calories = item.calories,
            //                preparation = item.preparation
            //            });
            //    }
            //}
            context.SaveChanges();
        }
    }
}

