using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProfessoresAlunos.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
        
        public float Mensalidade { get; set; }
        
        public DateTime DataVencimento { get; set; }
        
        public int ProfessorId { get; set; }

        public string NomeProfessor { get; set; }

        public IFormFile Arquivo { get; set; }
    }
}
