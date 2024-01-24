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
    public class TurmaBuilder : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(x => x.TurmaId);

            builder.HasOne(x => x.Aluno)
                .WithMany(x => x.Turma)
                .HasForeignKey(x => x.AlunoId);

            builder.Property(x => x.DataInicio)
                .HasColumnType("date");

            builder.Property(x => x.DataFim)
                .HasColumnType("date");
        }
    }

}
