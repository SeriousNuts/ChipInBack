using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChipIn.Controller.Migrations
{
    public partial class deleteclassesparametresfrommember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_member_user__user_id",
                table: "member");

            migrationBuilder.DropIndex(
                name: "ix_member_user_id",
                table: "member");

            migrationBuilder.AddColumn<int>(
                name: "user_id1",
                table: "member",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_member_user_id",
                table: "member",
                column: "user_id1");

            migrationBuilder.AddForeignKey(
                name: "fk_member_user__user_id",
                table: "member",
                column: "user_id1",
                principalTable: "user_",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_member_user__user_id",
                table: "member");

            migrationBuilder.DropIndex(
                name: "ix_member_user_id",
                table: "member");

            migrationBuilder.DropColumn(
                name: "user_id1",
                table: "member");

            migrationBuilder.CreateIndex(
                name: "ix_member_user_id",
                table: "member",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_member_user__user_id",
                table: "member",
                column: "user_id",
                principalTable: "user_",
                principalColumn: "id");
        }
    }
}
