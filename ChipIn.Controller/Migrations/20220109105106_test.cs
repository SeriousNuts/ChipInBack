using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChipIn.Controller.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user__event_event_id",
                table: "user_");

            migrationBuilder.DropIndex(
                name: "ix_user__event_id",
                table: "user_");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "user_");

            migrationBuilder.DropColumn(
                name: "event_id",
                table: "user_");

            migrationBuilder.DropColumn(
                name: "member_credit",
                table: "user_");

            migrationBuilder.DropColumn(
                name: "member_id",
                table: "user_");

            migrationBuilder.CreateTable(
                name: "member",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    member_credit = table.Column<double>(type: "double precision", nullable: true),
                    event_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    user_id1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_member", x => x.id);
                    table.ForeignKey(
                        name: "fk_member_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_member_user__user_id",
                        column: x => x.user_id1,
                        principalTable: "user_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_member_event_id",
                table: "member",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_member_user_id",
                table: "member",
                column: "user_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "member");

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "user_",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "event_id",
                table: "user_",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "member_credit",
                table: "user_",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "member_id",
                table: "user_",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_user__event_id",
                table: "user_",
                column: "event_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user__event_event_id",
                table: "user_",
                column: "event_id",
                principalTable: "event",
                principalColumn: "id");
        }
    }
}
