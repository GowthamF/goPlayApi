using Microsoft.EntityFrameworkCore.Migrations;

namespace goPlayApi.Migrations
{
    public partial class removechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Users_UserId",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_UserId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Venues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_UserId",
                table: "Venues",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Users_UserId",
                table: "Venues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
