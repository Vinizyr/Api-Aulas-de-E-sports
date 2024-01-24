using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IJogoRepository
    {
        Jogo GetJogo(int jogoId);
        Task<bool> TodosOsJogosExistem(List<int> jogos);
        Task<List<Jogo>> GetJogos(List<int> jogosId);
    }
}
