using Microsoft.EntityFrameworkCore.Migrations;

namespace DAH_FIMS.Migrations
{
    public partial class TablesModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUEST_SYSTEM_ADMIN",
                table: "REQUEST");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKLOAD_FACULTY",
                table: "WORKLOAD");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneExtension",
                table: "EMPLOYEE",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_REQUEST_SYSTEM_ADMIN",
                table: "REQUEST",
                column: "EmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKLOAD_FACULTY",
                table: "WORKLOAD",
                column: "EmployeeId",
                principalTable: "EMPLOYEE",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKLOAD_FACULTY_EmployeeId",
                table: "WORKLOAD",
                column: "EmployeeId",
                principalTable: "FACULTY",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_REQUEST_SYSTEM_ADMIN",
                table: "REQUEST");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKLOAD_FACULTY",
                table: "WORKLOAD");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKLOAD_FACULTY_EmployeeId",
                table: "WORKLOAD");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneExtension",
                table: "EMPLOYEE",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_REQUEST_SYSTEM_ADMIN",
                table: "REQUEST",
                column: "EmployeeId",
                principalTable: "SYSTEM_ADMIN",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKLOAD_FACULTY",
                table: "WORKLOAD",
                column: "EmployeeId",
                principalTable: "FACULTY",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
