using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Jogo
    {
        public Jogo(string nome)
        {
            Nome = nome;
        }

        public int JogoId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PlanoJogos>? PlanoJogos { get; set; }
        public virtual ICollection<JogoProfessor>? JogoProfessor { get; set; }

    }
}
