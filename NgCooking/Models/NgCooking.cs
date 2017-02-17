//namespace NgCooking.Models
//{
//    using System;
//    using System.Data.Entity;
//    using System.Linq;

//    public class NgCooking : DbContext
//    {
//        // Votre contexte a été configuré pour utiliser une chaîne de connexion « NgCooking » du fichier 
//        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
//        // la base de données « NgCooking.Models.NgCooking » sur votre instance LocalDb. 
//        // 
//        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
//        // la chaîne de connexion « NgCooking » dans le fichier de configuration de l'application.
//        public NgCooking()
//            : base("name=NgCooking")
//        {
//        }

//        public virtual DbSet<Ingredients> Ingredients { get; set; }
//        public virtual DbSet<Recettes> Recettes { get; set; }
//        public virtual DbSet<Comments> Comments { get; set; }
//        public virtual DbSet<Categories> Categories { get; set; }


//        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
//        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

//        // public virtual DbSet<MyEntity> MyEntities { get; set; }
//    }

//    //public class MyEntity
//    //{
//    //    public int Id { get; set; }
//    //    public string Name { get; set; }
//    //}
//}