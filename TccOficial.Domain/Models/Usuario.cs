using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Usuario
    {
        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
            CriadoEm = DateTime.Now;
            //_perfis = new List<UsuarioPerfil>();
            UsuarioPerfil = new List<UsuarioPerfil>();
        }

        public long UsuarioId { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CriadoEm { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; }
    }
   
}
