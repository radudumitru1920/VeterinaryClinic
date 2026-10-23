using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetClinicApp.Infrastructure.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class VetClinicApp12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistantRequests_Staffs_staffID",
                table: "AssistantRequests");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_AssistantRequests_staffID",
                table: "AssistantRequests");

            migrationBuilder.DropColumn(
                name: "staffID",
                table: "AssistantRequests");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "role");

            migrationBuilder.AddColumn<string>(
                name: "StaffLastName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffLastName",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Users",
                newName: "Role");

            migrationBuilder.AddColumn<int>(
                name: "staffID",
                table: "AssistantRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    staffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.staffID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistantRequests_staffID",
                table: "AssistantRequests",
                column: "staffID");

            migrationBuilder.AddForeignKey(
                name: "FK_AssistantRequests_Staffs_staffID",
                table: "AssistantRequests",
                column: "staffID",
                principalTable: "Staffs",
                principalColumn: "staffID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
