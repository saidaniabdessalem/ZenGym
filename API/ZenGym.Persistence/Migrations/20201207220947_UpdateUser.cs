using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenGym.Persistence.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Pointings",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 7, 23, 9, 47, 513, DateTimeKind.Local).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 7, 17, 22, 40, 582, DateTimeKind.Local).AddTicks(2636));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Pointings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 7, 17, 22, 40, 582, DateTimeKind.Local).AddTicks(2636),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 7, 23, 9, 47, 513, DateTimeKind.Local).AddTicks(2050));
        }
    }
}
