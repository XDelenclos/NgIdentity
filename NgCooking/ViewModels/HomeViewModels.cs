using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NgCooking.Tools;

namespace NgCooking.Models
{
    public class HomeViewModels
    {
        public BestRecipeModel LastAndBest { get; set; } = new BestRecipeModel();
        public LoginViewModel Auth { get; set; } = new LoginViewModel();
    }


    
}