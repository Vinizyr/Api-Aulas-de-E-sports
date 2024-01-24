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
    public class PessoaBuilder : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.Property(p => p.DataNascimento)
                .HasColumnType("date");

            builder.Property(c => c.Sexo)
                    .HasConversion<string>();

            builder.HasOne(p => p.Aluno)
            .WithOne(a => a.Pessoa)
            .HasForeignKey<Aluno>(a => a.AlunoId);

            builder.HasOne(p => p.Professor)
            .WithOne(p => p.Pessoa)
            .HasForeignKey<Professor>(pr => pr.ProfessorId);

            builder.HasOne(p => p.Usuario)
            .WithOne(u => u.Pessoa)
            .HasForeignKey<Usuario>(u => u.UsuarioId);
        }
    }

}
