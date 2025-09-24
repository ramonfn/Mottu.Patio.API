using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mottu.Patio.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_MOTTU_FILIAIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MOTTU_FILIAIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_MOTTU_MOTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Quilometragem = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FilialId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MOTTU_MOTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_MOTTU_MOTOS_T_MOTTU_FILIAIS_FilialId",
                        column: x => x.FilialId,
                        principalTable: "T_MOTTU_FILIAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_MOTTU_USUARIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FilialId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrimeiroNome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Sobrenome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cargo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Idade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MOTTU_USUARIO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_MOTTU_USUARIO_T_MOTTU_FILIAIS_FilialId",
                        column: x => x.FilialId,
                        principalTable: "T_MOTTU_FILIAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_MOTTU_LOCALIZACOES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MotoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Latitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MOTTU_LOCALIZACOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_MOTTU_LOCALIZACOES_T_MOTTU_MOTOS_MotoId",
                        column: x => x.MotoId,
                        principalTable: "T_MOTTU_MOTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_MOTTU_LOCALIZACOES_MotoId",
                table: "T_MOTTU_LOCALIZACOES",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_T_MOTTU_MOTOS_FilialId",
                table: "T_MOTTU_MOTOS",
                column: "FilialId");

            migrationBuilder.CreateIndex(
                name: "IX_T_MOTTU_USUARIO_FilialId",
                table: "T_MOTTU_USUARIO",
                column: "FilialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MOTTU_LOCALIZACOES");

            migrationBuilder.DropTable(
                name: "T_MOTTU_USUARIO");

            migrationBuilder.DropTable(
                name: "T_MOTTU_MOTOS");

            migrationBuilder.DropTable(
                name: "T_MOTTU_FILIAIS");
        }
    }
}
