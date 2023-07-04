using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentProfile.Data.Migrations
{
    public partial class add_is_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "AspNetUsers");
        }
    }
}
