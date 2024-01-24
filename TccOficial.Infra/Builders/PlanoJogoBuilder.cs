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
    public class PlanoJogoBuilder : IEntityTypeConfiguration<PlanoJogos>
    {
        public void Configure(EntityTypeBuilder<PlanoJogos> builder)
        {
            builder.HasKey(x => new { x.PlanoId, x.JogoId });

            builder.HasOne(x => x.Plano)
                .WithMany(x => x.PlanoJogo)
                .HasForeignKey(x => x.PlanoId);
        }
    }

}
