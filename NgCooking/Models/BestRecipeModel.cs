using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class BestRecipeModel
    {
        public List<BestRecipes> lastRecipes { get; set; } = new List<BestRecipes>();
        public List<BestRecipes> bestRecipes { get; set; } = new List<BestRecipes>();

        public class BestRecipes
        {
            public decimal rate { get; set; }
            public Recettes bestRecette { get; set; }
        }
    }
}