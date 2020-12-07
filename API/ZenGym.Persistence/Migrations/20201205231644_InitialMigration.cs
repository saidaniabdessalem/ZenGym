using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZenGym.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CachingUps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Collecting = table.Column<decimal>(nullable: false),
                    Disbursement = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachingUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Libelle = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Libelle = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Client = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    IsDeteted = table.Column<string>(nullable: true, defaultValue: "False"),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    FisrtName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    PhotoLink = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    CertificationDate = table.Column<DateTime>(nullable: false),
                    Size = table.Column<decimal>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true),
                    IMC = table.Column<decimal>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellItem_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ReceivedAmount = table.Column<decimal>(nullable: false),
                    RemainingAmount = table.Column<decimal>(nullable: false),
                    IsCanceled = table.Column<bool>(nullable: false, defaultValue: false),
                    SubscriptionTypeId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionTypes_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "SubscriptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pointings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 12, 6, 0, 16, 44, 630, DateTimeKind.Local).AddTicks(1199)),
                    ExitTime = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pointings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pointings_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pointings_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Pointings_MemberId",
                table: "Pointings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Pointings_SubscriptionId",
                table: "Pointings",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellItem_ProductId",
                table: "SellItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellItem_SaleId",
                table: "SellItem",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MemberId",
                table: "Subscriptions",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_SubscriptionTypeId",
                table: "Subscriptions",
                column: "SubscriptionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CachingUps");

            migrationBuilder.DropTable(
                name: "Pointings");

            migrationBuilder.DropTable(
                name: "SellItem");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "SubscriptionTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
