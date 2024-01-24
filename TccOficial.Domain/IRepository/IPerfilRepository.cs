using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Domain.IRepository
{
    public interface IPerfilRepository
    {
        Task<Perfil> GetPerfil(string tipoPerfil);
        Task<List<Perfil>> GetAllPerfils(string username, string password);
    }
}
