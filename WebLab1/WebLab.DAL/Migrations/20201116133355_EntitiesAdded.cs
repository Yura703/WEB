using Microsoft.EntityFrameworkCore.Migrations;

namespace WebLab.DAL.Migrations
{
    public partial class EntitiesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaneGroups",
                columns: table => new
                {
                    PlaneGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneGroups", x => x.PlaneGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Speed = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    PlaneGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.PlaneId);
                    table.ForeignKey(
                        name: "FK_Planes_PlaneGroups_PlaneGroupId",
                        column: x => x.PlaneGroupId,
                        principalTable: "PlaneGroups",
                        principalColumn: "PlaneGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planes_PlaneGroupId",
                table: "Planes",
                column: "PlaneGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "PlaneGroups");
        }
    }
}
