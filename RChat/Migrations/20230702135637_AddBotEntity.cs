using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RChat.Migrations
{
    public partial class AddBotEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BotEntityBotId",
                table: "Messages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bots",
                columns: table => new
                {
                    BotId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bots", x => x.BotId);
                });

            migrationBuilder.CreateTable(
                name: "BotEntityChatEntity",
                columns: table => new
                {
                    BotEntitiesBotId = table.Column<int>(type: "integer", nullable: false),
                    ChatEntitiesChatId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotEntityChatEntity", x => new { x.BotEntitiesBotId, x.ChatEntitiesChatId });
                    table.ForeignKey(
                        name: "FK_BotEntityChatEntity_Bots_BotEntitiesBotId",
                        column: x => x.BotEntitiesBotId,
                        principalTable: "Bots",
                        principalColumn: "BotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BotEntityChatEntity_Chats_ChatEntitiesChatId",
                        column: x => x.ChatEntitiesChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_BotEntityBotId",
                table: "Messages",
                column: "BotEntityBotId");

            migrationBuilder.CreateIndex(
                name: "IX_BotEntityChatEntity_ChatEntitiesChatId",
                table: "BotEntityChatEntity",
                column: "ChatEntitiesChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Bots_BotEntityBotId",
                table: "Messages",
                column: "BotEntityBotId",
                principalTable: "Bots",
                principalColumn: "BotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Bots_BotEntityBotId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "BotEntityChatEntity");

            migrationBuilder.DropTable(
                name: "Bots");

            migrationBuilder.DropIndex(
                name: "IX_Messages_BotEntityBotId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "BotEntityBotId",
                table: "Messages");
        }
    }
}
