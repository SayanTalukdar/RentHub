using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class modeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavouriteModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false),
                    IsFavorite = table.Column<bool>(nullable: false),
                    ApartmentModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteModel_ApartmentModel_ApartmentModelId",
                        column: x => x.ApartmentModelId,
                        principalTable: "ApartmentModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteModel_ApartmentModelId",
                table: "FavouriteModel",
                column: "ApartmentModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteModel");
        }
    }
}
