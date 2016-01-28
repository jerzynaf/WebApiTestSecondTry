using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using AutoMapper;
using MvcTest.Database.Repositories.Interfaces;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MvcTest.Web.Areas
{

    public class PeopleApiController : ApiController
    {
        private readonly IPersonRepository _personRepository;

        public PeopleApiController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public HttpResponseMessage GetPeopleViewModels()
        {
            var people = _personRepository.GetAllPeople();
            var peopleViewModels = Mapper.Map<List<PersonViewModel>>(people);

            return Request.CreateResponse(HttpStatusCode.OK, peopleViewModels, Configuration.Formatters.JsonFormatter);
        }

        [ResponseType(typeof(PersonViewModel))]
        public HttpResponseMessage GetPersonViewModel(int id)
        {
            var contact = _personRepository.GetPersonViewModel(id);
            if (contact == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, contact, Configuration.Formatters.JsonFormatter);
        }

        [ResponseType(typeof(void))]
        public HttpResponseMessage PutPersonViewModel(int id, PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != personViewModel.PersonId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var personParameterModel = Mapper.Map<PersonParameterModel>(personViewModel);
            _personRepository.UpdatePerson(personParameterModel);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}