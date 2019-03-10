using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcurrencyConflictInEFCore.Migrations
{
    public partial class AddRowVersionByFluentDesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Person",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldRowVersion: true,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Person",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
