using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaProfessoresAlunos.DAL;
using SistemaProfessoresAlunos.Entidades;
using SistemaProfessoresAlunos.Models;

namespace SistemaProfessoresAlunos.Controllers
{
    public class ProfessorController : Controller
    {
        protected ApplicationDbContext mContext;

        public ProfessorController(ApplicationDbContext context)
        {
            mContext = context;
        }
        
        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ProfessorViewModel professorViewModel = new ProfessorViewModel();

            if(id != null)
            {
                var professor = mContext.Professor.Where(p => p.Id == id).ToList().FirstOrDefault();
                professorViewModel.Id = professor.Id;
                professorViewModel.Nome = professor.Nome;
            }            

            return View(professorViewModel);
        }
        
        [HttpPost]
        public IActionResult Cadastro(ProfessorViewModel viewProfessor)
        {
            if (ModelState.IsValid)
            {
                Professor professor = new Professor()
                {
                    Id = viewProfessor.Id,
                    Nome = viewProfessor.Nome
                };

                if(viewProfessor.Id == 0)
                {
                    mContext.Professor.Add(professor);
                }
                else
                {
                    mContext.Entry(professor).State = EntityState.Modified;
                }

                mContext.SaveChanges();
            }
            else
            {
                return View(viewProfessor);
            }

            return RedirectToAction("Cadastro");
        }
    }
}