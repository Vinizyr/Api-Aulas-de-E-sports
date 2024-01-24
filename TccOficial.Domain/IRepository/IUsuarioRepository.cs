using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ExisteUsuario(string username);
        Task<Usuario> GetUsuarioLogin(string username, string password);

    }
}
