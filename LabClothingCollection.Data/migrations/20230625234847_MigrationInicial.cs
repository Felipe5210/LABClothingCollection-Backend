using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabClothingCollection.Data.migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colecoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDaColecao = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    idResponsavel = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orcamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnoDeLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colecoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDoModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificadorDaColecao = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfOuCnpj = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "id", "CpfOuCnpj", "DataDeNascimento", "Email", "Genero", "Status", "Telefone", "TipoDeUsuario", "nomeCompleto" },
                values: new object[,]
                {
                    { 1, "141.659.360-81", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@mail.com", "Masculino", "Ativo", "9999-9999", "Administrador", "Koiru Teusda Vueca" },
                    { 2, "123.456.789-00", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "fulano@mail.com", "Masculino", "Ativo", "8888-8888", "Colaborador", "Fulano de Tal" },
                    { 3, "987.654.321-00", new DateTime(1992, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ciclana@mail.com", "Feminino", "Ativo", "7777-7777", "Cliente", "Ciclana Silva" },
                    { 4, "567.890.123-00", new DateTime(1978, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "beltrano@mail.com", "Masculino", "Inativo", "6666-6666", "Administrador", "Beltrano Pereira" },
                    { 5, "321.654.987-00", new DateTime(1995, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@mail.com", "Feminino", "Ativo", "5555-5555", "Cliente", "Ana Souza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colecoes_NomeDaColecao",
                table: "Colecoes",
                column: "NomeDaColecao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CpfOuCnpj",
                table: "Usuarios",
                column: "CpfOuCnpj",
                unique: true,
                filter: "[CpfOuCnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colecoes");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
