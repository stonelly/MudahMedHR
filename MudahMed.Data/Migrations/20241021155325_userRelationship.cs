using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class userRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicID1",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorpID",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "304364c2-26dc-4250-83e2-7a073eeba12f");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "09565143-16a5-4109-8ced-051e4d7d7794");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "d59d9765-d884-4842-ae8e-78f0457b4a95");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "e19750ee-1457-4bbb-b14e-f87a96a7eab1");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc7e80ea-53a3-4da9-84c8-9497c77b90a2", "AQAAAAEAACcQAAAAEKIhHCgvh8DGtxxzCQsFuBJsX6wG0nEQD5e1mA82gBC7RSTh7IRVqOlLlPloxpSy1w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "5a388e0d-77e3-47ed-8f01-580996330ef4", new DateTime(2024, 10, 21, 23, 53, 24, 321, DateTimeKind.Local).AddTicks(6572), "AQAAAAEAACcQAAAAEDcLhRbkDFNenVwOxs2qm0D1tS18IG78h6gNiD9eLboCBglp2/tK2cez6tDXzdl1Vg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3ffcc3ed-3ec3-48f7-9f8f-85c6be4a70b8", "AQAAAAEAACcQAAAAEEHjbUmnZj+KmPnVHE1Hi+g6HOO1Vkbt6XWa3T8B3q+o3mJGEEunNGZtFzwuVwR9eg==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 10, 21, 23, 53, 24, 319, DateTimeKind.Local).AddTicks(7971), new DateTime(2024, 10, 21, 23, 53, 24, 319, DateTimeKind.Local).AddTicks(7970) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 10, 21, 23, 53, 24, 319, DateTimeKind.Local).AddTicks(7946), new DateTime(2024, 10, 21, 23, 53, 24, 319, DateTimeKind.Local).AddTicks(7933) });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ClinicID1",
                table: "AppUsers",
                column: "ClinicID1");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CorpID",
                table: "AppUsers",
                column: "CorpID");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RefId",
                table: "AppUsers",
                column: "RefId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblClinic_ClinicID1",
                table: "AppUsers",
                column: "ClinicID1",
                principalTable: "tblClinic",
                principalColumn: "ClinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblClinic_RefId",
                table: "AppUsers",
                column: "RefId",
                principalTable: "tblClinic",
                principalColumn: "ClinicID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblCorp_CorpID",
                table: "AppUsers",
                column: "CorpID",
                principalTable: "tblCorp",
                principalColumn: "CorpID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblCorp_RefId",
                table: "AppUsers",
                column: "RefId",
                principalTable: "tblCorp",
                principalColumn: "CorpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblClinic_ClinicID1",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblClinic_RefId",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblCorp_CorpID",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblCorp_RefId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_ClinicID1",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CorpID",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_RefId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ClinicID1",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CorpID",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "58cac793-36e0-4d9e-88e5-d5af2ba6a1c2");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "ae808944-13f5-4909-aa73-82a1a2a2cb4c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "9813a41e-55a0-454b-8e47-3b3b39b65527");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "ee1a11a0-d39b-4907-9f68-ddeffe2ff191");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bdfe1f0e-99e3-4a61-9a26-1aa8c901c997", "AQAAAAEAACcQAAAAEGziLUejJiTruwTrW+L1MWUfxBweTtiV765PRs4Yeur/dNhbI5AJ/OvmVS/bUMch6Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "ca5bcd90-cea6-4b8c-b3a7-2911c0d6bdca", new DateTime(2024, 10, 12, 1, 34, 2, 281, DateTimeKind.Local).AddTicks(3422), "AQAAAAEAACcQAAAAEJllC7hr4wwQHtFp0UwxRjbbyoWOOZ/wneHiQUu7uHT5mmuQvyWN+tQ+cdKbbOYABg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6dd2a859-8906-4190-9e8b-44ad689f90db", "AQAAAAEAACcQAAAAEIEJbh1qh0Bsi6/9r4DAS6W8v6qrEWoJt2ee5SlXenHtR9OIF2xeGhFwzDrV4WZbzA==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(761), new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(759) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(739), new DateTime(2024, 10, 12, 1, 34, 2, 271, DateTimeKind.Local).AddTicks(726) });
        }
    }
}
