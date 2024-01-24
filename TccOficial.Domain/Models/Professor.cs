using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Professor
    {
        public long ProfessorId { get; set; }
        public string? NomeCanalYoutube { get; set; }
        public DateTime DataCriado { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Plano>? Planos { get; set; }
        public virtual ICollection<JogoProfessor>? JogoProfessor { get; set; }
        public virtual ICollection<Horario>? Horarios { get; set; }
        public virtual ICollection<Turma>? Turmas { get; set; }

    }
}
