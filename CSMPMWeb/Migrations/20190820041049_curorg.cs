using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class curorg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserSelectedAsCurrent",
                table: "AppUserToOrganizations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserSelectedAsCurrent",
                table: "AppUserToOrganizations");
        }
    }
}
