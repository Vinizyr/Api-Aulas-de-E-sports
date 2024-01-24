using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccOficial.Domain.Models
{
    public class Perfil
    {
        public Perfil(long perfilId, string tipoPerfil)
        {
            PerfilId = perfilId;
            TipoPerfil = tipoPerfil;
        }

        public long PerfilId { get; set; }
        public string TipoPerfil { get; set; }

        public virtual ICollection<UsuarioPerfil> UsuarioPerfil { get; set; }

    }
}
