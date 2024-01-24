using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Aluno
    {
        public long AlunoId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public DateTime DataCriado { get; set; }
        public virtual ICollection<Turma>? Turma { get; set; }

    }
}
