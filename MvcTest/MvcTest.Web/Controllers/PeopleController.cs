using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MvcTest.Database.Models;
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var people = _personRepository.GetAllPeople();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);

            return View(peopleViewModels);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var personViewModel = _personRepository.GetPersonViewModel(id);

            return View(personViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdatePerson(personViewModel);
                return RedirectToAction("Index");
            }

            return View(personViewModel);
        }

        private void UpdatePerson(PersonViewModel personViewModel)
        {
            var personParameterModel = Mapper.Map<PersonParameterModel>(personViewModel);
            _personRepository.UpdatePerson(personParameterModel);
        }
    }
}