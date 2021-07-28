using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fridge.Migrations
{
    public partial class EarningsDeductionsReestablished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_payroll_pay_specs_pay_spec_id",
                table: "employee_payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_payroll_payrolls_payroll_id",
                table: "employee_payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_payroll_people_employee_id",
                table: "employee_payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_pay_values_employee_payroll_d_employee_d_payroll_d_pay_spec",
                table: "pay_values");

            migrationBuilder.DropForeignKey(
                name: "FK_pay_values_employee_payroll_e_employee_e_payroll_e_pay_spec",
                table: "pay_values");

            migrationBuilder.DropTable(
                name: "pay_specs");

            migrationBuilder.DropTable(
                name: "spouses");

            migrationBuilder.DropIndex(
                name: "IX_pay_values_d_employee_d_payroll_d_pay_spec",
                table: "pay_values");

            migrationBuilder.DropIndex(
                name: "IX_pay_values_e_employee_e_payroll_e_pay_spec",
                table: "pay_values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee_payroll",
                table: "employee_payroll");

            migrationBuilder.DropIndex(
                name: "IX_employee_payroll_pay_spec_id",
                table: "employee_payroll");

            migrationBuilder.DropColumn(
                name: "d_employee",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "d_pay_spec",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "d_payroll",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "e_employee",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "e_pay_spec",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "pay_spec_id",
                table: "employee_payroll");

            migrationBuilder.RenameColumn(
                name: "o_contribution",
                table: "pay_values",
                newName: "org_cont");

            migrationBuilder.RenameColumn(
                name: "e_payroll",
                table: "pay_values",
                newName: "PayrollId");

            migrationBuilder.RenameColumn(
                name: "e_contribution",
                table: "pay_values",
                newName: "emp_cont");

            migrationBuilder.RenameColumn(
                name: "payroll_id",
                table: "employee_payroll",
                newName: "roll_id");

            migrationBuilder.RenameColumn(
                name: "employee_id",
                table: "employee_payroll",
                newName: "emp_id");

            migrationBuilder.RenameIndex(
                name: "IX_employee_payroll_payroll_id",
                table: "employee_payroll",
                newName: "IX_employee_payroll_roll_id");

            migrationBuilder.AlterColumn<int>(
                name: "marital_status",
                table: "people",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "emp",
                table: "people",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nu_emp",
                table: "payrolls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "org_cont",
                table: "pay_values",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "PayrollId",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "emp_cont",
                table: "pay_values",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "period",
                table: "pay_values",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "organisations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reg_number",
                table: "organisations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee_payroll",
                table: "employee_payroll",
                columns: new[] { "emp_id", "roll_id" });

            migrationBuilder.CreateTable(
                name: "EmployeeContributoryDeductions",
                columns: table => new
                {
                    emp_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cd_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContributoryDeductions", x => new { x.emp_id, x.cd_id });
                    table.ForeignKey(
                        name: "FK_EmployeeContributoryDeductions_pay_values_cd_id",
                        column: x => x.cd_id,
                        principalTable: "pay_values",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EmployeeContributoryDeductions_people_emp_id",
                        column: x => x.emp_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeImmediateEarnings",
                columns: table => new
                {
                    emp_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ie_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeImmediateEarnings", x => new { x.emp_id, x.ie_id });
                    table.ForeignKey(
                        name: "FK_EmployeeImmediateEarnings_pay_values_ie_id",
                        column: x => x.ie_id,
                        principalTable: "pay_values",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EmployeeImmediateEarnings_people_emp_id",
                        column: x => x.emp_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeePeriodicEarnings",
                columns: table => new
                {
                    emp_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pe_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePeriodicEarnings", x => new { x.emp_id, x.pe_id });
                    table.ForeignKey(
                        name: "FK_EmployeePeriodicEarnings_pay_values_pe_id",
                        column: x => x.pe_id,
                        principalTable: "pay_values",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EmployeePeriodicEarnings_people_emp_id",
                        column: x => x.emp_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSingleFundedDeductions",
                columns: table => new
                {
                    emp_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sd_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSingleFundedDeductions", x => new { x.emp_id, x.sd_id });
                    table.ForeignKey(
                        name: "FK_EmployeeSingleFundedDeductions_pay_values_sd_id",
                        column: x => x.sd_id,
                        principalTable: "pay_values",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EmployeeSingleFundedDeductions_people_emp_id",
                        column: x => x.emp_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_people_emp",
                table: "people",
                column: "emp");

            migrationBuilder.CreateIndex(
                name: "IX_pay_values_PayrollId",
                table: "pay_values",
                column: "PayrollId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContributoryDeductions_cd_id",
                table: "EmployeeContributoryDeductions",
                column: "cd_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImmediateEarnings_ie_id",
                table: "EmployeeImmediateEarnings",
                column: "ie_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePeriodicEarnings_pe_id",
                table: "EmployeePeriodicEarnings",
                column: "pe_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSingleFundedDeductions_sd_id",
                table: "EmployeeSingleFundedDeductions",
                column: "sd_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_payroll_payrolls_roll_id",
                table: "employee_payroll",
                column: "roll_id",
                principalTable: "payrolls",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_payroll_people_emp_id",
                table: "employee_payroll",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_pay_values_payrolls_PayrollId",
                table: "pay_values",
                column: "PayrollId",
                principalTable: "payrolls",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_people_people_emp",
                table: "people",
                column: "emp",
                principalTable: "people",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_payroll_payrolls_roll_id",
                table: "employee_payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_payroll_people_emp_id",
                table: "employee_payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_pay_values_payrolls_PayrollId",
                table: "pay_values");

            migrationBuilder.DropForeignKey(
                name: "FK_people_people_emp",
                table: "people");

            migrationBuilder.DropTable(
                name: "EmployeeContributoryDeductions");

            migrationBuilder.DropTable(
                name: "EmployeeImmediateEarnings");

            migrationBuilder.DropTable(
                name: "EmployeePeriodicEarnings");

            migrationBuilder.DropTable(
                name: "EmployeeSingleFundedDeductions");

            migrationBuilder.DropIndex(
                name: "IX_people_emp",
                table: "people");

            migrationBuilder.DropIndex(
                name: "IX_pay_values_PayrollId",
                table: "pay_values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employee_payroll",
                table: "employee_payroll");

            migrationBuilder.DropColumn(
                name: "emp",
                table: "people");

            migrationBuilder.DropColumn(
                name: "nu_emp",
                table: "payrolls");

            migrationBuilder.DropColumn(
                name: "period",
                table: "pay_values");

            migrationBuilder.DropColumn(
                name: "country",
                table: "organisations");

            migrationBuilder.DropColumn(
                name: "reg_number",
                table: "organisations");

            migrationBuilder.RenameColumn(
                name: "org_cont",
                table: "pay_values",
                newName: "o_contribution");

            migrationBuilder.RenameColumn(
                name: "emp_cont",
                table: "pay_values",
                newName: "e_contribution");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "pay_values",
                newName: "e_payroll");

            migrationBuilder.RenameColumn(
                name: "roll_id",
                table: "employee_payroll",
                newName: "payroll_id");

            migrationBuilder.RenameColumn(
                name: "emp_id",
                table: "employee_payroll",
                newName: "employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_employee_payroll_roll_id",
                table: "employee_payroll",
                newName: "IX_employee_payroll_payroll_id");

            migrationBuilder.AlterColumn<int>(
                name: "marital_status",
                table: "people",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "o_contribution",
                table: "pay_values",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "e_contribution",
                table: "pay_values",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "e_payroll",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "d_employee",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "d_pay_spec",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "d_payroll",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "e_employee",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "e_pay_spec",
                table: "pay_values",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "pay_spec_id",
                table: "employee_payroll",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_employee_payroll",
                table: "employee_payroll",
                columns: new[] { "employee_id", "payroll_id", "pay_spec_id" });

            migrationBuilder.CreateTable(
                name: "pay_specs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    base_amt = table.Column<double>(type: "float", nullable: false),
                    period = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pay_specs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spouses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    national_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spouses", x => x.id);
                    table.ForeignKey(
                        name: "FK_spouses_people_employee",
                        column: x => x.employee,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pay_values_d_employee_d_payroll_d_pay_spec",
                table: "pay_values",
                columns: new[] { "d_employee", "d_payroll", "d_pay_spec" });

            migrationBuilder.CreateIndex(
                name: "IX_pay_values_e_employee_e_payroll_e_pay_spec",
                table: "pay_values",
                columns: new[] { "e_employee", "e_payroll", "e_pay_spec" });

            migrationBuilder.CreateIndex(
                name: "IX_employee_payroll_pay_spec_id",
                table: "employee_payroll",
                column: "pay_spec_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_spouses_employee",
                table: "spouses",
                column: "employee");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_payroll_pay_specs_pay_spec_id",
                table: "employee_payroll",
                column: "pay_spec_id",
                principalTable: "pay_specs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_payroll_payrolls_payroll_id",
                table: "employee_payroll",
                column: "payroll_id",
                principalTable: "payrolls",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_payroll_people_employee_id",
                table: "employee_payroll",
                column: "employee_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_pay_values_employee_payroll_d_employee_d_payroll_d_pay_spec",
                table: "pay_values",
                columns: new[] { "d_employee", "d_payroll", "d_pay_spec" },
                principalTable: "employee_payroll",
                principalColumns: new[] { "employee_id", "payroll_id", "pay_spec_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_pay_values_employee_payroll_e_employee_e_payroll_e_pay_spec",
                table: "pay_values",
                columns: new[] { "e_employee", "e_payroll", "e_pay_spec" },
                principalTable: "employee_payroll",
                principalColumns: new[] { "employee_id", "payroll_id", "pay_spec_id" });
        }
    }
}
