using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicApp.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class VetClinicApp11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetName",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false);
            
            migrationBuilder.AddColumn<string>(
                name: "PetType",
                table: "Appointments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "PetBreed",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pets",
                newName: "PetName");

           migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pets",
                newName: "PetBreed");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Pets",
                newName: "PetType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PetType",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PetBreed",
                table: "Appointments");
            
            migrationBuilder.RenameColumn(
                name: "PetName",
                table: "Pets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PetBreed",
                table: "Pets",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "PetType",
                table: "Pets",
                newName: "Type");
        }
    }
}
