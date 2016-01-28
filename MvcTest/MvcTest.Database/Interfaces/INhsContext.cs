using System.Data.Entity;
using MvcTest.Database.Models;

namespace MvcTest.Database.Interfaces
{
    public interface INhsContext
    {
        DbSet<Colour> Colours { get; set; }
        DbSet<Person> People { get; set; }

        int SaveChanges();
    }
}