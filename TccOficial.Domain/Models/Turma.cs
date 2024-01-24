using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Turma
    {
        public Turma()
        {
            Frequencia = new List<Frequencia>();
        }
        public long TurmaId { get; set; }

        public long ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public long AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public long PlanoId { get; set; }
        public virtual Plano Plano { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual ICollection<Frequencia> Frequencia { get; set; }

    }
}
