using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    PAN = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1500)", nullable: false),
                    DOJ = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhotoFileName = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryReports",
                columns: table => new
                {
                    PAN = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DOJ = table.Column<DateTime>(type: "Date", nullable: false),
                    PFAccount = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UAN = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    AvailableDays = table.Column<int>(type: "int", nullable: false),
                    PaidDays = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryReports", x => x.PAN);
                    table.ForeignKey(
                        name: "FK_SalaryReports_Users_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "Users",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryReports_UserEmail",
                table: "SalaryReports",
                column: "UserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryReports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
