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
    public class PerfilBuilder : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(x => x.PerfilId);

            builder.Property(x => x.TipoPerfil).IsRequired();

            builder.HasData(new { PerfilId = (long)1, TipoPerfil = "Aluno" },
                            new { PerfilId = (long)2, TipoPerfil = "Professor" },
                            new { PerfilId = (long)3, TipoPerfil = "Administrador" });
        }
    }

}
