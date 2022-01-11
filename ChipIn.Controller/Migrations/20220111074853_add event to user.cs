using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChipIn.Controller.Migrations
{
    public partial class addeventtouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
