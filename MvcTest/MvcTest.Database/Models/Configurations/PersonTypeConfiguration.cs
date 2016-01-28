using System.Data.Entity.ModelConfiguration;

namespace MvcTest.Database.Models.Configurations
{
    public class PersonTypeConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonTypeConfiguration()
        {
            Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            Property(d => d.LastName).IsRequired().HasMaxLength(50);
        }
    }
}