using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementAPI.Migrations
{
    public partial class updatesalarys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "SalaryReports",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryReports_UserEmail",
                table: "SalaryReports",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryReports_Users_UserEmail",
                table: "SalaryReports",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryReports_Users_UserEmail",
                table: "SalaryReports");

            migrationBuilder.DropIndex(
                name: "IX_SalaryReports_UserEmail",
                table: "SalaryReports");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "SalaryReports");
        }
    }
}
