﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcurrencyConflictInEFCore.Migrations
{
    public partial class AddTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Person",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Person");
        }
    }
}
