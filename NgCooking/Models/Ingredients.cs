using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class Ingredients
    {
        public Ingredients()
        {
            Recettes = new HashSet<Recettes>();
        }

        [Key]
        public string id { get; set; }

        [StringLength(128)]
        public string category { get; set; }
        public string name { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public int calories { get; set; }



        //foreign key
        public virtual Categories Categories { get; set; }
        public virtual ICollection<Recettes> Recettes { get; set; }
    }
}