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
    public class UsuarioBuilder : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.UsuarioId);

            builder.HasOne(x => x.Pessoa)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Usuario>(x => x.UsuarioId);

            builder.Property(x => x.CriadoEm).HasColumnType("date");

            builder.HasMany(x => x.UsuarioPerfil)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId);
        }
    }

}
