using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class IrrigationGridsAndIrrigationCanals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IrrigationGrids",
                columns: table => new
                {
                    IrrigationGridId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationGridName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationGrids", x => x.IrrigationGridId);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationCanals",
                columns: table => new
                {
                    IrrigationCanalId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationCanalName = table.Column<string>(nullable: true),
                    IrrigationGridId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationCanals", x => x.IrrigationCanalId);
                    table.ForeignKey(
                        name: "FK_IrrigationCanals_IrrigationGrids_IrrigationGridId",
                        column: x => x.IrrigationGridId,
                        principalTable: "IrrigationGrids",
                        principalColumn: "IrrigationGridId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationCanals_IrrigationGridId",
                table: "IrrigationCanals",
                column: "IrrigationGridId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrrigationCanals");

            migrationBuilder.DropTable(
                name: "IrrigationGrids");
        }
    }
}
