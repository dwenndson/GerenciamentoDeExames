using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciamentoDeExames.Data;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeExames.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public DoctorController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaveDoctorViewModel saveDoctor)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var doctor = Mapper.Map<SaveDoctorViewModel, Doctor>(saveDoctor);
                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    await _userManager.RemoveFromRoleAsync(user, "Basic");
                    await _userManager.AddToRoleAsync(user, "Doctor");

                    doctor.UserId = user.Id;
                    _context.Doctor.Add(doctor);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                throw new Exception("Campos inválidos");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(Mapper.Map<SaveDoctorViewModel>(await _context.Doctor.SingleOrDefaultAsync(c => c.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SaveDoctorViewModel saveDoctor)
        {
            try
            {
                if (id != saveDoctor.Id)
                {
                    return BadRequest();
                }

                if(ModelState.IsValid)
                {
                    var doctor = Mapper.Map<Doctor>(saveDoctor);

                    _context.Doctor.Update(doctor);
                    _context.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                throw new Exception("Campos inválidos");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(Mapper.Map<SaveDoctorViewModel>(await _context.Doctor.SingleOrDefaultAsync(c => c.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, SaveDoctorViewModel saveDoctor)
        {
            try
            {
                if (id != saveDoctor.Id)
                {
                    return BadRequest();
                }

                var doctor = await _context.Doctor.SingleOrDefaultAsync(c => c.Id == id);
                doctor.IsActive = false;
                _context.Doctor.Update(doctor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}