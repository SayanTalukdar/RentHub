using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentHubBackend.Migrations
{
    public partial class newmodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ApartName = table.Column<string>(nullable: true),
                    IsShared = table.Column<bool>(nullable: false),
                    ApartLocation = table.Column<string>(nullable: true),
                    ApartDetails = table.Column<string>(nullable: true),
                    StayType = table.Column<string>(nullable: true),
                    ExpectedRent = table.Column<string>(nullable: true),
                    IsNegotiable = table.Column<bool>(nullable: false),
                    IsFurnished = table.Column<bool>(nullable: false),
                    DescpTitle = table.Column<string>(nullable: true),
                    Descp = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    IsFavourited = table.Column<int>(nullable: false),
                    ApartmentImagePath = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentsModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CommentMade = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentModel");

            migrationBuilder.DropTable(
                name: "CommentsModel");
        }
    }
}
