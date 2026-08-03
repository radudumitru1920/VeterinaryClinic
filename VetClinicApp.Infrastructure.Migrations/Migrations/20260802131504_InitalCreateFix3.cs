using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicApp.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreateFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientID",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_clientID",
                table: "Pets",
                column: "clientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Clients_clientID",
                table: "Pets",
                column: "clientID",
                principalTable: "Clients",
                principalColumn: "clientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Clients_clientID",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_clientID",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "clientID",
                table: "Pets");
        }
    }
}
