using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OSlight.App.Data.Migrations
{
    public partial class InitIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AbrirOSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbrirOSViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NomeReclamante = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroPoste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbrirOSViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbrirOSViewModel_EnderecoViewModel_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "EnderecoViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FecharOSViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbrirOSId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFechamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FecharOSViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FecharOSViewModel_AbrirOSViewModel_AbrirOSId",
                        column: x => x.AbrirOSId,
                        principalTable: "AbrirOSViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbrirOSViewModel_EnderecoId",
                table: "AbrirOSViewModel",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_FecharOSViewModel_AbrirOSId",
                table: "FecharOSViewModel",
                column: "AbrirOSId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FecharOSViewModel");

            migrationBuilder.DropTable(
                name: "AbrirOSViewModel");

            migrationBuilder.DropTable(
                name: "EnderecoViewModel");
        }
    }
}
