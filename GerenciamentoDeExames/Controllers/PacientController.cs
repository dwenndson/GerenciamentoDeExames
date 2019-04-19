using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciamentoDeExames.Data;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Pacient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeExames.Controllers
{
    public class PacientController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PacientController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Basic")]
        public async Task<ActionResult> Create(SavePacientViewModel savePacient)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var pacient = Mapper.Map<Pacient>(savePacient);
                    var user = await _userManager.GetUserAsync(HttpContext.User);

                    await _userManager.RemoveFromRoleAsync(user, "Basic");
                    await _userManager.AddToRoleAsync(user, "Pacient");

                    pacient.UserId = user.Id;
                    _context.Pacient.Add(pacient);
                    await _context.SaveChangesAsync();

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
            return View(Mapper.Map<SavePacientViewModel>(await _context.Pacient.SingleOrDefaultAsync(p => p.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SavePacientViewModel savePacient)
        {
            try
            {
                if(id != savePacient.Id)
                {
                    return BadRequest();
                }

                if(ModelState.IsValid)
                {
                    var pacient = Mapper.Map<Pacient>(savePacient);

                    _context.Pacient.Update(pacient);
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
            return View(Mapper.Map<SavePacientViewModel>(await _context.Pacient.SingleOrDefaultAsync(p => p.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, SavePacientViewModel savePacient)
        {
            try
            {
                if (id != savePacient.Id)
                {
                    return BadRequest();
                }

                var pacient = await _context.Pacient.SingleOrDefaultAsync(c => c.Id == id);
                pacient.IsActive = false;
                _context.Pacient.Update(pacient);
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