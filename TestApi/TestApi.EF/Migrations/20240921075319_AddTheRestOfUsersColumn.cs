using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddTheRestOfUsersColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ExpiresOn",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "users",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "FristName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FristName",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "Roles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresOn",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
