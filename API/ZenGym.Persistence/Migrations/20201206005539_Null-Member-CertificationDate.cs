using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenGym.Persistence.Migrations
{
    public partial class NullMemberCertificationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Pointings",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 6, 1, 55, 39, 518, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 6, 1, 3, 59, 207, DateTimeKind.Local).AddTicks(2039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Members",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Pointings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 6, 1, 3, 59, 207, DateTimeKind.Local).AddTicks(2039),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 6, 1, 55, 39, 518, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
