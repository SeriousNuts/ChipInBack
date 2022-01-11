using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChipIn.Controller.Migrations
{
    public partial class addusercollectionreferencetoEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_event_user__user_id",
                table: "event");

            migrationBuilder.DropIndex(
                name: "ix_event_user_id",
                table: "event");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "event");

            migrationBuilder.CreateTable(
                name: "event_user_",
                columns: table => new
                {
                    eventsid = table.Column<int>(type: "integer", nullable: false),
                    users_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_user_", x => new { x.eventsid, x.users_id });
                    table.ForeignKey(
                        name: "fk_event_user__event_eventsid",
                        column: x => x.eventsid,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_event_user__user__users_id",
                        column: x => x.users_id,
                        principalTable: "user_",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_event_user__users_id",
                table: "event_user_",
                column: "users_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_user_");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "event",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_event_user_id",
                table: "event",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_event_user__user_id",
                table: "event",
                column: "user_id",
                principalTable: "user_",
                principalColumn: "id");
        }
    }
}
