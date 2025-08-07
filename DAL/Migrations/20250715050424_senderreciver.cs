using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class senderreciver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "TbUserSebders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TbUserSebders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OtherAddress",
                table: "TbUserSebders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "TbUserSebders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "TbUserReceivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherAddress",
                table: "TbUserReceivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "TbUserReceivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "TbUserSebders");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TbUserSebders");

            migrationBuilder.DropColumn(
                name: "OtherAddress",
                table: "TbUserSebders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "TbUserSebders");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "TbUserReceivers");

            migrationBuilder.DropColumn(
                name: "OtherAddress",
                table: "TbUserReceivers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "TbUserReceivers");
        }
    }
}
