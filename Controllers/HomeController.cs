using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaProfessoresAlunos.DAL;
using SistemaProfessoresAlunos.Entidades;
using SistemaProfessoresAlunos.Models;

namespace SistemaProfessoresAlunos.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext Repositorio;
        public HomeController(ApplicationDbContext repositorio)
        {
            Repositorio = repositorio;
        }

        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            IEnumerable<Professor> listaProfessores = Repositorio.Professor.ToList();

            return View(listaProfessores);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
