using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class shipmentFeilds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShippmentStatus_TbCarriers",
                table: "TbShippmentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TbShippmentStatus_TbShippments",
                table: "TbShippmentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbShippmentStatus",
                table: "TbShippmentStatus");

            migrationBuilder.RenameTable(
                name: "TbShippmentStatus",
                newName: "TbShipmentStatus");

            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "TbShippments",
                newName: "ShipingDate");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TbShippmentStatus_ShippmentId",
            //    table: "TbShipmentStatus",
            //    newName: "IX_TbShipmentStatus_ShippmentId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TbShippmentStatus_CarrierId",
            //    table: "TbShipmentStatus",
            //    newName: "IX_TbShipmentStatus_CarrierId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DelivryDate",
                table: "TbShippments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ShipingPackgingId",
                table: "TbShippments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbShipmentStatus",
                table: "TbShipmentStatus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TbShipingPackging",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipingPackgingAname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipingPackgingEname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbShipingPackging", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbShippments_ShipingPackgingId",
                table: "TbShippments",
                column: "ShipingPackgingId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers",
                table: "TbShipmentStatus",
                column: "CarrierId",
                principalTable: "TbCarriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipmentStatus_TbShippments",
                table: "TbShipmentStatus",
                column: "ShippmentId",
                principalTable: "TbShippments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShippments_TbShipingPackging_ShipingPackgingId",
                table: "TbShippments",
                column: "ShipingPackgingId",
                principalTable: "TbShipingPackging",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers",
                table: "TbShipmentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TbShipmentStatus_TbShippments",
                table: "TbShipmentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_TbShippments_TbShipingPackging_ShipingPackgingId",
                table: "TbShippments");

            migrationBuilder.DropTable(
                name: "TbShipingPackging");

            migrationBuilder.DropIndex(
                name: "IX_TbShippments_ShipingPackgingId",
                table: "TbShippments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbShipmentStatus",
                table: "TbShipmentStatus");

            migrationBuilder.DropColumn(
                name: "DelivryDate",
                table: "TbShippments");

            migrationBuilder.DropColumn(
                name: "ShipingPackgingId",
                table: "TbShippments");

            migrationBuilder.RenameTable(
                name: "TbShipmentStatus",
                newName: "TbShippmentStatus");

            migrationBuilder.RenameColumn(
                name: "ShipingDate",
                table: "TbShippments",
                newName: "ShippingDate");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TbShipmentStatus_ShippmentId",
            //    table: "TbShippmentStatus",
            //    newName: "IX_TbShippmentStatus_ShippmentId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TbShipmentStatus_CarrierId",
            //    table: "TbShippmentStatus",
            //    newName: "IX_TbShippmentStatus_CarrierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbShippmentStatus",
                table: "TbShippmentStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShippmentStatus_TbCarriers",
                table: "TbShippmentStatus",
                column: "CarrierId",
                principalTable: "TbCarriers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShippmentStatus_TbShippments",
                table: "TbShippmentStatus",
                column: "ShippmentId",
                principalTable: "TbShippments",
                principalColumn: "Id");
        }
    }
}
