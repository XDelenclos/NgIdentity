namespace NgCooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        nameToDisplay = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        category = c.String(maxLength: 128),
                        name = c.String(),
                        isAvailable = c.Boolean(nullable: false),
                        picture = c.String(),
                        calories = c.Int(nullable: false),
                        Categories_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.Categories_id)
                .Index(t => t.Categories_id);
            
            CreateTable(
                "dbo.Recettes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        creatorId = c.Int(nullable: false),
                        name = c.String(),
                        isAvailable = c.Boolean(nullable: false),
                        picture = c.String(),
                        calories = c.Int(nullable: false),
                        preparation = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.creatorId, cascadeDelete: true)
                .Index(t => t.creatorId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        recettesId = c.String(maxLength: 128),
                        userId = c.Int(nullable: false),
                        title = c.String(),
                        comment = c.String(),
                        mark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Recettes", t => t.recettesId)
                .ForeignKey("dbo.AspNetUsers", t => t.userId, cascadeDelete: true)
                .Index(t => t.recettesId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        surname = c.String(),
                        level = c.Int(nullable: false),
                        picture = c.String(),
                        birth = c.Int(nullable: false),
                        bio = c.String(),
                        city = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RecettesIngredients",
                c => new
                    {
                        Recettes_id = c.String(nullable: false, maxLength: 128),
                        Ingredients_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Recettes_id, t.Ingredients_id })
                .ForeignKey("dbo.Recettes", t => t.Recettes_id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredients_id, cascadeDelete: true)
                .Index(t => t.Recettes_id)
                .Index(t => t.Ingredients_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecettesIngredients", "Ingredients_id", "dbo.Ingredients");
            DropForeignKey("dbo.RecettesIngredients", "Recettes_id", "dbo.Recettes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recettes", "creatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "recettesId", "dbo.Recettes");
            DropForeignKey("dbo.Ingredients", "Categories_id", "dbo.Categories");
            DropIndex("dbo.RecettesIngredients", new[] { "Ingredients_id" });
            DropIndex("dbo.RecettesIngredients", new[] { "Recettes_id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "userId" });
            DropIndex("dbo.Comments", new[] { "recettesId" });
            DropIndex("dbo.Recettes", new[] { "creatorId" });
            DropIndex("dbo.Ingredients", new[] { "Categories_id" });
            DropTable("dbo.RecettesIngredients");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Recettes");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Categories");
        }
    }
}
