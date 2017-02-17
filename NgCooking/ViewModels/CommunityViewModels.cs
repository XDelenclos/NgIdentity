using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class CommunityViewModels
    {
        public List<BestCookers> BestCooker { get; set; }
        public Communaute User { get; set; }
        public List<Recettes> RecetteUser { get; set; }
        public List<Communaute> ListUser { get; set; }
        public User UserAge { get; set; }
    }

    public class User
    {
        public Communaute Utilisateur { get; set; }
        public int Age { get; set; }
    }

    public class BestCookers
    {
        public string UserRate { get; set; }
        public Communaute BestUser { get; set; }

    }

}