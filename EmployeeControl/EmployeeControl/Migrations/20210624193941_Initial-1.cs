using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeControl.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeDayStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusStartWork = table.Column<bool>(type: "bit", nullable: false),
                    statusEndWork = table.Column<bool>(type: "bit", nullable: false),
                    IduseraId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeDayStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employeeDayStatuses_AspNetUsers_IduseraId",
                        column: x => x.IduseraId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeeDayStatuses_IduseraId",
                table: "employeeDayStatuses",
                column: "IduseraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeDayStatuses");
        }
    }
}
