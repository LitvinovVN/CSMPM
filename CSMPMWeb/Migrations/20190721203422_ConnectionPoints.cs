using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class ConnectionPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IrrigationCanalConnectionPoints",
                columns: table => new
                {
                    IrrigationCanalConnectionPointId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationCanalConnectionPointName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationCanalConnectionPoints", x => x.IrrigationCanalConnectionPointId);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationCanalConnectionPointTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationCanalConnectionPointTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationCanalConnectionPointToIrrigationCanals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationCanalConnectionPointId = table.Column<int>(nullable: false),
                    IrrigationCanalId = table.Column<int>(nullable: false),
                    IrrigationCanalConnectionPointTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationCanalConnectionPointToIrrigationCanals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IrrigationCanalConnectionPointToIrrigationCanals_IrrigationC~",
                        column: x => x.IrrigationCanalConnectionPointId,
                        principalTable: "IrrigationCanalConnectionPoints",
                        principalColumn: "IrrigationCanalConnectionPointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationCanalConnectionPointToIrrigationCanals_Irrigation~1",
                        column: x => x.IrrigationCanalConnectionPointTypeId,
                        principalTable: "IrrigationCanalConnectionPointTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationCanalConnectionPointToIrrigationCanals_Irrigation~2",
                        column: x => x.IrrigationCanalId,
                        principalTable: "IrrigationCanals",
                        principalColumn: "IrrigationCanalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationCanalConnectionPointToIrrigationCanals_IrrigationC~",
                table: "IrrigationCanalConnectionPointToIrrigationCanals",
                column: "IrrigationCanalConnectionPointId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationCanalConnectionPointToIrrigationCanals_Irrigation~1",
                table: "IrrigationCanalConnectionPointToIrrigationCanals",
                column: "IrrigationCanalConnectionPointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationCanalConnectionPointToIrrigationCanals_Irrigation~2",
                table: "IrrigationCanalConnectionPointToIrrigationCanals",
                column: "IrrigationCanalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPointToIrrigationCanals");

            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPoints");

            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPointTypes");
        }
    }
}
