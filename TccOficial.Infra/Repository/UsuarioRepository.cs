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

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TccContext _context;

        public UsuarioRepository(TccContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ExisteUsuario(string username)
        {
            var usuario = await _context.Usuario
                .Where(x => x.Username == username).FirstOrDefaultAsync();

            return usuario!;
        }

        public async Task<Usuario> GetUsuarioLogin(string username, string password)
        {
            var usuario = await _context.Usuario
                .Where(x => x.Username == username &&
                            x.Password == password)
                .FirstOrDefaultAsync();

            return usuario!;
        }
    }
}
