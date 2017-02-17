using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NgCooking.Models
{
    public class Comments
    {
        [Key]
        public int id { get; set; }

        [StringLength(128)]
        public string recettesId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string comment { get; set; }
        public int mark { get; set; }



        //foreign key
        public virtual Communaute user { get; set; }
        public virtual Recettes recettes { get; set; }
    }
}