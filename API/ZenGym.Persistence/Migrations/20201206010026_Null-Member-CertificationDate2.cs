using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenGym.Persistence.Migrations
{
    public partial class NullMemberCertificationDate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Pointings",
                nullable: false,
                defaultValue: new DateTime(2020, 12, 6, 2, 0, 26, 570, DateTimeKind.Local).AddTicks(9293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 12, 6, 1, 55, 39, 518, DateTimeKind.Local).AddTicks(5641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CertificationDate",
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
                defaultValue: new DateTime(2020, 12, 6, 1, 55, 39, 518, DateTimeKind.Local).AddTicks(5641),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 12, 6, 2, 0, 26, 570, DateTimeKind.Local).AddTicks(9293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CertificationDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
