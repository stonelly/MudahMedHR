using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class corptables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCorpGroup",
                columns: table => new
                {
                    CorpGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Addr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Addr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCorpGroup", x => x.CorpGroupID);
                });

            migrationBuilder.CreateTable(
                name: "tblCorp",
                columns: table => new
                {
                    CorpID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorpName = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CorpAddr1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CorpAddr2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CorpAddr3 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CorpContactNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorpFax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CorpRegNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CorpTIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BankAccNo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CorpGroupID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    FinanceEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsSuspend = table.Column<bool>(type: "bit", nullable: false),
                    IndustryField = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCorp", x => x.CorpID);
                    table.ForeignKey(
                        name: "FK_tblCorp_tblCorpGroup_CorpGroupID",
                        column: x => x.CorpGroupID,
                        principalTable: "tblCorpGroup",
                        principalColumn: "CorpGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "6f0dc847-71e5-4755-9b9a-d543fb0b9208");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "852d45f4-d9ca-481f-b519-28d0f1ce4e50");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "3c4ece07-afd5-43e3-801c-5626c8c10dc9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "e372659a-8364-4bd4-a7d9-0d24c35e7c5a", new DateTime(2024, 10, 9, 3, 10, 43, 106, DateTimeKind.Local).AddTicks(4733), "AQAAAAEAACcQAAAAEIPwE0Laft17NMMQyqp+ZnsxCeuHXECSjtGGI89a8k8m23/zLQYiilWwZawlC+opNg==" });

            migrationBuilder.CreateIndex(
                name: "IX_tblCorp_CorpGroupID",
                table: "tblCorp",
                column: "CorpGroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCorp");

            migrationBuilder.DropTable(
                name: "tblCorpGroup");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "bb760d45-ef93-4c5e-aa36-524ea4960072");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "dad3c18c-1340-4da2-88b0-f15c9bf65d22");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "8d681dff-b911-4aea-bb97-3be17ba95e48");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash" },
                values: new object[] { "e6d2c4d0-3172-4dff-8c92-499dfe6597a0", new DateTime(2023, 7, 8, 2, 55, 16, 64, DateTimeKind.Local).AddTicks(9520), "AQAAAAEAACcQAAAAEAfXXQh97Y9dgVTzTXk4vJqMeZfUhIdwZ/EDrZOayS3pdscyowtYHMs4yu6Mg7ch3w==" });
        }
    }
}
