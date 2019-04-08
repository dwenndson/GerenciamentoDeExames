using AutoMapper;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SaveClinicViewModel, Clinic>();
            CreateMap<Clinic ,SaveClinicViewModel>();
        }
    }
}
