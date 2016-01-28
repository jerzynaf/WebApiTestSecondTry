using System.Collections.Generic;
using MvcTest.Database.Models;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;

namespace MvcTest.Database.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPerson(int id);
        PersonViewModel GetPersonViewModel(int id);
        void UpdatePerson(PersonParameterModel personParameterModel);
    }
}