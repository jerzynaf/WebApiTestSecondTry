using System.Collections.Generic;
using AutoMapper;
using MvcTest.Database;
using MvcTest.Database.Models;
using MvcTest.Database.Models.Configurations;
using MvcTest.Database.Repositories;
using MvcTest.Database.Repositories.ParameterModels;
using MvcTest.Models.ViewModels;

namespace MvcTest.Web
{
    public class PersonProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Person, PersonViewModel>();
            Mapper.CreateMap<PersonViewModel, Person>();
            Mapper.CreateMap<PersonViewModel, PersonParameterModel>();
        }
    }
}