using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace olShop.Data.EF.Migrations
{
    public partial class update_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AdvertistmentPages",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("af186d00-6d93-4721-ac73-46a8d968c8ed"),
                column: "ConcurrencyStamp",
                value: "7e179ef4-0e38-4afe-9d60-8951b5639947");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a389bfc2-ed92-4fb5-8705-fd0cb5b48b48"),
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash" },
                values: new object[] { "f33a02df-aa73-41bd-9961-d578c02589b9", new DateTime(2020, 3, 12, 0, 55, 10, 706, DateTimeKind.Local).AddTicks(9417), new DateTime(2020, 3, 12, 0, 55, 10, 707, DateTimeKind.Local).AddTicks(7506), "AQAAAAEAACcQAAAAEBqqOIzHk9GZYqUhNp76tngfejYe2qWORjdBCK7lHNxdlDG15lJUlB2c0O04hzctnw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(4619), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8058), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8124), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8127), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8129), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8131), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8133), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8135), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8136), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8138), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8141), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8143), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8145), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8147), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8149), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8151), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8153), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8155), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8157), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 55, 10, 726, DateTimeKind.Local).AddTicks(8159), 1000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AdvertistmentPages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("af186d00-6d93-4721-ac73-46a8d968c8ed"),
                column: "ConcurrencyStamp",
                value: "568f2f0a-e24b-410d-a0ad-c1bb8558d6a4");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("a389bfc2-ed92-4fb5-8705-fd0cb5b48b48"),
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateModified", "PasswordHash" },
                values: new object[] { "06f74b37-6817-4588-a921-792f46ded18d", new DateTime(2020, 3, 12, 0, 42, 24, 955, DateTimeKind.Local).AddTicks(4079), new DateTime(2020, 3, 12, 0, 42, 24, 956, DateTimeKind.Local).AddTicks(1309), "AQAAAAEAACcQAAAAEEGX6/qr1ZF2OuXaSbjZxKPZY6R4FpU2U2p2RM5sAZCU7pn5MCXEnwoPXEuVuX7UBA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(2965), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5575), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5624), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5626), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5628), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5631), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5634), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5636), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5638), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5640), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5642), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5644), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5646), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5648), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5650), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5652), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5655), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5657), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5659), 1000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DateCreated", "Price" },
                values: new object[] { new DateTime(2020, 3, 12, 0, 42, 24, 974, DateTimeKind.Local).AddTicks(5661), 1000m });
        }
    }
}
