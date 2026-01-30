using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCM.Migrations
{
    /// <inheritdoc />
    public partial class CreateMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourtId = table.Column<int>(type: "int", nullable: false),
                    MatchType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    Player3Id = table.Column<int>(type: "int", nullable: true),
                    Player4Id = table.Column<int>(type: "int", nullable: true),
                    WinnerId = table.Column<int>(type: "int", nullable: true),
                    WinnerTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player1Score = table.Column<int>(type: "int", nullable: true),
                    Player2Score = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRanked = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Courts_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Courts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Members_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Members_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Members_Player3Id",
                        column: x => x.Player3Id,
                        principalTable: "Members",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Members_Player4Id",
                        column: x => x.Player4Id,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CourtId",
                table: "Matches",
                column: "CourtId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player3Id",
                table: "Matches",
                column: "Player3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player4Id",
                table: "Matches",
                column: "Player4Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
