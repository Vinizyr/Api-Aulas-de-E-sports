using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;

namespace TccOficial.Infra.Builders
{
    public class AlunoBuilder : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(x => x.AlunoId);
            builder.Property(x => x.DataCriado).HasColumnType("date");
        }
    }
}
