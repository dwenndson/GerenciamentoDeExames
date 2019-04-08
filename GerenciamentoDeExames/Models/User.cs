using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool IsActive { get; set; }
    }
}
