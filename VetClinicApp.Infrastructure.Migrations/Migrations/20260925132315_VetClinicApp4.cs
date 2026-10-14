using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicApp.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class VetClinicApp4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Time",
                table: "Appointments",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Appointments");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Time",
                table: "Appointments",
                type: "time",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");
        }
    }
}
