using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace banco_api.migrations
{
    public partial class PrimeraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    n_cuenta = table.Column<int>(type: "int(11)", nullable: false),
                    nombre = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    apellido = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1"),
                    dni = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false, collation: "latin1_swedish_ci")
                        .Annotation("MySql:CharSet", "latin1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.n_cuenta);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "depositos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    monto = table.Column<int>(type: "int(11)", nullable: false),
                    cliente = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depositos", x => x.id);
                    table.ForeignKey(
                        name: "depositos_ibfk_1",
                        column: x => x.cliente,
                        principalTable: "cliente",
                        principalColumn: "n_cuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "retiros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "date", nullable: false),
                    monto = table.Column<int>(type: "int(11)", nullable: false),
                    cliente = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retiros", x => x.id);
                    table.ForeignKey(
                        name: "retiros_ibfk_1",
                        column: x => x.cliente,
                        principalTable: "cliente",
                        principalColumn: "n_cuenta",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "latin1")
                .Annotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateIndex(
                name: "cliente",
                table: "depositos",
                column: "cliente");

            migrationBuilder.CreateIndex(
                name: "cliente1",
                table: "retiros",
                column: "cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "depositos");

            migrationBuilder.DropTable(
                name: "retiros");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
