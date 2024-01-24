using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class JogoProfessor
    {
        //public long JogoProfessorId { get; set; }
        public long ProfessorId { get; set; }
        public int JogoId { get; set; }

        public virtual Jogo Jogo { get; set; }
        public virtual Professor Professor { get; set; }

        public bool Ativo { get; set; }

    }
}
