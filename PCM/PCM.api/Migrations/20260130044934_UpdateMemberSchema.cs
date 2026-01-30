using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMemberSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Members",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
