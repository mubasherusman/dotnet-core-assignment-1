using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetAssignment.Migrations
{
    public partial class PANColumninDebitCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Pan",
                table: "DebitCards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pan",
                table: "DebitCards");
        }
    }
}
