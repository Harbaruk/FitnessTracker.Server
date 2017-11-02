using FitnessTracker.DataAccess.Entity;
using System.Data.Entity.ModelConfiguration;

namespace FitnessTracker.DataAccess.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<ProductEntity>
    {
        public ProductConfiguration()
        {
            ToTable("Products");

            HasKey(x => x.Id);

            Property(x => x.Name);
            Property(x => x.Portion);
            Property(x => x.Calories);
        }
    }
}
