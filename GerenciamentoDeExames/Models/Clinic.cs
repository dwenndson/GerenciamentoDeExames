using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Models
{
    public class Clinic
    {
        public Guid Id { get; set; }

        public string FirstPhone { get; set; }

        public string SecondPhone { get; set; }

        public string Cnpj { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
