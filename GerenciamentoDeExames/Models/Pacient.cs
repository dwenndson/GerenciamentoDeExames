using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Models
{
    public class Pacient
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Cpf { get; set; }
    }
}
