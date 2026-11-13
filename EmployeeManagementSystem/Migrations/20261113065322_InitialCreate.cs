using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementSystem.Migrations;

/// <inheritdoc />
public partial class _20261113065322_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Email = table.Column<string>(type: "TEXT", nullable: false),
                EmpPhone = table.Column<string>(type: "TEXT", nullable: false),
                Salary = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Leaves",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                LeaveType = table.Column<string>(type: "TEXT", nullable: false),
                FromDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                ToDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                Reason = table.Column<string>(type: "TEXT", nullable: false),
                Status = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Leaves", x => x.Id);
                table.ForeignKey(
                    name: "FK_Leaves_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Leaves_EmployeeId",
            table: "Leaves",
            column: "EmployeeId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Leaves");

        migrationBuilder.DropTable(
            name: "Employees");
    }
}
