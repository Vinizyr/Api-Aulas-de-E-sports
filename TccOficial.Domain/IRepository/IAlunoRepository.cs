using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IAlunoRepository
    {
        Task<Aluno> GetAlunoById(long id);
        Task<Aluno> GetByCpf(string cpf);
        Task Edit(Aluno aluno);
        Task Delete(Aluno aluno);
    }
}
