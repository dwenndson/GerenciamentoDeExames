using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GerenciamentoDeExames.Data;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Clinic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeExames.Controllers
{
    public class ClinicController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ClinicController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Clinic
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clinic/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clinic/Create
        [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Basic")]
        public async Task<ActionResult> Create(SaveClinicViewModel saveClinic)
        {
            try
            {
                var clinic = Mapper.Map<SaveClinicViewModel, Clinic>(saveClinic);
                var user = await _userManager.GetUserAsync(HttpContext.User);

                await _userManager.RemoveFromRoleAsync(user, "Basic");
                await _userManager.AddToRoleAsync(user, "Clinic");

                clinic.UserId = user.Id;
                _context.Clinic.Add(clinic);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clinic/Edit/5
        [Authorize(Roles = "Clinic")]
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var clinic = Mapper.Map<Clinic, SaveClinicViewModel>(_context.Clinic.Include(c => c.User).Where(c => c.UserId == user.Id).SingleOrDefault());
            return View(clinic);
        }

        // POST: Clinic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clinic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clinic/Delete/5
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