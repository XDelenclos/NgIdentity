using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class Categories
    {
        public Categories()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        [Key]
        public string id { get; set; }
        public string nameToDisplay { get; set; }

        //foreign key
        public virtual ICollection<Ingredients> Ingredients { get; set; }

    }
}