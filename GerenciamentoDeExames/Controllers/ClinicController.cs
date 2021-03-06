﻿using System;
using System.Collections.Generic;
using System.IO;
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


        [Authorize(Roles = "Basic")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Basic")]
        public async Task<ActionResult> Create(SaveClinicViewModel saveClinic)
        {
            try
            {
                if (ModelState.IsValid)
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
                throw new Exception("Campos inválidos");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Clinic")]
        public async Task<ActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(Mapper.Map<SaveClinicViewModel>(await _context.Clinic.SingleOrDefaultAsync(c => c.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, SaveClinicViewModel saveClinic)
        {
            try
            {
                if(id != saveClinic.Id)
                {
                    return BadRequest();
                }

                if(ModelState.IsValid)
                {
                    var clinic = Mapper.Map<Clinic>(saveClinic);
                    _context.Clinic.Update(clinic);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                throw new Exception("Campos inválidos");
                
            }
            catch(DbUpdateException e)
            {
                return StatusCode(401, e.Message);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(Mapper.Map<SaveClinicViewModel>(await _context.Clinic.SingleOrDefaultAsync(c => c.UserId == user.Id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, SaveClinicViewModel saveClinic)
        {
            try
            {
                if(id != saveClinic.Id)
                {
                    return BadRequest();
                }

                var clinic = await _context.Clinic.SingleOrDefaultAsync(c => c.Id == id);
                clinic.IsActive = false;
                _context.Clinic.Update(clinic);
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