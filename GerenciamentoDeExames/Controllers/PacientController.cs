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

        // GET: Pacient
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pacient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pacient/Create
        [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Basic")]
        public async Task<ActionResult> Create(SavePacientViewModel savePacient)
        {
            try
            {
                var pacient = Mapper.Map<SavePacientViewModel, Pacient>(savePacient);
                var user = await _userManager.GetUserAsync(HttpContext.User);

                await _userManager.RemoveFromRoleAsync(user, "Basic");
                await _userManager.AddToRoleAsync(user, "Pacient");

                _context.Pacient.Add(pacient);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacient/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Pacient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SavePacientViewModel savePacient)
        {
            try
            {
                var pacient = Mapper.Map<SavePacientViewModel, Pacient>(savePacient);
                var user = await _userManager.GetUserAsync(HttpContext.User);

                _context.Pacient.Update(pacient);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pacient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}