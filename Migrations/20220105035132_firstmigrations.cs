using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineChatApp.Migrations
{
    public partial class firstmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UserRole = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    FriendRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FriendRequestFromId = table.Column<int>(type: "integer", nullable: false),
                    FriendRequestToId = table.Column<int>(type: "integer", nullable: false),
                    FriendRequestStatus = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.FriendRequestId);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_FriendRequestFromId",
                        column: x => x.FriendRequestFromId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequests_Users_FriendRequestToId",
                        column: x => x.FriendRequestToId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FriendRequestFromId",
                table: "FriendRequests",
                column: "FriendRequestFromId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_FriendRequestToId",
                table: "FriendRequests",
                column: "FriendRequestToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
