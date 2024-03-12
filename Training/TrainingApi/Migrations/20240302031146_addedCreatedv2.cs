using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApi.Migrations
{
    /// <inheritdoc />
    public partial class addedCreatedv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SalesDetailsTemps",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedStamp",
                table: "SalesDetailsTemps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "CreatedStamp",
                table: "SalesDetailsTemps");
        }
    }
}
