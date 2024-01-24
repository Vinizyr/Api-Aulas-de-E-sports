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
    public class PerfilRepository : IPerfilRepository
    {
        private readonly TccContext _context;

        public PerfilRepository(TccContext context)
        {
            _context = context;
        }

        public async Task<List<Perfil>> GetAllPerfils(string username, string password)
        {
            var perfis = await _context.Perfil
                .Include(x => x.UsuarioPerfil)
                    .ThenInclude(x => x.Usuario)
                        .Where(x => x.UsuarioPerfil
                            .Any(x => x.Usuario.Username == username && 
                                x.Usuario.Password == password)).ToListAsync();

            return perfis;
        }

        public async Task<Perfil> GetPerfil(string tipoPerfil)
        {
            var perfil = await _context.Perfil
                .Where(x => x.TipoPerfil == tipoPerfil)
                .FirstOrDefaultAsync();
            return perfil!;
        }
    }
}
