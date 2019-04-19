using GerenciamentoDeExames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Clinic
{
    public class ClinicViewModel
    {
        public Guid Id { get; set; }

        public string FirstPhone { get; set; }

        public string SecondPhone { get; set; }

        public string Cnpj { get; set; }

        public User User { get; set; }
    }
}
