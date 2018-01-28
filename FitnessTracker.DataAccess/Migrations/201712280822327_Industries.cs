namespace FitnessTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Industries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndustryEntities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.IndustryEntityUserEntities",
                c => new
                {
                    IndustryEntity_Id = c.Int(nullable: false),
                    UserEntity_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.IndustryEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.IndustryEntities", t => t.IndustryEntity_Id)
                .ForeignKey("dbo.Users", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.IndustryEntity_Id)
                .Index(t => t.UserEntity_Id);

            AddColumn("dbo.Users", "IsApproved", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.IndustryEntityUserEntities", "UserEntity_Id", "dbo.Users");
            DropForeignKey("dbo.IndustryEntityUserEntities", "IndustryEntity_Id", "dbo.IndustryEntities");
            DropIndex("dbo.IndustryEntityUserEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.IndustryEntityUserEntities", new[] { "IndustryEntity_Id" });
            DropColumn("dbo.Users", "IsApproved");
            DropTable("dbo.IndustryEntityUserEntities");
            DropTable("dbo.IndustryEntities");
        }
    }
}