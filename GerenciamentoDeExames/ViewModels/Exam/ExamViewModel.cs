using GerenciamentoDeExames.ViewModels.Clinic;
using GerenciamentoDeExames.ViewModels.Pacient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Exam
{
    public class ExamViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public ClinicViewModel Clinic { get; set; }

        public PacientViewModel Pacient { get; set; }

        public string ExamPath { get; set; }

        [Display(Name = "Data de Enviado")]
        [DataType(DataType.Date)]
        public DateTime DataEnviado { get; set; }

        public DateTime DataConfirmado { get; set; }
    }
}
