using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.ViewModels.Clinic
{
    public class SaveClinicViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Telefone")]
        public string FirstPhone { get; set; }

        [Display(Name = "Celular")]
        public string SecondPhone { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }
    }
}
