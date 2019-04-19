using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Crm { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
