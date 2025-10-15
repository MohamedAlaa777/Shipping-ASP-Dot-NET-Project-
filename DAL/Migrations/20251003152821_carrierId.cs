using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class carrierId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers",
                table: "TbShipmentStatus");

            migrationBuilder.AddColumn<Guid>(
                name: "CarrierId",
                table: "TbShippments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbShippments_CarrierId",
                table: "TbShippments",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers_CarrierId",
                table: "TbShipmentStatus",
                column: "CarrierId",
                principalTable: "TbCarriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers",
                table: "TbShippments",
                column: "CarrierId",
                principalTable: "TbCarriers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers_CarrierId",
                table: "TbShipmentStatus");

            migrationBuilder.DropIndex(
                name: "IX_TbShippments_CarrierId",
                table: "TbShippments");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "TbShippments");
        }
    }
}
