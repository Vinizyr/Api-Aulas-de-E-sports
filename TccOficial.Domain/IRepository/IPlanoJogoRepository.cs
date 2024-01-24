using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IPlanoJogoRepository
    {
        void Save(List<PlanoJogos> planoJogos);
        Task<List<PlanoJogos>> GetJogosDoPlano(long planoId);
    }
}
