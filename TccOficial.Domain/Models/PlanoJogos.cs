using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class PlanoJogos
    {
        public PlanoJogos()
        {

        }
        public PlanoJogos(Plano plano, Jogo jogo)
        {
            Plano = plano;
            Jogo = jogo;
        }

        public long PlanoId { get; set; }
        public int JogoId { get; set; }

        public virtual Plano Plano { get; set; }
        public virtual Jogo Jogo { get; set; }

    }
}
