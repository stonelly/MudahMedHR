using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudahMed.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "5b893c50-f9cd-41f7-beb1-854668f41297");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "89c499c4-1341-4628-8fce-8d27c9c72526");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "3bfdf45c-1172-49ff-96a5-9cef9a7936b3");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "175e203a-adb9-4f71-be83-6605c1256901");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8dcde488-9d32-40e4-a13e-0ba3c4e7b38a", "AQAAAAEAACcQAAAAEDAXsU05KOYOc2ct6RtsPtnsy1o1ZmwWeXhIHJqFbtMCaBzMq7UL2WcBUNjynf3nFw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "74976ecb-fc1b-4a3b-8f33-f96d6068a4e6", new DateTime(2025, 1, 20, 4, 1, 15, 714, DateTimeKind.Local).AddTicks(4940), "AQAAAAEAACcQAAAAEManP0cFHj3BzAdCYpIFALPSZTy4ErRQ4MtMD3SMDPpbHpZRUJHsD4iu/tV0hpIm6g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d714d97e-5471-442a-8df6-5d589255fac4", "AQAAAAEAACcQAAAAEAuByjS24E/zhHwtVfZdMs1/frzrn9Q/nJiApB5FJAIc2onj38nlLV8O7t42LXuBkw==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2025, 1, 20, 4, 1, 15, 712, DateTimeKind.Local).AddTicks(6077), new DateTime(2025, 1, 20, 4, 1, 15, 712, DateTimeKind.Local).AddTicks(6076) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2025, 1, 20, 4, 1, 15, 712, DateTimeKind.Local).AddTicks(6042), new DateTime(2025, 1, 20, 4, 1, 15, 712, DateTimeKind.Local).AddTicks(6019) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("376c1d1e-0b04-47da-9657-a2a87faf0a59"),
                column: "ConcurrencyStamp",
                value: "5b92edb4-f2e1-453b-84ab-da92749b7ad5");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e233be7-c199-4567-9c07-9271a9de4c64"),
                column: "ConcurrencyStamp",
                value: "747509d5-8d9c-4eea-a6f0-0e0a7e49cb49");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f685d0f-bd6f-44dd-ab60-c606952eb2a8"),
                column: "ConcurrencyStamp",
                value: "0aea8169-1d6e-41d1-9df3-cc99a8319416");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b448a7dc-54c6-4060-90f0-86965c07e8f0"),
                column: "ConcurrencyStamp",
                value: "c15602e6-525d-4c70-bdac-501107f5d082");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("31986efe-9171-44e7-8503-1b4c8f9c1d1b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5cb0634-3296-432e-9f3f-bce52d38cecb", "AQAAAAEAACcQAAAAEHlbuSbBucjcEUjluwjJR6ff6fvFi7AmYjycLGh2H3WxRudI1b5lT8oO7Z0AWu5rBA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("769f41bd-ccd4-45ba-abbd-550ccd0b62e3"),
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash" },
                values: new object[] { "0a244aee-c7da-41c6-a859-24d2097e693f", new DateTime(2025, 1, 20, 3, 55, 31, 968, DateTimeKind.Local).AddTicks(9670), "AQAAAAEAACcQAAAAEIOOCeG1lPKjfVueOAr+nTJQfqpV1W1/p1dN6Ndswn2hDvmUtUe1RRypJaNyo0pxdA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("faed90a2-9f7d-411a-8119-0fa3a668e660"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b94b5544-2c87-42bd-9757-74c98b99f8dc", "AQAAAAEAACcQAAAAED3Hka11ojZPkLdgErM8vIlGOXvrA/fQne3jF1UgfSK5Y7X7EdhrRrwuHt3Cn4ArMg==" });

            migrationBuilder.UpdateData(
                table: "tblCorp",
                keyColumn: "CorpID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2025, 1, 20, 3, 55, 31, 966, DateTimeKind.Local).AddTicks(8445), new DateTime(2025, 1, 20, 3, 55, 31, 966, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "tblCorpGroup",
                keyColumn: "CorpGroupID",
                keyValue: 1,
                columns: new[] { "LastModifiedDate", "createdDate" },
                values: new object[] { new DateTime(2025, 1, 20, 3, 55, 31, 966, DateTimeKind.Local).AddTicks(8404), new DateTime(2025, 1, 20, 3, 55, 31, 966, DateTimeKind.Local).AddTicks(8379) });
        }
    }
}
