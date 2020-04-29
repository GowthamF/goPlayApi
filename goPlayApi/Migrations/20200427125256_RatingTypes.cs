using Microsoft.EntityFrameworkCore.Migrations;

namespace goPlayApi.Migrations
{
    public partial class RatingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Ratings",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Ratings",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
