using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Enums;

namespace TccOficial.Domain.Models
{
    public class Pessoa
    {
        public Pessoa()
        {

        }
        public Pessoa(string nome, string sobrenome, DateTime dataNascimento, string discord)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Discord = discord;
        }

        [Key]
        public long PessoaId { get; set; }

        public virtual Aluno? Aluno { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Professor? Professor { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Discord { get; set; }
        public ESexo Sexo { get; set; }
        public bool Ativo { get; set; }



        public void AtualizarPessoa(string nome, string sobrenome, DateTime dataNascimento, string discord)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Discord = discord;
        }
    }
}
