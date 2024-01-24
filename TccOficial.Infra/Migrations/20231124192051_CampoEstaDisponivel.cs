using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TccOficial.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CampoEstaDisponivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaDisponivel",
                schema: "TccOficial",
                table: "Horario",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaDisponivel",
                schema: "TccOficial",
                table: "Horario");
        }
    }
}
