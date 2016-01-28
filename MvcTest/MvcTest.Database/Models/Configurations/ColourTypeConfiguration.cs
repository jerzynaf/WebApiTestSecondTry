using System.Data.Entity.ModelConfiguration;

namespace MvcTest.Database.Models.Configurations
{
    public class ColourTypeConfiguration : EntityTypeConfiguration<Colour>
    {
        public ColourTypeConfiguration()
        {
            Property(d => d.Name).IsRequired().HasMaxLength(50);
            HasMany(e => e.People)
                .WithMany(e => e.Colours)
                .Map(m => m.ToTable("FavouriteColours").MapLeftKey("ColourId").MapRightKey("PersonId"));
        }
    }
}