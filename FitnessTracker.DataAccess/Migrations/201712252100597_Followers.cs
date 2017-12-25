namespace FitnessTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Followers : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Plans", name: "Owner_UserId", newName: "Owner_Id");
            RenameIndex(table: "dbo.Plans", name: "IX_Owner_UserId", newName: "IX_Owner_Id");
            CreateTable(
                "dbo.PlanEntityUserEntities",
                c => new
                {
                    PlanEntity_Id = c.Int(nullable: false),
                    UserEntity_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.PlanEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.Plans", t => t.PlanEntity_Id)
                .ForeignKey("dbo.Users", t => t.UserEntity_Id)
                .Index(t => t.PlanEntity_Id)
                .Index(t => t.UserEntity_Id);

            AddColumn("dbo.Exercises", "Name", c => c.String());
            AddColumn("dbo.Plans", "Description", c => c.String());
            AddColumn("dbo.Plans", "Type", c => c.String());
            DropColumn("dbo.Exercises", "KindOfSport");
            DropColumn("dbo.Exercises", "Type");
            DropColumn("dbo.Plans", "Duration");
        }

        public override void Down()
        {
            AddColumn("dbo.Plans", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "KindOfSport", c => c.Int(nullable: false));
            DropForeignKey("dbo.PlanEntityUserEntities", "UserEntity_Id", "dbo.Users");
            DropForeignKey("dbo.PlanEntityUserEntities", "PlanEntity_Id", "dbo.Plans");
            DropIndex("dbo.PlanEntityUserEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.PlanEntityUserEntities", new[] { "PlanEntity_Id" });
            DropColumn("dbo.Plans", "Type");
            DropColumn("dbo.Plans", "Description");
            DropColumn("dbo.Exercises", "Name");
            DropTable("dbo.PlanEntityUserEntities");
            RenameIndex(table: "dbo.Plans", name: "IX_Owner_Id", newName: "IX_Owner_UserId");
            RenameColumn(table: "dbo.Plans", name: "Owner_Id", newName: "Owner_UserId");
        }
    }
}