using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeoplesCities.Sqlite.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    ts = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    city_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    ts = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_city_city_id",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_city_id",
                table: "user",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_id",
                table: "user",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
