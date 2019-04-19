using GerenciamentoDeExames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Pacient
{
    public class PacientViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cpf { get; set; }

        public User User { get; set; }
    }
}
