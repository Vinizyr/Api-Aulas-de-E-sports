using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TccOficial.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TccOficial");

            migrationBuilder.CreateTable(
                name: "Jogo",
                schema: "TccOficial",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.JogoId);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "TccOficial",
                columns: table => new
                {
                    PerfilId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPerfil = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.PerfilId);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "TccOficial",
                columns: table => new
                {
                    PessoaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Sobrenome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Discord = table.Column<string>(type: "text", nullable: false),
                    Sexo = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                schema: "TccOficial",
                columns: table => new
                {
                    AlunoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_Aluno_Pessoa_AlunoId",
                        column: x => x.AlunoId,
                        principalSchema: "TccOficial",
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                schema: "TccOficial",
                columns: table => new
                {
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    NomeCanalYoutube = table.Column<string>(type: "text", nullable: true),
                    DataCriado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK_Professor_Pessoa_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "TccOficial",
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "TccOficial",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "TccOficial",
                        principalTable: "Pessoa",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                schema: "TccOficial",
                columns: table => new
                {
                    HorarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    DiaDaSemana = table.Column<string>(type: "text", nullable: false),
                    HoraInicial = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFinal = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horario_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "TccOficial",
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogoProfessor",
                schema: "TccOficial",
                columns: table => new
                {
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoProfessor", x => new { x.JogoId, x.ProfessorId });
                    table.ForeignKey(
                        name: "FK_JogoProfessor_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalSchema: "TccOficial",
                        principalTable: "Jogo",
                        principalColumn: "JogoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoProfessor_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "TccOficial",
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                schema: "TccOficial",
                columns: table => new
                {
                    PlanoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    CargaHoraria = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DuracaoAula = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.PlanoId);
                    table.ForeignKey(
                        name: "FK_Plano_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "TccOficial",
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPerfil",
                schema: "TccOficial",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    PerfilId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPerfil", x => new { x.PerfilId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "TccOficial",
                        principalTable: "Perfil",
                        principalColumn: "PerfilId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPerfil_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "TccOficial",
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanoJogo",
                schema: "TccOficial",
                columns: table => new
                {
                    PlanoId = table.Column<long>(type: "bigint", nullable: false),
                    JogoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoJogo", x => new { x.PlanoId, x.JogoId });
                    table.ForeignKey(
                        name: "FK_PlanoJogo_Jogo_JogoId",
                        column: x => x.JogoId,
                        principalSchema: "TccOficial",
                        principalTable: "Jogo",
                        principalColumn: "JogoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoJogo_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalSchema: "TccOficial",
                        principalTable: "Plano",
                        principalColumn: "PlanoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                schema: "TccOficial",
                columns: table => new
                {
                    TurmaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfessorId = table.Column<long>(type: "bigint", nullable: false),
                    AlunoId = table.Column<long>(type: "bigint", nullable: false),
                    PlanoId = table.Column<long>(type: "bigint", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turma_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalSchema: "TccOficial",
                        principalTable: "Aluno",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Plano_PlanoId",
                        column: x => x.PlanoId,
                        principalSchema: "TccOficial",
                        principalTable: "Plano",
                        principalColumn: "PlanoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalSchema: "TccOficial",
                        principalTable: "Professor",
                        principalColumn: "ProfessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Frequencia",
                schema: "TccOficial",
                columns: table => new
                {
                    FrequenciaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TurmaId = table.Column<long>(type: "bigint", nullable: false),
                    Presenca = table.Column<bool>(type: "boolean", nullable: false),
                    DataAula = table.Column<DateTime>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencia", x => x.FrequenciaId);
                    table.ForeignKey(
                        name: "FK_Frequencia_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalSchema: "TccOficial",
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "TccOficial",
                table: "Jogo",
                columns: new[] { "JogoId", "Nome" },
                values: new object[,]
                {
                    { 1, "Rocket League" },
                    { 2, "League of Legends (LOL)" },
                    { 3, "FIFA" },
                    { 4, "Pro Evolution Soccer (PES)" },
                    { 5, "CSGO: Counter Strike Global Offenssive" },
                    { 6, "Dota 2" },
                    { 7, "Fortnite" },
                    { 8, "Call of Duty" },
                    { 9, "Free Fire" },
                    { 10, "Apex Legends" }
                });

            migrationBuilder.InsertData(
                schema: "TccOficial",
                table: "Perfil",
                columns: new[] { "PerfilId", "TipoPerfil" },
                values: new object[,]
                {
                    { 1L, "Aluno" },
                    { 2L, "Professor" },
                    { 3L, "Administrador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencia_TurmaId",
                schema: "TccOficial",
                table: "Frequencia",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ProfessorId",
                schema: "TccOficial",
                table: "Horario",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_JogoProfessor_ProfessorId",
                schema: "TccOficial",
                table: "JogoProfessor",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plano_ProfessorId",
                schema: "TccOficial",
                table: "Plano",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoJogo_JogoId",
                schema: "TccOficial",
                table: "PlanoJogo",
                column: "JogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_AlunoId",
                schema: "TccOficial",
                table: "Turma",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_PlanoId",
                schema: "TccOficial",
                table: "Turma",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorId",
                schema: "TccOficial",
                table: "Turma",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPerfil_UsuarioId",
                schema: "TccOficial",
                table: "UsuarioPerfil",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frequencia",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Horario",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "JogoProfessor",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "PlanoJogo",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "UsuarioPerfil",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Turma",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Jogo",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Aluno",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Plano",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Professor",
                schema: "TccOficial");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "TccOficial");
        }
    }
}
