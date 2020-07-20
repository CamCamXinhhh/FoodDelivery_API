using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDelivery.Migrations
{
    public partial class Extend_IdentityUser_AddUserImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "AspNetUsers");
        }
    }
}
