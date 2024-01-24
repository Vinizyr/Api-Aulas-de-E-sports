using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Infra.Builders
{
    public class UsuarioPerfilBuilder : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.HasKey(x => new { x.PerfilId, x.UsuarioId });

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.UsuarioPerfil)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.Perfil)
                .WithMany(x => x.UsuarioPerfil)
                .HasForeignKey(x => x.PerfilId);
        }
    }

}
