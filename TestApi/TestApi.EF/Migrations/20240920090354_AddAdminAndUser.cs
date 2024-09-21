﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApi.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        values: new object[,]
        {
            { Guid.NewGuid().ToString(), "Admin", "ADMIN", Guid.NewGuid().ToString() },
            { Guid.NewGuid().ToString(), "User", "USER", Guid.NewGuid().ToString() }
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
        table: "AspNetRoles",
        keyColumn: "Name",
        keyValues: new object[] { "Admin", "User" });
        }
    }
}
