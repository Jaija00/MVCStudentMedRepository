﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCStudentMedRepository.Migrations
{
    /// <inheritdoc />
    public partial class addedcityproptoStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");
        }
    }
}
