using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaProfessoresAlunos.DAL;
using SistemaProfessoresAlunos.Entidades;
using SistemaProfessoresAlunos.Models;

namespace SistemaProfessoresAlunos.Controllers
{
    public class AlunoController : Controller
    {
        protected ApplicationDbContext mContext;

        public AlunoController(ApplicationDbContext context)

        {
            mContext = context;
        }

        public IActionResult Cadastro(AlunoViewModel viewAluno)
        {
            if (ModelState.IsValid)
            {
                Aluno aluno = new Aluno()
                {
                    Nome = viewAluno.Nome,
                    Mensalidade = viewAluno.Mensalidade,
                    DataVencimento = viewAluno.DataVencimento,
                    ProfessorId = viewAluno.ProfessorId
                };

                mContext.Aluno.Add(aluno);


                mContext.SaveChanges();
            }

            return RedirectToAction("Consulta");
        }
        public IActionResult Consulta(int professorId)
        {
            IEnumerable<AlunoViewModel> alunos = (from Aluno in mContext.Aluno
                                                  join professor in mContext.Professor on Aluno.ProfessorId equals professor.Id
                                                  where Aluno.ProfessorId == professorId
                                                  select new AlunoViewModel
                                                  {
                                                      Id = Aluno.Id,
                                                      Nome = Aluno.Nome,
                                                      Mensalidade = Aluno.Mensalidade,
                                                      ProfessorId = Aluno.ProfessorId,
                                                      DataVencimento = Aluno.DataVencimento,
                                                      NomeProfessor = professor.Nome
                                                  }).ToList();            
            mContext.Dispose();
            return View(alunos);
        }        

        [HttpPost]
        public IActionResult ConfirmarExclusao(string alunosExclusaoId)
        {
            var ids = alunosExclusaoId.Split(',');
            int professorId = 0;

            foreach(var id in ids)
            {
                if(id != "")
                {
                    Aluno aluno = mContext.Aluno.Where(a => a.Id == Convert.ToInt32(id)).FirstOrDefault();
                    professorId = aluno.ProfessorId;
                    mContext.Attach(aluno);
                    mContext.Remove(aluno);
                }                
            }

            mContext.SaveChanges();
            return RedirectToAction("Consulta", new { professorId = professorId });
        }       
    }
}