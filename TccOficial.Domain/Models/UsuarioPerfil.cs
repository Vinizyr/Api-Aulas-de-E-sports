using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class UsuarioPerfil
    {
        public UsuarioPerfil()
        {

        }
        public UsuarioPerfil(Usuario usuario, Perfil perfil)
        {
            Usuario = usuario;
            Perfil = perfil;
        }
        public long UsuarioId { get; set; }
        public long PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
