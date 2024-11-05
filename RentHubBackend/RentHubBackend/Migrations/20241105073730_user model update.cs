using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class usermodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteModel_ApartmentModel_ApartmentModelId",
                table: "FavouriteModel");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteModel_ApartmentModelId",
                table: "FavouriteModel");

            migrationBuilder.DropColumn(
                name: "ApartmentModelId",
                table: "FavouriteModel");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "FavouriteModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteModel_UserModelId",
                table: "FavouriteModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteModel_UserModel_UserModelId",
                table: "FavouriteModel",
                column: "UserModelId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteModel_UserModel_UserModelId",
                table: "FavouriteModel");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteModel_UserModelId",
                table: "FavouriteModel");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "FavouriteModel");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentModelId",
                table: "FavouriteModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteModel_ApartmentModelId",
                table: "FavouriteModel",
                column: "ApartmentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteModel_ApartmentModel_ApartmentModelId",
                table: "FavouriteModel",
                column: "ApartmentModelId",
                principalTable: "ApartmentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
