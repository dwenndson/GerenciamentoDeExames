using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Pacient
{
    public class SavePacientViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }
    }
}
