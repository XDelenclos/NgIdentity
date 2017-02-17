using System.Collections.Generic;
using System.Web.Mvc;

namespace NgCooking.Models
{
    public class RecipesViewModels
    {
        public BestRecipeModel NewAndBest { get; set; } = new BestRecipeModel();
        public string Name { get; set; }
        public Recettes recette { get; set; }
        public MultiSelectList SelectIng { get; set; }
        public List<string> IngIDs { get; set; }
        public int CalorieMin { get; set; }
        public int CalorieMax { get; set; }
        public List<CommentsByUser> UsersComment { get; set; }
        public List<Recettes> Result { get; set; }
        public Dictionary<string, List<Recettes>> Index { get; set; }

        //pas encore utilisé
        //public int DisplayLimit { get; set; }
    }

    public class CommentsByUser
    {
        public Communaute Bloggers { get; set; }
        public Comments Commentaires { get; set; }
    }

}