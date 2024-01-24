using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IPlanoRepository
    {
        Task Save(Plano plano);
        Task<Plano> GetByIdAndUsername(long id, string professorLogado);
        Task<Plano> GetById(long id);
        Task<Plano> GetByName(string nome, string usuarioLogado);
        Task<IList<Plano>> GetAllPlanosProfessor(string usuarioLogado);
        Task<IList<Plano>> GetAllPlanosAluno(string usuarioLogado);
        Task Edit(Plano plano);
        Task Delete(Plano plano);
    }
}
