using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUserToOrganizations",
                columns: table => new
                {
                    AppUserToOrganizationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserToOrganizations", x => x.AppUserToOrganizationId);
                    table.ForeignKey(
                        name: "FK_AppUserToOrganizations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserToOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemModules",
                columns: table => new
                {
                    SystemModuleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SystemModuleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemModules", x => x.SystemModuleId);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    SystemRoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SystemRoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.SystemRoleId);
                });

            migrationBuilder.CreateTable(
                name: "AssignedPermissions",
                columns: table => new
                {
                    AssignedPermissionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppUserToOrganizationId = table.Column<int>(nullable: false),
                    SystemModuleId = table.Column<int>(nullable: false),
                    SystemRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedPermissions", x => x.AssignedPermissionId);
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_AppUserToOrganizations_AppUserToOrganiza~",
                        column: x => x.AppUserToOrganizationId,
                        principalTable: "AppUserToOrganizations",
                        principalColumn: "AppUserToOrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_SystemModules_SystemModuleId",
                        column: x => x.SystemModuleId,
                        principalTable: "SystemModules",
                        principalColumn: "SystemModuleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedPermissions_SystemRoles_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "SystemRoles",
                        principalColumn: "SystemRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserToOrganizations_AppUserId",
                table: "AppUserToOrganizations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserToOrganizations_OrganizationId",
                table: "AppUserToOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPermissions_AppUserToOrganizationId",
                table: "AssignedPermissions",
                column: "AppUserToOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPermissions_SystemModuleId",
                table: "AssignedPermissions",
                column: "SystemModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedPermissions_SystemRoleId",
                table: "AssignedPermissions",
                column: "SystemRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedPermissions");

            migrationBuilder.DropTable(
                name: "AppUserToOrganizations");

            migrationBuilder.DropTable(
                name: "SystemModules");

            migrationBuilder.DropTable(
                name: "SystemRoles");
        }
    }
}
