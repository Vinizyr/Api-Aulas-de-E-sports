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
    public class HorarioBuilder : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.ToTable("Horario");

            builder.HasKey(h => h.HorarioId);

            builder.HasOne(h => h.Professor)
                .WithMany(h => h.Horarios)
                .HasForeignKey(h => h.ProfessorId); //Tem que perceber a classe que voce está modelando
            //Nesse exemplo entende-se que a foreignKey de Horario é o professorId. 

            builder.Property(d => d.DiaDaSemana)
                .HasConversion<string>();

        }
    }

}
