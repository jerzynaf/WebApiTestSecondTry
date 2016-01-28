using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using MvcTest.Database.Interfaces;
using MvcTest.Database.Models;

namespace MvcTest.Database
{
    public class NhsContext : DbContext, INhsContext
    {
        private readonly EntityTypeConfiguration<Person> _personTypeConfiguration;
        private readonly EntityTypeConfiguration<Colour> _colourTypeConfiguration;

        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Person> People { get; set; }

        public NhsContext()
        {
        }

        public NhsContext(EntityTypeConfiguration<Person> personTypeConfiguration,
            EntityTypeConfiguration<Colour> colourTypeConfiguration)
            : base("name=NhsContext")
        {
            _personTypeConfiguration = personTypeConfiguration;
            _colourTypeConfiguration = colourTypeConfiguration;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(_personTypeConfiguration);
            modelBuilder.Configurations.Add(_colourTypeConfiguration);
        }
    }
}