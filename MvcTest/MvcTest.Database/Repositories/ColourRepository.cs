using System.Collections.Generic;
using System.Linq;
using MvcTest.Database.Interfaces;
using MvcTest.Database.Models;
using MvcTest.Database.Repositories.Interfaces;

namespace MvcTest.Database.Repositories
{
    public class ColourRepository : IColourRepository
    {
        private readonly INhsContext _context;

        public ColourRepository(INhsContext context)
        {
            _context = context;
        }

        public IEnumerable<Colour> GetAllColours()
        {
            return _context.Colours.Where(c => c.IsEnabled == true);
        }

        public Colour GetColour(int id)
        {
            return _context.Colours.Find(id);
        }
    }
}