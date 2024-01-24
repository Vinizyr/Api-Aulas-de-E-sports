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
    public class PlanoJogoRepository : IPlanoJogoRepository
    {
        private readonly TccContext _context;

        public PlanoJogoRepository(TccContext context)
        {
            _context = context;
        }

        public void Save(List<PlanoJogos> planoJogo)
        {
            _context.PlanoJogo.AddRange(planoJogo);
        }

        public async Task<List<PlanoJogos>> GetJogosDoPlano(long planoId)
        {

            var jogos = await _context.PlanoJogo
                            .Where(x => x.PlanoId == planoId)
                            .ToListAsync();

            return jogos!;
            
        }
    }
}
