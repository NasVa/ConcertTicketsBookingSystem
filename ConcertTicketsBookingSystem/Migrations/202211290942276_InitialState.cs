namespace ConcertTicketsBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialState : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Concerts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        performer = c.String(),
                        ticketsNum = c.Int(nullable: false),
                        dataTime = c.DateTime(nullable: false),
                        address = c.String(),
                        voiceType = c.String(),
                        compositor = c.String(),
                        path = c.String(),
                        headliner = c.String(),
                        ageLimit = c.Byte(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PromoCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ConcertId = c.Int(nullable: false),
                        ProcentNum = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concerts", t => t.ConcertId, cascadeDelete: true)
                .Index(t => t.ConcertId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConcertId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Concerts", t => t.ConcertId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.ConcertId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        UserName = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "ConcertId", "dbo.Concerts");
            DropForeignKey("dbo.PromoCodes", "ConcertId", "dbo.Concerts");
            DropIndex("dbo.Tickets", new[] { "OwnerId" });
            DropIndex("dbo.Tickets", new[] { "ConcertId" });
            DropIndex("dbo.PromoCodes", new[] { "ConcertId" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.PromoCodes");
            DropTable("dbo.Concerts");
            DropTable("dbo.Admins");
        }
    }
}
