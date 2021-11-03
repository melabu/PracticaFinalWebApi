﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DRAGO.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "Money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
