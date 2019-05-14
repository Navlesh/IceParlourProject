using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IceParlourApp.Migrations
{
    public partial class IceParlourAppModelsBillingContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressMaster",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompleteAddress = table.Column<string>(type: "varchar(500)", nullable: true),
                    ZipCode = table.Column<int>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMaster", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "PriceMaster",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<double>(nullable: false),
                    Currency = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMaster", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "OrderMaster",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    NumberOfScoop = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMaster", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_OrderMaster_AddressMaster_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressMaster",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IceCreamMaster",
                columns: table => new
                {
                    IceCreamId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsToppings = table.Column<bool>(nullable: false),
                    PriceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreamMaster", x => x.IceCreamId);
                    table.ForeignKey(
                        name: "FK_IceCreamMaster_PriceMaster_PriceId",
                        column: x => x.PriceId,
                        principalTable: "PriceMaster",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<int>(nullable: false),
                    IceCreamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_IceCreamMaster_IceCreamId",
                        column: x => x.IceCreamId,
                        principalTable: "IceCreamMaster",
                        principalColumn: "IceCreamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderMaster_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "OrderMaster",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PriceMaster",
                columns: new[] { "PriceId", "Currency", "Price" },
                values: new object[,]
                {
                    { 1, "INR", 16.0 },
                    { 2, "INR", 17.0 },
                    { 3, "INR", 18.0 },
                    { 4, "INR", 19.0 },
                    { 5, "INR", 20.0 },
                    { 6, "INR", 0.0 },
                    { 7, "INR", 0.0 },
                    { 8, "INR", 0.0 },
                    { 9, "INR", 0.0 }
                });

            migrationBuilder.InsertData(
                table: "IceCreamMaster",
                columns: new[] { "IceCreamId", "IsToppings", "Name", "PriceId" },
                values: new object[,]
                {
                    { 1, false, "Vanilla", 1 },
                    { 2, false, "Chocolate", 2 },
                    { 3, false, "Strawberry", 3 },
                    { 4, false, "Cookie and Cream", 4 },
                    { 5, false, "Hazel Nut ", 5 },
                    { 6, true, "Cookies", 6 },
                    { 7, true, "Fruits", 7 },
                    { 8, true, "Chocochips", 8 },
                    { 9, true, "Nuts", 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IceCreamMaster_PriceId",
                table: "IceCreamMaster",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_IceCreamId",
                table: "OrderDetail",
                column: "IceCreamId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderNumber",
                table: "OrderDetail",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMaster_AddressId",
                table: "OrderMaster",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "IceCreamMaster");

            migrationBuilder.DropTable(
                name: "OrderMaster");

            migrationBuilder.DropTable(
                name: "PriceMaster");

            migrationBuilder.DropTable(
                name: "AddressMaster");
        }
    }
}
