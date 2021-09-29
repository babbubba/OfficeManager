using AutoMapper;
using OfficeManager.Interfaces;
using OfficeManager.Models;
using OfficeManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeManager
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<IPersonModel, IPersonViewModel>()
                .IncludeAllDerived()
                .As<PersonViewModel>();

            CreateMap<IPersonViewModel, IPersonModel>()
              .IncludeAllDerived()
              .As<PersonModel>();
        }
    }
}
