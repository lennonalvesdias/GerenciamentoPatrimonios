using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.Dados.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacaoRegistro = table.Column<DateTime>(nullable: false),
                    DataCriacaoRegistro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacaoRegistro = table.Column<DateTime>(nullable: false),
                    DataCriacaoRegistro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    MarcaId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    NumeroTombo = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Patrimonios");
        }
    }
}
