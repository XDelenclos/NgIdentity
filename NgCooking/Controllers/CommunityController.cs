using NgCooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NgCooking;

namespace NgCooking.Controllers
{
    public class CommunityController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Community
        public ActionResult Communaute()
        {

            CommunityViewModels model = new CommunityViewModels();
            model.BestCooker = new List<BestCookers>();
            model.ListUser = new List<Communaute>();
            MeilleurCuistot(model.BestCooker);
            IndexCooker("a completer", model.ListUser);
            return View(model);
        }

        // GET: Community/id 
        public ActionResult Details(int id)
        {
            CommunityViewModels model = new CommunityViewModels();
            model.User = new Communaute();
            model.UserAge = new User();
            model.RecetteUser = new List<Recettes>();
            RecetteUtilisateur(model.RecetteUser, id);
            DetailsUser(model.UserAge, id);
            model.User = db.Users.Find(id);
            return View(model);
        }


        private void MeilleurCuistot(List<BestCookers> bestCooker, int limit = 8)
        {
            List<Communaute> cooker = db.Users.OrderByDescending(c => c.level).Take(limit).ToList();
            foreach (var item in cooker)
            {
                switch (item.level)
                {
                    case 1:
                        bestCooker.Add(new BestCookers
                        {
                            BestUser = item,
                            UserRate = "Novice"
                        });
                        break;
                    case 2:
                        bestCooker.Add(new BestCookers
                        {
                            BestUser = item,
                            UserRate = "Expert"
                        });
                        break;
                    case 3:
                        bestCooker.Add(new BestCookers
                        {
                            BestUser = item,
                            UserRate = "Confirmé"
                        });
                        break;
                }
            }






        }


        //private void MeilleurCuistot(List<BestCookers> bestCooker,int limit = 8)
        //{
        //    List<Communaute> cooker = db.Communaute.SqlQuery<string>("",)         
        //    foreach (var item in cooker)
        //    {
        //        if (item.Comment.Count > 0)
        //            bestCooker.Add(new BestCookers
        //            {
        //                BestUser = item,
        //                UserRate = (double)item.Comment.Average(r => r.mark)
        //            });
        //        else
        //        {
        //            bestCooker.Add(new BestCookers
        //            {
        //                BestUser = item,
        //                UserRate = 0
        //            });
        //        }
        //    }
        //}
        private void DetailsUser(User user, int id)
        {
            int annee = db.Users.Find(id).birth;
            int age = (Convert.ToInt32(DateTime.Now.Year) - annee);
            user.Age = age;
            user.Utilisateur = db.Users.Find(id);
        }

        private void RecetteUtilisateur(List<Recettes> Rec, int id, int limit = 4)
        {
            List<Recettes> recipe = db.Recettes.Where(c => c.creatorId == id).Take(limit).ToList();
            foreach (var item in recipe)
            {
                Rec.Add(item);
            }
        }

        private void IndexCooker(string choix, List<Communaute> listUser, int limit = 8)
        {
            switch (choix)
            {
                case "az":
                    listUser = db.Users.OrderBy(r => r.surname).Take(limit).ToList();
                    break;
                case "za":
                    listUser = db.Users.OrderByDescending(r => r.surname).Take(limit).ToList();
                    break;
                case "exp":
                    listUser = db.Users.OrderBy(r => r.Comments.Average(c => c.mark)).Take(limit).ToList();
                    break;
                case "prod":
                    listUser = db.Users.OrderByDescending(c => c.Recettes.Count()).Take(limit).ToList();
                    break;
                case "prod_desc":
                    listUser = db.Users.OrderBy(c => c.Recettes.Count()).Take(limit).ToList();
                    break;
            }

        }

    }
}