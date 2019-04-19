using GerenciamentoDeExames.ViewModels.Clinic;
using GerenciamentoDeExames.ViewModels.Pacient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Exam
{
    public class SaveExamViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Id do paciente")]
        public Guid PacientId { get; set; }
        public PacientViewModel Pacient { get; set; }

        public Guid ClinicId { get; set; }
        public ClinicViewModel Clinic { get; set; }

        [NotMapped]
        public IFormFile ExamPath { get; set; }

        [Display(Name = "Data de Enviado")]
        [DataType(DataType.Date)]
        public DateTime DataEnviado { get; set; }

        public DateTime DataConfirmado { get; set; }
    }
}
