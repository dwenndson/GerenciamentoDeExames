using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Models
{
    public class Exam
    {
        public Guid Id { get; set; }

        public Guid ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public Guid PacientId { get; set; }
        public Pacient Pacient { get; set; }

        public string ExamPath { get; set; }

        public DateTime DataPedido { get; set; }

        public DateTime DataEnviado { get; set; }

        public DateTime DataConfirmado { get; set; }
    }
}
