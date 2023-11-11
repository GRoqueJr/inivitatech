using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoremIpsumLogistica.Repositorios.Migrations
{
    /// <inheritdoc />
    public partial class ClienteEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClienteEndereco_Clientes_ClienteId",
                table: "ClienteEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteEndereco",
                table: "ClienteEndereco");

            migrationBuilder.RenameTable(
                name: "ClienteEndereco",
                newName: "ClientesEnderecos");

            migrationBuilder.RenameIndex(
                name: "IX_ClienteEndereco_ClienteId",
                table: "ClientesEnderecos",
                newName: "IX_ClientesEnderecos_ClienteId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "Clientes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "ClientesEnderecos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "ClientesEnderecos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "ClientesEnderecos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "ClientesEnderecos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "ClientesEnderecos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "ClientesEnderecos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "ClientesEnderecos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAlteracao",
                table: "ClientesEnderecos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientesEnderecos",
                table: "ClientesEnderecos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesEnderecos_Clientes_ClienteId",
                table: "ClientesEnderecos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesEnderecos_Clientes_ClienteId",
                table: "ClientesEnderecos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientesEnderecos",
                table: "ClientesEnderecos");

            migrationBuilder.DropColumn(
                name: "DataDeAlteracao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DataDeAlteracao",
                table: "ClientesEnderecos");

            migrationBuilder.RenameTable(
                name: "ClientesEnderecos",
                newName: "ClienteEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_ClientesEnderecos_ClienteId",
                table: "ClienteEndereco",
                newName: "IX_ClienteEndereco_ClienteId");

            migrationBuilder.AlterColumn<string>(
                name: "Uf",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "ClienteEndereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteEndereco",
                table: "ClienteEndereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClienteEndereco_Clientes_ClienteId",
                table: "ClienteEndereco",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
