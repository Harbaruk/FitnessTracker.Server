namespace FitnessTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    KilometersRun = c.Decimal(nullable: false, precision: 18, scale: 2),
                    CaloriesBurned = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TypeOfDiet = c.Int(nullable: false),
                    DaysOnDiet = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {

        }
    }
}
