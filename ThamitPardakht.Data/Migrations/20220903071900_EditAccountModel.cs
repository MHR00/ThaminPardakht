using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThamitPardakht.Data.Migrations
{
    public partial class EditAccountModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Accounts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Accounts");
        }
    }
}
