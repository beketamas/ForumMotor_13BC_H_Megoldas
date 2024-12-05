using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumMotor_13BC_H.Data.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_307 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisLike",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisLike",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Like",
                table: "Posts");
        }
    }
}
