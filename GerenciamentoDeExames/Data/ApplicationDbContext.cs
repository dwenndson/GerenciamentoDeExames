using System;
using System.Collections.Generic;
using System.Text;
using GerenciamentoDeExames.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeExames.ViewModels.Clinic;
using GerenciamentoDeExames.ViewModels.Pacient;
using Microsoft.AspNetCore.Identity;

namespace GerenciamentoDeExames.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Pacient> Pacient { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
    }
}
