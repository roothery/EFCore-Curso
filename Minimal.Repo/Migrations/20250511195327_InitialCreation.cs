﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Minimal.Repo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diretores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    DiretorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmes_Diretores_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Christopher Nolan" },
                    { 2, "Steven Spielberg" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" },
                    { 6, "Greta Gerwig" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ano", "DiretorId", "Titulo" },
                values: new object[,]
                {
                    { 1, 2010, 1, "Inception" },
                    { 2, 2014, 1, "Interstellar" },
                    { 3, 2008, 1, "The Dark Knight" },
                    { 4, 1993, 2, "Jurassic Park" },
                    { 5, 1982, 2, "E.T. the Extra-Terrestrial" },
                    { 6, 1993, 2, "Schindler's List" },
                    { 7, 1994, 3, "Pulp Fiction" },
                    { 8, 2003, 3, "Kill Bill: Vol. 1" },
                    { 9, 2012, 3, "Django Unchained" },
                    { 10, 1990, 4, "Goodfellas" },
                    { 11, 2019, 4, "The Irishman" },
                    { 12, 1976, 4, "Taxi Driver" },
                    { 13, 2009, 5, "Avatar" },
                    { 14, 1997, 5, "Titanic" },
                    { 15, 1984, 5, "The Terminator" },
                    { 16, 2017, 6, "Lady Bird" },
                    { 17, 2019, 6, "Little Women" },
                    { 18, 2023, 6, "Barbie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_DiretorId",
                table: "Filmes",
                column: "DiretorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes");

            migrationBuilder.DropTable(
                name: "Diretores");
        }
    }
}
