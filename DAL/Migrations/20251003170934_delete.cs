using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers_CarrierId",
                table: "TbShipmentStatus");

            //migrationBuilder.DropIndex(
            //    name: "IX_TbShipmentStatus_CarrierId",
            //    table: "TbShipmentStatus");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "TbShipmentStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarrierId",
                table: "TbShipmentStatus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TbShipmentStatus_CarrierId",
                table: "TbShipmentStatus",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbShipmentStatus_TbCarriers_CarrierId",
                table: "TbShipmentStatus",
                column: "CarrierId",
                principalTable: "TbCarriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
