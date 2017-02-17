using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using NgCooking.Models;
using NgCooking.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels();                    
            EditionLastAndNewRecipes.MeilleuresRecettes(model.LastAndBest.lastRecipes);
            EditionLastAndNewRecipes.DernieresRecettes(model.LastAndBest.bestRecipes);            
            return View(model);
        }

        private void AddSecurityStamp()
        {
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public static void seeding()
        //{
        //    var db = new ApplicationDbContext();

        //    string json = "";
        //    using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\categories.json"))
        //    {
        //        json = r.ReadToEnd();
        //        dynamic array = JsonConvert.DeserializeObject(json);
        //        foreach (dynamic item in array)
        //        {
        //            var Cat = new Categories
        //            {
        //                id = item.id,
        //                nameToDisplay = item.nameToDisplay,
        //            };
        //            db.Categories.Add(Cat);
        //        }

        //    }

        //    using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\communaute.json"))
        //    {
        //        json = r.ReadToEnd();
        //        List<Communaute> ListUser = JsonConvert.DeserializeObject<List<Communaute>>(json);

        //        foreach (var Commu in ListUser)
        //        {
        //            db.Users.Add(Commu);
        //        }
        //    }

        //    using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\ingredients.json"))
        //    {
        //        json = r.ReadToEnd();
        //        List<Ingredients> ListIng = JsonConvert.DeserializeObject<List<Ingredients>>(json);
        //        foreach (var Ing in ListIng)
        //        {
        //            db.Ingredients.Add(Ing);
        //        }
        //        dynamic array = JsonConvert.DeserializeObject(json);
        //        foreach (dynamic item in array)
        //        {
        //            var Ing = new Ingredients();

        //            Ing.id = item.id;
        //            Ing.name = item.name;
        //            Ing.isAvailable = item.isAvailable;
        //            Ing.picture = item.picture;
        //            Ing.category = item.category.Value;
        //            Ing.calories = item.calories;

        //            db.Ingredients.Add(Ing);
        //        }

        //    }

        //    using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\recettes.json"))
        //    {
        //        json = r.ReadToEnd();
        //        List<Recettes> ListRecipes = JsonConvert.DeserializeObject<List<Recettes>>(json);

        //        foreach (var Recip in ListRecipes)
        //        {
        //            db.Recettes.Add(Recip);
        //        }
        //    }
        //    db.SaveChanges();




        //    using (StreamReader r = new StreamReader(@"C:\Users\C17 Developer\Documents\XavierProject\NgCooking\NgCooking\App_Data\Json\recettes.json"))
        //    {
        //        json = r.ReadToEnd();
        //        dynamic array = JsonConvert.DeserializeObject(json);
        //        foreach (dynamic item in array)
        //        {
        //            var com = new Comments
        //            {
        //                comment = item.comment,
        //                userId = item.userId,
        //                recettesId = item.id,
        //                title = item.title,
        //                mark = (int)item.mark
        //            };
        //            db.Comments.Add(com);
        //        }
        //        db.SaveChanges();
        //    }
        //}
    }

}

