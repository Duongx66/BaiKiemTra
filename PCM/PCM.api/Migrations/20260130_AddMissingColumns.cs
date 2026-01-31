using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCM.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DuprRating",
                table: "Members",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Members",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 1, 30, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<int>(
                name: "MatchesLost",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchesPlayed",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchesWon",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Members_IdentityUserId",
                table: "Members",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_IdentityUserId",
                table: "Members",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_IdentityUserId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_IdentityUserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "DuprRating",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MatchesLost",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MatchesPlayed",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MatchesWon",
                table: "Members");
        }
    }
}
