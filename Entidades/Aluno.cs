using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProfessoresAlunos.Entidades
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Mensalidade { get; set; }
        public DateTime DataVencimento { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }        
    }
}
