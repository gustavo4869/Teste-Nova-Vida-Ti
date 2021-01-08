using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaProfessoresAlunos.DAL;
using SistemaProfessoresAlunos.Entidades;
using SistemaProfessoresAlunos.Models;

namespace SistemaProfessoresAlunos.Controllers
{
    public class ArquivoController : Controller
    {
        private IHostingEnvironment _env;
        protected ApplicationDbContext mContext;

        public ArquivoController(IHostingEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            mContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Importar(IFormFile arquivo, int professorId)
        {
            try
            {
                var filePath = Path.GetTempFileName();                
                using (var stream = System.IO.File.Create(filePath))
                {
                    arquivo.CopyTo(stream);
                }

                using (var streamReader = new StreamReader(filePath))
                {
                    string mensagemErroModelState = "";
                    string linha;
                    int contadorLinha = 0;
                    while ((linha = streamReader.ReadLine()) != null)
                    {
                        contadorLinha++;
                        string mensagemErro = ValidaArquivoTexto(linha, contadorLinha);
                        if (mensagemErro.Equals(""))
                        {
                            Aluno aluno = new Aluno()
                            {
                                Nome = linha.Split("||")[0],
                                Mensalidade = float.Parse(linha.Split("||")[1]),
                                DataVencimento = DateTime.ParseExact(linha.Split("||")[2], "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")),
                                ProfessorId = professorId
                            };

                            mContext.Aluno.Add(aluno);
                        }
                        else
                        {
                            mensagemErroModelState = mensagemErroModelState + mensagemErro;
                        }
                    }

                    if (mensagemErroModelState.Equals("")){
                        mContext.SaveChanges();
                    }                        
                    else
                    {
                        ModelState.AddModelError("Error", mensagemErroModelState);
                        return View("Index"); 
                    }
                        
                }                
                return Redirect("..\\Aluno\\Consulta?ProfessorId=" + professorId);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", e.Message + " -> " + e.StackTrace);
                return View("Index");
            }
        }        

        private string ValidaArquivoTexto(string linha, int numeroLinha)
        {
            string mensagemErro = "";

            string nome = linha.Split("||")[0];
            if(nome == "")
            {
                mensagemErro += "É necessário preencher o campo nome da linha: " + numeroLinha.ToString() + Environment.NewLine;
            }

            float mensalidade = 0;
            if (!float.TryParse(linha.Split("||")[1], out mensalidade))
            {
                mensagemErro += "É necessário preencher a mensalidade corretamente da linha: " + numeroLinha.ToString() + Environment.NewLine;
            }

            DateTime dataVencimento;
            if (!DateTime.TryParseExact(linha.Split("||")[2], "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataVencimento))
            {
                mensagemErro += "É necessário preencher a data (dd/MM/yyyy) corretamente da linha: " + numeroLinha.ToString() + Environment.NewLine;
            }

            return mensagemErro;
        }
    }
}