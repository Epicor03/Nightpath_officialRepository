namespace Nightpath.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EstablishmentID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                        PointsNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Establishments", t => t.EstablishmentID, cascadeDelete: true)
                .Index(t => t.EstablishmentID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Establishments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Schedule = c.String(),
                        NIF = c.Int(nullable: false),
                        Estab_OwnerID = c.Int(nullable: false),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estab_Owner", t => t.Estab_OwnerID, cascadeDelete: true)
                .ForeignKey("dbo.Regions", t => t.RegionID, cascadeDelete: true)
                .Index(t => t.Estab_OwnerID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Estab_Owner",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
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
                        UserId = c.String(nullable: false, maxLength: 128),
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
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Capacity = c.Int(nullable: false),
                        EstablishmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Establishments", t => t.EstablishmentID, cascadeDelete: true)
                .Index(t => t.EstablishmentID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        EventID = c.Int(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                        DistrictID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Districts", t => t.DistrictID, cascadeDelete: true)
                .Index(t => t.DistrictID);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Points", "EstablishmentID", "dbo.Establishments");
            DropForeignKey("dbo.Establishments", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Regions", "DistrictID", "dbo.Districts");
            DropForeignKey("dbo.Reviews", "EventID", "dbo.Events");
            DropForeignKey("dbo.Reviews", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Events", "EstablishmentID", "dbo.Establishments");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Estab_Owner", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clients", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Establishments", "Estab_OwnerID", "dbo.Estab_Owner");
            DropForeignKey("dbo.Points", "ClientID", "dbo.Clients");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Regions", new[] { "DistrictID" });
            DropIndex("dbo.Reviews", new[] { "ClientID" });
            DropIndex("dbo.Reviews", new[] { "EventID" });
            DropIndex("dbo.Events", new[] { "EstablishmentID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Estab_Owner", new[] { "User_Id" });
            DropIndex("dbo.Establishments", new[] { "RegionID" });
            DropIndex("dbo.Establishments", new[] { "Estab_OwnerID" });
            DropIndex("dbo.Points", new[] { "ClientID" });
            DropIndex("dbo.Points", new[] { "EstablishmentID" });
            DropIndex("dbo.Clients", new[] { "User_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Districts");
            DropTable("dbo.Regions");
            DropTable("dbo.Reviews");
            DropTable("dbo.Events");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Estab_Owner");
            DropTable("dbo.Establishments");
            DropTable("dbo.Points");
            DropTable("dbo.Clients");
        }
    }
}
