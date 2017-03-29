namespace Saturn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primerM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Nit = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Cellphone = c.Int(nullable: false),
                        Addres = c.String(),
                    })
                .PrimaryKey(t => t.ClientID)
                .Index(t => t.Nit, unique: true, name: "Client_Nit_Index");
            
            CreateTable(
                "dbo.Contratoes",
                c => new
                    {
                        ContratoID = c.Int(nullable: false, identity: true),
                        CodContrato = c.String(nullable: false, maxLength: 20),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        FechaIni = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Prorrogas",
                c => new
                    {
                        ProrrogaID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        FechaIni = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        ContratoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProrrogaID)
                .ForeignKey("dbo.Contratoes", t => t.ContratoID)
                .Index(t => t.ContratoID);
            
            CreateTable(
                "dbo.Polizas",
                c => new
                    {
                        PolizaID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                        FechaIni = c.DateTime(nullable: false),
                        ContratoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PolizaID)
                .ForeignKey("dbo.Contratoes", t => t.ContratoID)
                .Index(t => t.ContratoID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Polizas", "ContratoID", "dbo.Contratoes");
            DropForeignKey("dbo.Prorrogas", "ContratoID", "dbo.Contratoes");
            DropForeignKey("dbo.Contratoes", "ClientID", "dbo.Clients");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Polizas", new[] { "ContratoID" });
            DropIndex("dbo.Prorrogas", new[] { "ContratoID" });
            DropIndex("dbo.Contratoes", new[] { "ClientID" });
            DropIndex("dbo.Clients", "Client_Nit_Index");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Polizas");
            DropTable("dbo.Prorrogas");
            DropTable("dbo.Contratoes");
            DropTable("dbo.Clients");
        }
    }
}
