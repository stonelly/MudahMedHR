using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class corpactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblCorpGroup",
                type: "bit",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Corp_name",
                table: "tblCorp",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblCorp",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "a35b0863-2918-4ba1-84ae-e22e740b83f5");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "b7b40d69-eadd-4601-a512-c3f5dcf97716");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "d391daa8-314a-44b5-873b-b1245f0ba48e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "bac19f68-fcc1-4a27-a891-9f757251067b");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "88539582-bad9-4bbc-b492-417cd11fcdde", "AQAAAAEAACcQAAAAEFGSJIFqhRxsq265SsAKXhUoXUR5Yc205fqJJjng/baGdCOKLoVTAYO9GolBp7B88A==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "f34ca13a-d4f5-4df8-9371-5962f2ab98c2", new DateTime(2024, 11, 6, 0, 47, 16, 316, DateTimeKind.Local).AddTicks(5253), "AQAAAAEAACcQAAAAEF7yBRvJ8gQB2Zpui5xNfIMj8vZbDFWbwe1Lw+5/ipyiOav/apAN9lAMamxsopHkAw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0aa2df76-ed13-4bb0-b8be-39ef8dc8ad9e", "AQAAAAEAACcQAAAAEObhY0wN555nr6KMob7j77MvnlOm/fbl5Mjd7O+Ipc1+ePBuwfNKo5GFw8+o7CU8Pg==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 11, 6, 0, 47, 16, 313, DateTimeKind.Local).AddTicks(6433), new DateTime(2024, 11, 6, 0, 47, 16, 313, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 11, 6, 0, 47, 16, 313, DateTimeKind.Local).AddTicks(6311), new DateTime(2024, 11, 6, 0, 47, 16, 313, DateTimeKind.Local).AddTicks(6288) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblCorpGroup");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblCorp");

            migrationBuilder.AlterColumn<string>(
                name: "Corp_name",
                table: "tblCorp",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d137876-92a6-4ed8-91a7-4e812fc6f276", "AQAAAAEAACcQAAAAEJ8HsKZTH7AhKKuP1jHs+CJfm9237aGbWeM4u5DRCQ609ScACw1TYr9hL3/UM02XNg==" });

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f9db109d-a76b-4e60-a228-db0e204ae271", "AQAAAAEAACcQAAAAEJt0/XwPNRfnxl00nQ5L9f3goSLk6z0p4gYxMlbI/Jjh+xxcgIlxCP0fPo3JTve0XA==" });

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
    }
}
