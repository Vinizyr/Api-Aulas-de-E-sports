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
    public class PlanoBuilder : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(x => x.PlanoId);

            builder.HasMany(x => x.PlanoJogo)
                .WithOne(x => x.Plano)
                .HasForeignKey(x => x.PlanoId);

            builder.HasOne(p => p.Professor)
                .WithMany(p => p.Planos)
                .HasForeignKey(x => x.ProfessorId);
        }
    }

}
