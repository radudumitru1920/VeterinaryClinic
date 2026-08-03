using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicApp.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateFix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NrTelefon",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nume",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClientDoctor",
                columns: table => new
                {
                    staffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    staffID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDoctor", x => x.staffID);
                    table.ForeignKey(
                        name: "FK_ClientDoctor_Staffs_staffID1",
                        column: x => x.staffID1,
                        principalTable: "Staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_clientID",
                table: "Appointments",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDoctor_staffID1",
                table: "ClientDoctor",
                column: "staffID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clients_clientID",
                table: "Appointments",
                column: "clientID",
                principalTable: "Clients",
                principalColumn: "clientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clients_clientID",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "ClientDoctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_clientID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NrTelefon",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Nume",
                table: "Appointments");
        }
    }
}
