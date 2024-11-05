using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class interestmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FavouriteModel",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "FavouriteModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "FavouriteModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FavouriteModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
