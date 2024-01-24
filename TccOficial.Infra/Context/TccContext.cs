using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccOficial.Domain.Models;
using TccOficial.Infra.Builders;

namespace TccOficial.Infra.Context
{
    public class TccContext : DbContext
    {
        public TccContext(DbContextOptions<TccContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Frequencia> Frequencia { get; set; }
        public DbSet<Horario> Horario { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        public DbSet<JogoProfessor> JogoProfessor { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Plano> Plano { get; set; }
        public DbSet<PlanoJogos> PlanoJogo { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TccOficial");

            modelBuilder.ApplyConfiguration(new AlunoBuilder());
            modelBuilder.ApplyConfiguration(new FrequenciaBuilder());
            modelBuilder.ApplyConfiguration(new HorarioBuilder());
            modelBuilder.ApplyConfiguration(new JogoBuilder());
            modelBuilder.ApplyConfiguration(new JogoProfessorBuilder());
            modelBuilder.ApplyConfiguration(new PerfilBuilder());
            modelBuilder.ApplyConfiguration(new PessoaBuilder());
            modelBuilder.ApplyConfiguration(new PlanoBuilder());
            modelBuilder.ApplyConfiguration(new PlanoJogoBuilder());
            modelBuilder.ApplyConfiguration(new ProfessorBuilder());
            modelBuilder.ApplyConfiguration(new TurmaBuilder());
            modelBuilder.ApplyConfiguration(new UsuarioBuilder());
            modelBuilder.ApplyConfiguration(new UsuarioPerfilBuilder());
            
        }

    }
}
