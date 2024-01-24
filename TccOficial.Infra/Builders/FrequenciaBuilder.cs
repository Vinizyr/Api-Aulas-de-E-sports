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
    public class FrequenciaBuilder : IEntityTypeConfiguration<Frequencia>
    {
        public void Configure(EntityTypeBuilder<Frequencia> builder)
        {
            builder.HasKey(f => f.FrequenciaId);

            builder.Property(x => x.DataAula)
                .HasColumnType("date");

            builder.HasOne(x => x.Turma)
                .WithMany(x => x.Frequencia)
                .HasForeignKey(x => x.TurmaId);
        }
    }

}
