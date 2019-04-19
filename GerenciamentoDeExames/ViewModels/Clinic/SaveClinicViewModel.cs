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

        //[Required]
        //[Display(Name = "Nome da clínica")]
        //public string Name { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string FirstPhone { get; set; }

        [Display(Name = "Celular")]
        public string SecondPhone { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        public Guid UserId { get; set; }
    }
}
