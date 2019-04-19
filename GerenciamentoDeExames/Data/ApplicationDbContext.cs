using System;
using System.Collections.Generic;
using System.Text;
using GerenciamentoDeExames.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeExames.ViewModels.Clinic;
using GerenciamentoDeExames.ViewModels.Pacient;
using Microsoft.AspNetCore.Identity;
using GerenciamentoDeExames.ViewModels.Doctor;
using GerenciamentoDeExames.ViewModels.Exam;

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
        public DbSet<GerenciamentoDeExames.ViewModels.Pacient.SavePacientViewModel> SavePacientViewModel { get; set; }
        public DbSet<GerenciamentoDeExames.ViewModels.Pacient.PacientViewModel> PacientViewModel { get; set; }
        public DbSet<GerenciamentoDeExames.ViewModels.Doctor.SaveDoctorViewModel> SaveDoctorViewModel { get; set; }
        public DbSet<GerenciamentoDeExames.ViewModels.Clinic.SaveClinicViewModel> SaveClinicViewModel { get; set; }
        public DbSet<GerenciamentoDeExames.ViewModels.Exam.SaveExamViewModel> SaveExamViewModel { get; set; }
        public DbSet<GerenciamentoDeExames.ViewModels.Exam.ExamViewModel> ExamViewModel { get; set; }
    }
}
