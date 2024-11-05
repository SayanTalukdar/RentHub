using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class favouritemodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "FavouriteModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "FavouriteModel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
