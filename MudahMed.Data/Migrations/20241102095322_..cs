using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCodeMaster",
                columns: table => new
                {
                    CodeMaster_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodeValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CodeDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDateBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCodeMaster", x => x.CodeMaster_id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "8a018ce5-5eab-4c81-a3a6-84a96f328a52");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "02c19737-52db-49cc-ab3d-daa5e2f7afa1");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "5b6332d3-629d-401d-bc6c-4702828dcdcf");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "ea0549b3-3ac1-492a-b4e7-d931ed7ec0d0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "5d137876-92a6-4ed8-91a7-4e812fc6f276", "AQAAAAEAACcQAAAAEJ8HsKZTH7AhKKuP1jHs+CJfm9237aGbWeM4u5DRCQ609ScACw1TYr9hL3/UM02XNg==", 0 });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "9dec07be-286b-482e-9b49-34ca7da420d1", new DateTime(2024, 11, 2, 17, 53, 20, 503, DateTimeKind.Local).AddTicks(9469), "AQAAAAEAACcQAAAAEMcOv5OVgHaIYCMYFmxkGZnc4XjWtI8m9v8lnXiJrOvwzVH6n6nXJ2b3sXdOplMDrg==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "f9db109d-a76b-4e60-a228-db0e204ae271", "AQAAAAEAACcQAAAAEJt0/XwPNRfnxl00nQ5L9f3goSLk6z0p4gYxMlbI/Jjh+xxcgIlxCP0fPo3JTve0XA==", 0 });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 11, 2, 17, 53, 20, 500, DateTimeKind.Local).AddTicks(9560), new DateTime(2024, 11, 2, 17, 53, 20, 500, DateTimeKind.Local).AddTicks(9558) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 11, 2, 17, 53, 20, 500, DateTimeKind.Local).AddTicks(9524), new DateTime(2024, 11, 2, 17, 53, 20, 500, DateTimeKind.Local).AddTicks(9499) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCodeMaster");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "cc7e80ea-53a3-4da9-84c8-9497c77b90a2", "AQAAAAEAACcQAAAAEKIhHCgvh8DGtxxzCQsFuBJsX6wG0nEQD5e1mA82gBC7RSTh7IRVqOlLlPloxpSy1w==", -1 });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Status" },
                values: new object[] { "3ffcc3ed-3ec3-48f7-9f8f-85c6be4a70b8", "AQAAAAEAACcQAAAAEEHjbUmnZj+KmPnVHE1Hi+g6HOO1Vkbt6XWa3T8B3q+o3mJGEEunNGZtFzwuVwR9eg==", -1 });

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
        }
    }
}
