using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IPessoaRepository
    {
        //Pessoa
        Task Save(Pessoa pessoa);
        Task<Pessoa> GetByCpf(string cpf);
        Task<Professor> GetProfessorByUsername(string username); //Usado em PlanoHandler
        Task<Pessoa> GetPessoaByUsername(string username);
        Task UpdatePessoa(Pessoa pessoa);
    }
}
