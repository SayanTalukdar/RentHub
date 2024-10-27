using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class modelupdatedapartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApartmentModelId",
                table: "CommentsModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "ApartmentModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentsModel_ApartmentModelId",
                table: "CommentsModel",
                column: "ApartmentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentsModel_ApartmentModel_ApartmentModelId",
                table: "CommentsModel",
                column: "ApartmentModelId",
                principalTable: "ApartmentModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentsModel_ApartmentModel_ApartmentModelId",
                table: "CommentsModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentsModel_ApartmentModelId",
                table: "CommentsModel");

            migrationBuilder.DropColumn(
                name: "ApartmentModelId",
                table: "CommentsModel");

            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "ApartmentModel");
        }
    }
}
