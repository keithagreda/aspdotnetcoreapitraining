using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApi.Migrations
{
    /// <inheritdoc />
    public partial class addedSalesHeaderFKToDEtails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesHeaders_SalesHeaderid",
                table: "SalesDetails");

            migrationBuilder.AlterColumn<long>(
                name: "SalesHeaderid",
                table: "SalesDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesHeaders_SalesHeaderid",
                table: "SalesDetails",
                column: "SalesHeaderid",
                principalTable: "SalesHeaders",
                principalColumn: "SalesHeaderid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesDetails_SalesHeaders_SalesHeaderid",
                table: "SalesDetails");

            migrationBuilder.AlterColumn<long>(
                name: "SalesHeaderid",
                table: "SalesDetails",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesDetails_SalesHeaders_SalesHeaderid",
                table: "SalesDetails",
                column: "SalesHeaderid",
                principalTable: "SalesHeaders",
                principalColumn: "SalesHeaderid");
        }
    }
}
