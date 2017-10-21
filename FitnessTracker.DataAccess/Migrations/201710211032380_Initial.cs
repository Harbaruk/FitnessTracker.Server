namespace FitnessTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excersices",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    KindOfSport = c.Int(nullable: false),
                    Type = c.Int(nullable: false),
                    Time = c.Int(),
                    Distance = c.Int(),
                    Weight = c.Int(),
                    Amount = c.Int(),
                    CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    Plan_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.Plan_Id)
                .Index(t => t.Plan_Id);

            CreateTable(
                "dbo.Plans",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Duration = c.Int(nullable: false),
                    Name = c.String(),
                    Owner_UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Owner_UserId, cascadeDelete: true)
                .Index(t => t.Owner_UserId);

            CreateTable(
                "dbo.UserProfiles",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Weight = c.Decimal(precision: 18, scale: 2),
                    Height = c.Int(nullable: false),
                    Sex = c.Int(nullable: false),
                    Age = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.ExpirationTokens",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    LastActivityDateTime = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Firstname = c.String(),
                    Lastname = c.String(),
                    Email = c.String(),
                    Role = c.Int(nullable: false),
                    Salt = c.String(),
                    Password = c.String(nullable: false),
                    Profile_UserId = c.Int(nullable: false),
                    Token_UserId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Profile_UserId, cascadeDelete: true)
                .ForeignKey("dbo.ExpirationTokens", t => t.Token_UserId)
                .Index(t => t.Profile_UserId)
                .Index(t => t.Token_UserId);

        }

        public override void Down()
        {
        }
    }
}
