using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RChat.Migrations
{
    public partial class addMessageAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    UserEntityUserId = table.Column<int>(type: "integer", nullable: true),
                    ChatEntityChatId = table.Column<int>(type: "integer", nullable: true),
                    BotEntityBotId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Bots_BotEntityBotId",
                        column: x => x.BotEntityBotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatEntityChatId",
                        column: x => x.ChatEntityChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserEntityUserId",
                        column: x => x.UserEntityUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BotEntityBotId",
                table: "Messages",
                column: "BotEntityBotId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatEntityChatId",
                table: "Messages",
                column: "ChatEntityChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserEntityUserId",
                table: "Messages",
                column: "UserEntityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
