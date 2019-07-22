using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class IrrigationSystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationName = table.Column<string>(nullable: true),
                    ParentOrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationSystems",
                columns: table => new
                {
                    IrrigationSystemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationSystemName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationSystems", x => x.IrrigationSystemId);
                    table.ForeignKey(
                        name: "FK_IrrigationSystems_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationGrids",
                columns: table => new
                {
                    IrrigationGridId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationGridName = table.Column<string>(nullable: true),
                    IrrigationSystemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationGrids", x => x.IrrigationGridId);
                    table.ForeignKey(
                        name: "FK_IrrigationGrids_IrrigationSystems_IrrigationSystemId",
                        column: x => x.IrrigationSystemId,
                        principalTable: "IrrigationSystems",
                        principalColumn: "IrrigationSystemId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationGrids_IrrigationSystemId",
                table: "IrrigationGrids",
                column: "IrrigationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationSystems_OrganizationId",
                table: "IrrigationSystems",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrrigationCanals");

            migrationBuilder.DropTable(
                name: "IrrigationGrids");

            migrationBuilder.DropTable(
                name: "IrrigationSystems");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
