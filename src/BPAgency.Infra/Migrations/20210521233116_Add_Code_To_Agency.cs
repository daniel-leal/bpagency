using Microsoft.EntityFrameworkCore.Migrations;

namespace BPAgency.Infra.Migrations
{
    public partial class Add_Code_To_Agency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Agencies",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Agencies");
        }
    }
}
