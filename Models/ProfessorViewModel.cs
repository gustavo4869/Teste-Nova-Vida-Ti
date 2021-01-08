using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProfessoresAlunos.Models
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do professor!")]
        public string Nome { get; set; }
    }
}
