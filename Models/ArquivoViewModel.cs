using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProfessoresAlunos.Models
{
    public class ArquivoViewModel
    {
        public int ProfessorId { get; set; }
        public IFormFile Arquivo { get; set; }
        
    }
}
