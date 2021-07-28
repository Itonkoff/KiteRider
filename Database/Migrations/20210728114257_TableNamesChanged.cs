using Microsoft.EntityFrameworkCore.Migrations;

namespace Fridge.Migrations
{
    public partial class TableNamesChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContributoryDeductions_pay_values_cd_id",
                table: "EmployeeContributoryDeductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContributoryDeductions_people_emp_id",
                table: "EmployeeContributoryDeductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeImmediateEarnings_pay_values_ie_id",
                table: "EmployeeImmediateEarnings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeImmediateEarnings_people_emp_id",
                table: "EmployeeImmediateEarnings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePeriodicEarnings_pay_values_pe_id",
                table: "EmployeePeriodicEarnings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePeriodicEarnings_people_emp_id",
                table: "EmployeePeriodicEarnings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSingleFundedDeductions_pay_values_sd_id",
                table: "EmployeeSingleFundedDeductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSingleFundedDeductions_people_emp_id",
                table: "EmployeeSingleFundedDeductions");

            migrationBuilder.DropForeignKey(
                name: "FK_pay_values_payrolls_PayrollId",
                table: "pay_values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pay_values",
                table: "pay_values");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSingleFundedDeductions",
                table: "EmployeeSingleFundedDeductions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeePeriodicEarnings",
                table: "EmployeePeriodicEarnings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeImmediateEarnings",
                table: "EmployeeImmediateEarnings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeContributoryDeductions",
                table: "EmployeeContributoryDeductions");

            migrationBuilder.RenameTable(
                name: "pay_values",
                newName: "ern_ddn");

            migrationBuilder.RenameTable(
                name: "EmployeeSingleFundedDeductions",
                newName: "emp_fds");

            migrationBuilder.RenameTable(
                name: "EmployeePeriodicEarnings",
                newName: "emp_pes");

            migrationBuilder.RenameTable(
                name: "EmployeeImmediateEarnings",
                newName: "emp_ies");

            migrationBuilder.RenameTable(
                name: "EmployeeContributoryDeductions",
                newName: "emp_cds");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "ern_ddn",
                newName: "payroll");

            migrationBuilder.RenameIndex(
                name: "IX_pay_values_PayrollId",
                table: "ern_ddn",
                newName: "IX_ern_ddn_payroll");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSingleFundedDeductions_sd_id",
                table: "emp_fds",
                newName: "IX_emp_fds_sd_id");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeePeriodicEarnings_pe_id",
                table: "emp_pes",
                newName: "IX_emp_pes_pe_id");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeImmediateEarnings_ie_id",
                table: "emp_ies",
                newName: "IX_emp_ies_ie_id");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeContributoryDeductions_cd_id",
                table: "emp_cds",
                newName: "IX_emp_cds_cd_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ern_ddn",
                table: "ern_ddn",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp_fds",
                table: "emp_fds",
                columns: new[] { "emp_id", "sd_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp_pes",
                table: "emp_pes",
                columns: new[] { "emp_id", "pe_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp_ies",
                table: "emp_ies",
                columns: new[] { "emp_id", "ie_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_emp_cds",
                table: "emp_cds",
                columns: new[] { "emp_id", "cd_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_emp_cds_ern_ddn_cd_id",
                table: "emp_cds",
                column: "cd_id",
                principalTable: "ern_ddn",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_cds_people_emp_id",
                table: "emp_cds",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_fds_ern_ddn_sd_id",
                table: "emp_fds",
                column: "sd_id",
                principalTable: "ern_ddn",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_fds_people_emp_id",
                table: "emp_fds",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_ies_ern_ddn_ie_id",
                table: "emp_ies",
                column: "ie_id",
                principalTable: "ern_ddn",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_ies_people_emp_id",
                table: "emp_ies",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_pes_ern_ddn_pe_id",
                table: "emp_pes",
                column: "pe_id",
                principalTable: "ern_ddn",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_emp_pes_people_emp_id",
                table: "emp_pes",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ern_ddn_payrolls_payroll",
                table: "ern_ddn",
                column: "payroll",
                principalTable: "payrolls",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emp_cds_ern_ddn_cd_id",
                table: "emp_cds");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_cds_people_emp_id",
                table: "emp_cds");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_fds_ern_ddn_sd_id",
                table: "emp_fds");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_fds_people_emp_id",
                table: "emp_fds");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_ies_ern_ddn_ie_id",
                table: "emp_ies");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_ies_people_emp_id",
                table: "emp_ies");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_pes_ern_ddn_pe_id",
                table: "emp_pes");

            migrationBuilder.DropForeignKey(
                name: "FK_emp_pes_people_emp_id",
                table: "emp_pes");

            migrationBuilder.DropForeignKey(
                name: "FK_ern_ddn_payrolls_payroll",
                table: "ern_ddn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ern_ddn",
                table: "ern_ddn");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emp_pes",
                table: "emp_pes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emp_ies",
                table: "emp_ies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emp_fds",
                table: "emp_fds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emp_cds",
                table: "emp_cds");

            migrationBuilder.RenameTable(
                name: "ern_ddn",
                newName: "pay_values");

            migrationBuilder.RenameTable(
                name: "emp_pes",
                newName: "EmployeePeriodicEarnings");

            migrationBuilder.RenameTable(
                name: "emp_ies",
                newName: "EmployeeImmediateEarnings");

            migrationBuilder.RenameTable(
                name: "emp_fds",
                newName: "EmployeeSingleFundedDeductions");

            migrationBuilder.RenameTable(
                name: "emp_cds",
                newName: "EmployeeContributoryDeductions");

            migrationBuilder.RenameColumn(
                name: "payroll",
                table: "pay_values",
                newName: "PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_ern_ddn_payroll",
                table: "pay_values",
                newName: "IX_pay_values_PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_emp_pes_pe_id",
                table: "EmployeePeriodicEarnings",
                newName: "IX_EmployeePeriodicEarnings_pe_id");

            migrationBuilder.RenameIndex(
                name: "IX_emp_ies_ie_id",
                table: "EmployeeImmediateEarnings",
                newName: "IX_EmployeeImmediateEarnings_ie_id");

            migrationBuilder.RenameIndex(
                name: "IX_emp_fds_sd_id",
                table: "EmployeeSingleFundedDeductions",
                newName: "IX_EmployeeSingleFundedDeductions_sd_id");

            migrationBuilder.RenameIndex(
                name: "IX_emp_cds_cd_id",
                table: "EmployeeContributoryDeductions",
                newName: "IX_EmployeeContributoryDeductions_cd_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pay_values",
                table: "pay_values",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeePeriodicEarnings",
                table: "EmployeePeriodicEarnings",
                columns: new[] { "emp_id", "pe_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeImmediateEarnings",
                table: "EmployeeImmediateEarnings",
                columns: new[] { "emp_id", "ie_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSingleFundedDeductions",
                table: "EmployeeSingleFundedDeductions",
                columns: new[] { "emp_id", "sd_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeContributoryDeductions",
                table: "EmployeeContributoryDeductions",
                columns: new[] { "emp_id", "cd_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContributoryDeductions_pay_values_cd_id",
                table: "EmployeeContributoryDeductions",
                column: "cd_id",
                principalTable: "pay_values",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContributoryDeductions_people_emp_id",
                table: "EmployeeContributoryDeductions",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeImmediateEarnings_pay_values_ie_id",
                table: "EmployeeImmediateEarnings",
                column: "ie_id",
                principalTable: "pay_values",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeImmediateEarnings_people_emp_id",
                table: "EmployeeImmediateEarnings",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePeriodicEarnings_pay_values_pe_id",
                table: "EmployeePeriodicEarnings",
                column: "pe_id",
                principalTable: "pay_values",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePeriodicEarnings_people_emp_id",
                table: "EmployeePeriodicEarnings",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSingleFundedDeductions_pay_values_sd_id",
                table: "EmployeeSingleFundedDeductions",
                column: "sd_id",
                principalTable: "pay_values",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSingleFundedDeductions_people_emp_id",
                table: "EmployeeSingleFundedDeductions",
                column: "emp_id",
                principalTable: "people",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_pay_values_payrolls_PayrollId",
                table: "pay_values",
                column: "PayrollId",
                principalTable: "payrolls",
                principalColumn: "id");
        }
    }
}
