using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BPAgency.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ServiceStartTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    ServiceEndTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    SelfServiceStartTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    SelfServiceEndTime = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(14,8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(14,8)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Phone2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Phone3 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    District = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false),
                    IsStation = table.Column<bool>(type: "bit", nullable: false),
                    IsCapital = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
