using AutoMapper;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Clinic;
using GerenciamentoDeExames.ViewModels.Doctor;
using GerenciamentoDeExames.ViewModels.Exam;
using GerenciamentoDeExames.ViewModels.Pacient;
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

            CreateMap<ClinicViewModel, Clinic>();
            CreateMap<Clinic, ClinicViewModel>();

            CreateMap<SavePacientViewModel, Pacient>();
            CreateMap<Pacient, SavePacientViewModel>();

            CreateMap<PacientViewModel, Pacient>();
            CreateMap<Pacient, PacientViewModel>();

            CreateMap<SaveDoctorViewModel, Doctor>();
            CreateMap<Doctor, SaveDoctorViewModel>();

            CreateMap<SaveExamViewModel, Exam>();
            CreateMap<Exam, SaveExamViewModel>()
                .ForMember(e => e.ExamPath, opt => opt.Ignore());
        }
    }
}
