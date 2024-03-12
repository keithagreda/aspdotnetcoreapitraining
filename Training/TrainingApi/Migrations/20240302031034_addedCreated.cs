using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApi.Migrations
{
    /// <inheritdoc />
    public partial class addedCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SalesHeaders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedStamp",
                table: "SalesHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "SalesDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedStamp",
                table: "SalesDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalesHeaders");

            migrationBuilder.DropColumn(
                name: "CreatedStamp",
                table: "SalesHeaders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "CreatedStamp",
                table: "SalesDetails");
        }
    }
}
