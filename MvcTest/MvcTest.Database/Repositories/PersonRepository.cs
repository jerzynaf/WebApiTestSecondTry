using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MvcTest.Database.Interfaces;
using MvcTest.Database.Models;
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;

namespace MvcTest.Database.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly INhsContext _context;

        public PersonRepository(INhsContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.People.OrderBy(p => p.FirstName);
        }

        public Person GetPerson(int id)
        {
            return _context.People.Find(id);
        }

        public void UpdatePerson(PersonParameterModel personParameterModel)
        {
            var person = this.GetPerson(personParameterModel.PersonId);

            person.IsAuthorised = personParameterModel.IsAuthorised;
            person.IsEnabled = personParameterModel.IsEnabled;
            person.Colours.Clear();

            var pickedColours = personParameterModel.Colours.Where(c => c.IsChecked == true).Select(c => c.ColourId);

            for (int i = 0; i < pickedColours.Count(); i++)
            {
                var colour = _context.Colours.Find(pickedColours.ElementAt(i));
                person.Colours.Add(colour);
            }

            _context.SaveChanges();
        }

        public PersonViewModel GetPersonViewModel(int id)
        {
            var person = this.GetPerson(id);

            if (person == null)
            {
                return null;
            }

            var personViewModel = new PersonViewModel()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                IsAuthorised = person.IsAuthorised,
                IsEnabled = person.IsEnabled,
                IsValid = person.IsValid,
                Colours = new List<ColourViewModel>()
            };

            var allColours = _context.Colours.OrderBy(c => c.Name);
            var allColourViewModels = Mapper.Map<List<ColourViewModel>>(allColours);
            var favouriteColourIds = person.Colours.Select(c => c.ColourId);
            personViewModel = LoadColourViewModels(personViewModel, favouriteColourIds, allColourViewModels);

            return personViewModel;
        }

        private PersonViewModel LoadColourViewModels(PersonViewModel personViewModel,
            IEnumerable<int> favouriteColourIds, List<ColourViewModel> allColourViewModels)
        {
            for (int i = 0; i < allColourViewModels.Count; i++)
            {
                var tempColour = allColourViewModels.ElementAt(i);

                if (favouriteColourIds.Contains(tempColour.ColourId))
                {
                    tempColour.IsChecked = true;
                }

                personViewModel.Colours.Add(tempColour);
            }

            return personViewModel;
        }
    }
}