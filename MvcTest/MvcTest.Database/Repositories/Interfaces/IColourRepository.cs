using System.Collections.Generic;
using MvcTest.Database.Models;

namespace MvcTest.Database.Repositories.Interfaces
{
    public interface IColourRepository
    {
        IEnumerable<Colour> GetAllColours();
        Colour GetColour(int id);
    }
}