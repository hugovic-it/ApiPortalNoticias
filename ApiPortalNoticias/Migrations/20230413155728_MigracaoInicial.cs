using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPortalNoticias.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<string>(type: "TEXT", nullable: false),
                    ImagemApresentacao = table.Column<string>(type: "TEXT", nullable: false),
                    TextoApresentacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    NoticiaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.NoticiaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Noticias");
        }
    }
}
