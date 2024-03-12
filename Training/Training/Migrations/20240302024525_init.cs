using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesHeaders",
                columns: table => new
                {
                    SalesHeaderid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesHeaders", x => x.SalesHeaderid);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    SalesDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesHeaderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.SalesDetailsId);
                    table.ForeignKey(
                        name: "FK_SalesDetails_SalesHeaders_SalesHeaderid",
                        column: x => x.SalesHeaderid,
                        principalTable: "SalesHeaders",
                        principalColumn: "SalesHeaderid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_SalesHeaderid",
                table: "SalesDetails",
                column: "SalesHeaderid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");

            migrationBuilder.DropTable(
                name: "SalesHeaders");
        }
    }
}
