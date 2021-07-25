using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fridge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organisations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organisations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pay_specs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    period = table.Column<int>(type: "int", nullable: false),
                    base_amt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pay_specs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    national_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passport_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marital_status = table.Column<int>(type: "int", nullable: false),
                    home_tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cell = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    home_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postal_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_hired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payrolls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pay_date = table.Column<int>(type: "int", nullable: false),
                    last_run = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    organisation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payrolls", x => x.id);
                    table.ForeignKey(
                        name: "FK_payrolls_organisations_organisation",
                        column: x => x.organisation,
                        principalTable: "organisations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bank_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branch_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    split = table.Column<double>(type: "float", nullable: false, defaultValue: 100.0),
                    account_holder = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_details", x => x.id);
                    table.ForeignKey(
                        name: "FK_bank_details_people_account_holder",
                        column: x => x.account_holder,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "spouses",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    national_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "employee_payroll",
                columns: table => new
                {
                    employee_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    payroll_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pay_spec_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_payroll", x => new { x.employee_id, x.payroll_id, x.pay_spec_id });
                    table.ForeignKey(
                        name: "FK_employee_payroll_pay_specs_pay_spec_id",
                        column: x => x.pay_spec_id,
                        principalTable: "pay_specs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employee_payroll_payrolls_payroll_id",
                        column: x => x.payroll_id,
                        principalTable: "payrolls",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_employee_payroll_people_employee_id",
                        column: x => x.employee_id,
                        principalTable: "people",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pay_values",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    e_contribution = table.Column<double>(type: "float", nullable: false),
                    o_contribution = table.Column<double>(type: "float", nullable: false),
                    reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    d_employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    d_payroll = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    d_pay_spec = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    e_employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    e_payroll = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    e_pay_spec = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pay_values", x => x.id);
                    table.ForeignKey(
                        name: "FK_pay_values_employee_payroll_d_employee_d_payroll_d_pay_spec",
                        columns: x => new { x.d_employee, x.d_payroll, x.d_pay_spec },
                        principalTable: "employee_payroll",
                        principalColumns: new[] { "employee_id", "payroll_id", "pay_spec_id" });
                    table.ForeignKey(
                        name: "FK_pay_values_employee_payroll_e_employee_e_payroll_e_pay_spec",
                        columns: x => new { x.e_employee, x.e_payroll, x.e_pay_spec },
                        principalTable: "employee_payroll",
                        principalColumns: new[] { "employee_id", "payroll_id", "pay_spec_id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_bank_details_account_holder",
                table: "bank_details",
                column: "account_holder");

            migrationBuilder.CreateIndex(
                name: "IX_employee_payroll_pay_spec_id",
                table: "employee_payroll",
                column: "pay_spec_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_payroll_payroll_id",
                table: "employee_payroll",
                column: "payroll_id");

            migrationBuilder.CreateIndex(
                name: "IX_pay_values_d_employee_d_payroll_d_pay_spec",
                table: "pay_values",
                columns: new[] { "d_employee", "d_payroll", "d_pay_spec" });

            migrationBuilder.CreateIndex(
                name: "IX_pay_values_e_employee_e_payroll_e_pay_spec",
                table: "pay_values",
                columns: new[] { "e_employee", "e_payroll", "e_pay_spec" });

            migrationBuilder.CreateIndex(
                name: "IX_payrolls_organisation",
                table: "payrolls",
                column: "organisation");

            migrationBuilder.CreateIndex(
                name: "IX_spouses_employee",
                table: "spouses",
                column: "employee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_details");

            migrationBuilder.DropTable(
                name: "pay_values");

            migrationBuilder.DropTable(
                name: "spouses");

            migrationBuilder.DropTable(
                name: "employee_payroll");

            migrationBuilder.DropTable(
                name: "pay_specs");

            migrationBuilder.DropTable(
                name: "payrolls");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "organisations");
        }
    }
}
