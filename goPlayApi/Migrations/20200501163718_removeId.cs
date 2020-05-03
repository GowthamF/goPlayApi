using Microsoft.EntityFrameworkCore.Migrations;

namespace goPlayApi.Migrations
{
    public partial class removeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Venues_VenueId",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_VenueId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Promotions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Promotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_VenueId",
                table: "Promotions",
                column: "VenueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Venues_VenueId",
                table: "Promotions",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
