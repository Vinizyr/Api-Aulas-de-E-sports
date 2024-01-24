﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TccOficial.Infra.Context;

#nullable disable

namespace TccOficial.Infra.Migrations
{
    [DbContext(typeof(TccContext))]
    partial class TccContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("TccOficial")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TccOficial.Domain.Models.Aluno", b =>
                {
                    b.Property<long>("AlunoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCriado")
                        .HasColumnType("date");

                    b.HasKey("AlunoId");

                    b.ToTable("Aluno", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Frequencia", b =>
                {
                    b.Property<long>("FrequenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("FrequenciaId"));

                    b.Property<DateTime>("DataAula")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("HoraFim")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("interval");

                    b.Property<bool>("Presenca")
                        .HasColumnType("boolean");

                    b.Property<long>("TurmaId")
                        .HasColumnType("bigint");

                    b.HasKey("FrequenciaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Frequencia", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Horario", b =>
                {
                    b.Property<long>("HorarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("HorarioId"));

                    b.Property<string>("DiaDaSemana")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("EstaDisponivel")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan>("HoraFinal")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("HoraInicial")
                        .HasColumnType("interval");

                    b.Property<long>("ProfessorId")
                        .HasColumnType("bigint");

                    b.HasKey("HorarioId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Horario", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Jogo", b =>
                {
                    b.Property<int>("JogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JogoId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("JogoId");

                    b.ToTable("Jogo", "TccOficial");

                    b.HasData(
                        new
                        {
                            JogoId = 1,
                            Nome = "Rocket League"
                        },
                        new
                        {
                            JogoId = 2,
                            Nome = "League of Legends (LOL)"
                        },
                        new
                        {
                            JogoId = 3,
                            Nome = "FIFA"
                        },
                        new
                        {
                            JogoId = 4,
                            Nome = "Pro Evolution Soccer (PES)"
                        },
                        new
                        {
                            JogoId = 5,
                            Nome = "CSGO: Counter Strike Global Offenssive"
                        },
                        new
                        {
                            JogoId = 6,
                            Nome = "Dota 2"
                        },
                        new
                        {
                            JogoId = 7,
                            Nome = "Fortnite"
                        },
                        new
                        {
                            JogoId = 8,
                            Nome = "Call of Duty"
                        },
                        new
                        {
                            JogoId = 9,
                            Nome = "Free Fire"
                        },
                        new
                        {
                            JogoId = 10,
                            Nome = "Apex Legends"
                        });
                });

            modelBuilder.Entity("TccOficial.Domain.Models.JogoProfessor", b =>
                {
                    b.Property<int>("JogoId")
                        .HasColumnType("integer");

                    b.Property<long>("ProfessorId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.HasKey("JogoId", "ProfessorId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("JogoProfessor", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Perfil", b =>
                {
                    b.Property<long>("PerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PerfilId"));

                    b.Property<string>("TipoPerfil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PerfilId");

                    b.ToTable("Perfil", "TccOficial");

                    b.HasData(
                        new
                        {
                            PerfilId = 1L,
                            TipoPerfil = "Aluno"
                        },
                        new
                        {
                            PerfilId = 2L,
                            TipoPerfil = "Professor"
                        },
                        new
                        {
                            PerfilId = 3L,
                            TipoPerfil = "Administrador"
                        });
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Pessoa", b =>
                {
                    b.Property<long>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PessoaId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Discord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Plano", b =>
                {
                    b.Property<long>("PlanoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("PlanoId"));

                    b.Property<TimeSpan>("CargaHoraria")
                        .HasColumnType("interval");

                    b.Property<TimeSpan>("DuracaoAula")
                        .HasColumnType("interval");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.Property<long>("ProfessorId")
                        .HasColumnType("bigint");

                    b.HasKey("PlanoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Plano", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.PlanoJogos", b =>
                {
                    b.Property<long>("PlanoId")
                        .HasColumnType("bigint");

                    b.Property<int>("JogoId")
                        .HasColumnType("integer");

                    b.HasKey("PlanoId", "JogoId");

                    b.HasIndex("JogoId");

                    b.ToTable("PlanoJogo", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Professor", b =>
                {
                    b.Property<long>("ProfessorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataCriado")
                        .HasColumnType("date");

                    b.Property<string>("NomeCanalYoutube")
                        .HasColumnType("text");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professor", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Turma", b =>
                {
                    b.Property<long>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("TurmaId"));

                    b.Property<long>("AlunoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("date");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date");

                    b.Property<long>("PlanoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfessorId")
                        .HasColumnType("bigint");

                    b.HasKey("TurmaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("PlanoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Turma", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Usuario", b =>
                {
                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.UsuarioPerfil", b =>
                {
                    b.Property<long>("PerfilId")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("PerfilId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioPerfil", "TccOficial");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Aluno", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Pessoa", "Pessoa")
                        .WithOne("Aluno")
                        .HasForeignKey("TccOficial.Domain.Models.Aluno", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Frequencia", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Turma", "Turma")
                        .WithMany("Frequencia")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Horario", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Professor", "Professor")
                        .WithMany("Horarios")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.JogoProfessor", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Jogo", "Jogo")
                        .WithMany("JogoProfessor")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TccOficial.Domain.Models.Professor", "Professor")
                        .WithMany("JogoProfessor")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Plano", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Professor", "Professor")
                        .WithMany("Planos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.PlanoJogos", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Jogo", "Jogo")
                        .WithMany("PlanoJogos")
                        .HasForeignKey("JogoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TccOficial.Domain.Models.Plano", "Plano")
                        .WithMany("PlanoJogo")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jogo");

                    b.Navigation("Plano");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Professor", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Pessoa", "Pessoa")
                        .WithOne("Professor")
                        .HasForeignKey("TccOficial.Domain.Models.Professor", "ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Turma", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Aluno", "Aluno")
                        .WithMany("Turma")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TccOficial.Domain.Models.Plano", "Plano")
                        .WithMany("Turmas")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TccOficial.Domain.Models.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Plano");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Usuario", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Pessoa", "Pessoa")
                        .WithOne("Usuario")
                        .HasForeignKey("TccOficial.Domain.Models.Usuario", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.UsuarioPerfil", b =>
                {
                    b.HasOne("TccOficial.Domain.Models.Perfil", "Perfil")
                        .WithMany("UsuarioPerfil")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TccOficial.Domain.Models.Usuario", "Usuario")
                        .WithMany("UsuarioPerfil")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Aluno", b =>
                {
                    b.Navigation("Turma");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Jogo", b =>
                {
                    b.Navigation("JogoProfessor");

                    b.Navigation("PlanoJogos");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Perfil", b =>
                {
                    b.Navigation("UsuarioPerfil");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Pessoa", b =>
                {
                    b.Navigation("Aluno");

                    b.Navigation("Professor");

                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Plano", b =>
                {
                    b.Navigation("PlanoJogo");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Professor", b =>
                {
                    b.Navigation("Horarios");

                    b.Navigation("JogoProfessor");

                    b.Navigation("Planos");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Turma", b =>
                {
                    b.Navigation("Frequencia");
                });

            modelBuilder.Entity("TccOficial.Domain.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioPerfil");
                });
#pragma warning restore 612, 618
        }
    }
}
