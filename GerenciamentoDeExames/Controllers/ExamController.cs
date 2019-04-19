using AutoMapper;
using GerenciamentoDeExames.Data;
using GerenciamentoDeExames.Models;
using GerenciamentoDeExames.ViewModels.Exam;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeExames.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _environment;

        public ExamController(ApplicationDbContext context, UserManager<User> userManager, IHostingEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        public async Task<ActionResult> Details(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(Mapper.Map<ExamViewModel>(await _context.Exam.SingleOrDefaultAsync(e => e.PacientId == user.Id && e.Id == id)));
        }
        
        [HttpGet("Index")]
        public async Task<ActionResult> Index(string field, Guid value)
        {
            try
            {
                if (field.ToLower() == "clinic".ToLower())
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    var clinic = await _context.Clinic.SingleOrDefaultAsync(c => c.UserId == user.Id);
                    return View(Mapper.Map<List<ExamViewModel>>(_context.Exam.Where(e => e.ClinicId == clinic.Id).OrderByDescending(e => e.DataEnviado)));
                }
                else if(field.ToLower() == "pacient".ToLower())
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    var pacient = await _context.Pacient.SingleOrDefaultAsync(c => c.UserId == user.Id);
                    return View(Mapper.Map<List<ExamViewModel>>(_context.Exam.Include(e => e.Pacient).Where(e => e.PacientId == pacient.Id).OrderByDescending(e => e.DataEnviado)));
                }
                else if(field.ToLower() == "customDoctor".ToLower())
                {
                    return View(Mapper.Map<List<ExamViewModel>>(_context.Exam.Include(e => e.Pacient).Where(e => e.PacientId == value).OrderByDescending(e => e.DataEnviado)));
                }
                else if(field.ToLower() == "doctor".ToLower())
                {
                    ViewBag.PacientId = new SelectList(_context.Pacient.Select(p => p.Id));
                    return View();
                }
                return NotFound();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: Exam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SaveExamViewModel saveExam, IFormFile pdf)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var clinic = await _context.Clinic.SingleOrDefaultAsync(c => c.UserId == user.Id);

                var filePath = _environment.WebRootPath + @"\pdf\";
                var fileName = Guid.NewGuid();
                var extension = Path.GetExtension(pdf.FileName);
                if (pdf.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(filePath, (fileName + extension)), FileMode.Create, FileAccess.Write))
                    {
                        await pdf.CopyToAsync(fileStream);
                    }
                }

                _context.Exam.Add(new Exam { ClinicId = clinic.Id, Title = saveExam.Title, Description = saveExam.Description,
                    PacientId = saveExam.PacientId, DataEnviado = DateTime.Now, ExamPath = @"pdf\" + fileName + extension});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }


        // GET: Exam/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.PacientId = new SelectList(_context.Pacient.Select(p => p.Id));
            return View(Mapper.Map<SaveExamViewModel>(await _context.Exam.SingleOrDefaultAsync(e => e.Id == id)));
        }

        // POST: Exam/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Exam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Exam/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}