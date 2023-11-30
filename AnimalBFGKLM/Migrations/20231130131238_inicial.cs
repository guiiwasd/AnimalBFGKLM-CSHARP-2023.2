using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalBFGKLM.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTipos",
                columns: table => new
                {
                    AnimalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domestico = table.Column<bool>(type: "bit", nullable: false),
                    Selvagem = table.Column<bool>(type: "bit", nullable: false),
                    Comportamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<long>(type: "bigint", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTipos", x => x.AnimalId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalTipos");
        }
    }
}
