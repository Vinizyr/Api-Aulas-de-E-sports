using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.IRepository;
using TccOficial.Domain.Models;
using TccOficial.Infra.Context;

namespace TccOficial.Infra.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private readonly TccContext _context;

        public JogoRepository(TccContext context)
        {
            _context = context;
        }

        public Jogo GetJogo(int jogosId)
        {
            var jogo = _context.Jogo
                .Where(x => x.JogoId == jogosId)
                    .FirstOrDefault();
            
            return jogo!;
        }

        public async Task<List<Jogo>> GetJogos(List<int> jogosId)
        {
            var jogo = await _context.Jogo
                .Where(x => jogosId.Contains(x.JogoId))
                    .ToListAsync();

            return jogo;
        }

        public async Task<bool> TodosOsJogosExistem(List<int> jogos)
        {
            foreach(var jogoId in jogos)
            {
                var existe = await _context.Jogo
                .Where(x => x.JogoId == jogoId)
                    .FirstOrDefaultAsync();

                if(existe == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
