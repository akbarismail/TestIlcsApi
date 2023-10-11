using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestIlcsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_country",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "NVarchar(50)", nullable: true),
                    code = table.Column<string>(type: "NVarchar(10)", nullable: true),
                    @char = table.Column<string>(name: "char", type: "NVarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code_product = table.Column<string>(type: "NVarchar(10)", nullable: true),
                    name = table.Column<string>(type: "NVarchar(50)", nullable: true),
                    price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_harbour",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "NVarchar(50)", nullable: true),
                    country_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    @char = table.Column<string>(name: "char", type: "NVarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_harbour", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_harbour_m_country_country_id",
                        column: x => x.country_id,
                        principalTable: "m_country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "m_ppn",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    percent = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_ppn", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_ppn_m_product_product_id",
                        column: x => x.product_id,
                        principalTable: "m_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_harbour_country_id",
                table: "m_harbour",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_m_ppn_product_id",
                table: "m_ppn",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_harbour");

            migrationBuilder.DropTable(
                name: "m_ppn");

            migrationBuilder.DropTable(
                name: "m_country");

            migrationBuilder.DropTable(
                name: "m_product");
        }
    }
}
