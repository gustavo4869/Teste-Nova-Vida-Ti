using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProfessoresAlunos.Entidades
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
