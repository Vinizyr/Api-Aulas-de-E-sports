using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Plano
    {
        public Plano()
        {

        }
        public Plano(string nome, float preco, TimeSpan cargaHoraria, TimeSpan duracaoAula)
        {
            Nome = nome;
            Preco = preco;
            CargaHoraria = cargaHoraria;
            DuracaoAula = duracaoAula;
        }

        public long PlanoId { get; set; }

        public long ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

        public string Nome { get; set; }
        public float Preco { get; set; }
        public TimeSpan CargaHoraria { get; set; }
        public TimeSpan DuracaoAula { get; set; } 

        public virtual ICollection<Turma>? Turmas { get; set; }
        public virtual ICollection<PlanoJogos> PlanoJogo { get; set; }


        public void AtualizaPlano(string nome, float preco, TimeSpan cargaHoraria, TimeSpan duracaoAula, List<PlanoJogos> jogos)
        {
            Nome = nome;
            Preco = preco;
            CargaHoraria = cargaHoraria;
            DuracaoAula = duracaoAula;
            PlanoJogo = jogos;
        }
    }
}
