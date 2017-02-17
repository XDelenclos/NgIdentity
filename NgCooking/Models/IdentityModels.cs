using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin.Security.Cookies;

namespace NgCooking.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe Communaute ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class Communaute : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>, IUser<int>
    {
        
        public Communaute()
        {
            Comments = new HashSet<Comments>();
            Recettes = new HashSet<Recettes>();
        }        
        public string firstname { get; set; }
        public string surname { get; set; }
        public int level { get; set; }
        public string picture { get; set; }
        public int birth { get; set; }
        public string bio { get; set; }
        public string city { get; set; }

        //foreign key
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Recettes> Recettes { get; set; }





        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Communaute, int> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }



    }
    public class ApplicationDbContext : IdentityDbContext<Communaute, CustomRole,
    int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("name=NgCookingIdentityContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Recettes> Recettes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Categories> Categories { get; set; }


    }

    //modification des classes pour la prise en charge de la clé (TKEY) en INT 
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<Communaute, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}