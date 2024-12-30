using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class appuserremovefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_AppUsers_RefId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "ClinicID1",
                table: "AppUsers",
                newName: "ClinicID");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ClinicID1",
                table: "AppUsers",
                newName: "IX_AppUsers_ClinicID");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "c9cd37fb-8b44-4086-a6f0-10b019f6f41d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "73ce758c-a918-4019-96fd-23b03c5b13ca");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "e714816d-13a6-4f0a-a41f-6d8034b105d7");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "dd5779d6-adf9-4d29-84c3-2dd13231b2a9");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64a5b662-bf1a-4b70-b248-eefedc4632e4", "AQAAAAEAACcQAAAAEIq/soaswdfquyJkmqebCA9HIipOIp0ri5dBaKKdSAQ1UkD1M4uNJSyvM9J6QzeOjA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "1929cf72-c91e-4fdb-91bd-bbbc96bab01c", new DateTime(2024, 12, 23, 17, 36, 14, 313, DateTimeKind.Local).AddTicks(288), "AQAAAAEAACcQAAAAECGM0dgTYVaq9immoMoqsDB38r3FinGaskIksF+cvzSiQOyY28f3hMq/pIhWIIzPWw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "582e9058-fbb9-4117-a217-d3bb62318422", "AQAAAAEAACcQAAAAEBqZZAheqVud6PLe7gPulCH6MyECRryY+eW2kJ99kusqQTPhEbqYPC2g8G1+dK8FFQ==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 36, 14, 311, DateTimeKind.Local).AddTicks(1623), new DateTime(2024, 12, 23, 17, 36, 14, 311, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 36, 14, 311, DateTimeKind.Local).AddTicks(1603), new DateTime(2024, 12, 23, 17, 36, 14, 311, DateTimeKind.Local).AddTicks(1580) });

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblClinic_ClinicID",
                table: "AppUsers",
                column: "ClinicID",
                principalTable: "tblClinic",
                principalColumn: "ClinicID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_tblCorp_CorpID",
                table: "AppUsers",
                column: "CorpID",
                principalTable: "tblCorp",
                principalColumn: "CorpID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblClinic_ClinicID",
                table: "AppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_tblCorp_CorpID",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "ClinicID",
                table: "AppUsers",
                newName: "ClinicID1");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_ClinicID",
                table: "AppUsers",
                newName: "IX_AppUsers_ClinicID1");

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
    }
}
