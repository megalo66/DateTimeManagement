using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DateTimeManagement.Migrations
{
    public partial class InitBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonEntittyWithIANADateTimes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BilingDate_OriginalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BilingDate_TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BilingDate_OffsetUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DueDate_OriginalDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate_TimeZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate_OffsetUTC = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonEntittyWithIANADateTimes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonEntittyWithIANADateTimes");
        }
    }
}
