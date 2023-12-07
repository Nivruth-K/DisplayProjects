using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InterviewScheduler_2.Migrations
{
    /// <inheritdoc />
    public partial class datetimer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("2b2a7e95-548f-40dd-94b4-7f4ddbb55c88"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("9df6b7aa-3573-404e-809e-606ea106b17c"));

            migrationBuilder.DropColumn(
                name: "Scheduled_Time",
                table: "Schedule");

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "CompanyAddress", "CompanyCity", "CompanyName" },
                values: new object[,]
                {
                    { new Guid("50fbb8ea-dbda-42e8-897b-3458debb5a55"), "Test Address1", "TestCity1", "TestCompany1" },
                    { new Guid("89a8e730-9275-40a3-8d45-25c3639ffd21"), "Test Address2", "TestCity2", "TestCompany1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("50fbb8ea-dbda-42e8-897b-3458debb5a55"));

            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "CompanyId",
                keyValue: new Guid("89a8e730-9275-40a3-8d45-25c3639ffd21"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Scheduled_Time",
                table: "Schedule",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "CompanyAddress", "CompanyCity", "CompanyName" },
                values: new object[,]
                {
                    { new Guid("2b2a7e95-548f-40dd-94b4-7f4ddbb55c88"), "Test Address1", "TestCity1", "TestCompany1" },
                    { new Guid("9df6b7aa-3573-404e-809e-606ea106b17c"), "Test Address2", "TestCity2", "TestCompany1" }
                });
        }
    }
}
