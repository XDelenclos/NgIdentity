using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class Recettes
    {
        public Recettes()
        {
            Comments = new HashSet<Comments>();
            Ingredients = new HashSet<Ingredients>();
        }
        [Key]
        public string id { get; set; }
        public int creatorId { get; set; }
        public string name { get; set; }
        public bool isAvailable { get; set; }
        public string picture { get; set; }
        public int calories { get; set; }
        public string preparation { get; set; }


        //foreign key
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual Communaute creator { get; set; }
        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}