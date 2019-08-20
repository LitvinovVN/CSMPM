using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMPMWeb.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropGroups",
                columns: table => new
                {
                    CropGroupId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CropGroupName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropGroups", x => x.CropGroupId);
                });

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
                name: "IrrigationSystems",
                columns: table => new
                {
                    IrrigationSystemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationSystemName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationSystems", x => x.IrrigationSystemId);
                });

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
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationToSystemRelationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationToSystemRelationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reasons",
                columns: table => new
                {
                    ReasonId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReasonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reasons", x => x.ReasonId);
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
                name: "TypeOfActivities",
                columns: table => new
                {
                    TypeOfActivityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TypeOfActivityName = table.Column<string>(nullable: true),
                    RootTypeOfActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfActivities", x => x.TypeOfActivityId);
                    table.ForeignKey(
                        name: "FK_TypeOfActivities_TypeOfActivities_RootTypeOfActivityId",
                        column: x => x.RootTypeOfActivityId,
                        principalTable: "TypeOfActivities",
                        principalColumn: "TypeOfActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CropName = table.Column<string>(nullable: true),
                    WateringRate = table.Column<double>(nullable: false),
                    IrrigationRate = table.Column<double>(nullable: false),
                    CropGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropId);
                    table.ForeignKey(
                        name: "FK_Crops_CropGroups_CropGroupId",
                        column: x => x.CropGroupId,
                        principalTable: "CropGroups",
                        principalColumn: "CropGroupId",
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
                name: "OrganizationDocumentation",
                columns: table => new
                {
                    OrganizationDocumentationItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationDocumentationItemName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDocumentation", x => x.OrganizationDocumentationItemId);
                    table.ForeignKey(
                        name: "FK_OrganizationDocumentation_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationToIrrigationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    IrrigationSystemId = table.Column<int>(nullable: false),
                    OrganizationToSystemRelationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationToIrrigationSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationToIrrigationSystems_IrrigationSystems_Irrigation~",
                        column: x => x.IrrigationSystemId,
                        principalTable: "IrrigationSystems",
                        principalColumn: "IrrigationSystemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationToIrrigationSystems_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationToIrrigationSystems_OrganizationToSystemRelation~",
                        column: x => x.OrganizationToSystemRelationTypeId,
                        principalTable: "OrganizationToSystemRelationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationToTypeOfActivities",
                columns: table => new
                {
                    OrganizationToTypeOfActivityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    TypeOfActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationToTypeOfActivities", x => x.OrganizationToTypeOfActivityId);
                    table.ForeignKey(
                        name: "FK_OrganizationToTypeOfActivities_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationToTypeOfActivities_TypeOfActivities_TypeOfActivi~",
                        column: x => x.TypeOfActivityId,
                        principalTable: "TypeOfActivities",
                        principalColumn: "TypeOfActivityId",
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

            migrationBuilder.CreateTable(
                name: "OrganizationDocumentationPlans",
                columns: table => new
                {
                    OrganizationDocumentationPlansId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationDocumentationPlansName = table.Column<string>(nullable: true),
                    OrganizationDocumentationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationDocumentationPlans", x => x.OrganizationDocumentationPlansId);
                    table.ForeignKey(
                        name: "FK_OrganizationDocumentationPlans_OrganizationDocumentation_Org~",
                        column: x => x.OrganizationDocumentationId,
                        principalTable: "OrganizationDocumentation",
                        principalColumn: "OrganizationDocumentationItemId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "IrrigationPlans",
                columns: table => new
                {
                    IrrigationPlanId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    OrganizationDocumentationPlansId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationPlans", x => x.IrrigationPlanId);
                    table.ForeignKey(
                        name: "FK_IrrigationPlans_OrganizationDocumentationPlans_OrganizationD~",
                        column: x => x.OrganizationDocumentationPlansId,
                        principalTable: "OrganizationDocumentationPlans",
                        principalColumn: "OrganizationDocumentationPlansId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationPlanItems",
                columns: table => new
                {
                    IrrigationPlanItemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationPlanId = table.Column<int>(nullable: false),
                    IrrigationSystemId = table.Column<int>(nullable: false),
                    LandAreaOnBeginningOfYear = table.Column<double>(nullable: false),
                    LandAreaAgriculturalUse = table.Column<double>(nullable: false),
                    LandAreaIncludedInIrrigationPlan = table.Column<double>(nullable: false),
                    LandAreaSowing = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationPlanItems", x => x.IrrigationPlanItemId);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItems_IrrigationPlans_IrrigationPlanId",
                        column: x => x.IrrigationPlanId,
                        principalTable: "IrrigationPlans",
                        principalColumn: "IrrigationPlanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItems_IrrigationSystems_IrrigationSystemId",
                        column: x => x.IrrigationSystemId,
                        principalTable: "IrrigationSystems",
                        principalColumn: "IrrigationSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationPlanItem_CropSowingAndIrrigations",
                columns: table => new
                {
                    IrrigationPlanItem_CropSowingAndIrrigationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationPlanItemId = table.Column<int>(nullable: false),
                    CropId = table.Column<int>(nullable: false),
                    Sowing = table.Column<double>(nullable: false),
                    Irrigation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationPlanItem_CropSowingAndIrrigations", x => x.IrrigationPlanItem_CropSowingAndIrrigationId);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_CropSowingAndIrrigations_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "CropId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_CropSowingAndIrrigations_IrrigationPlanIt~",
                        column: x => x.IrrigationPlanItemId,
                        principalTable: "IrrigationPlanItems",
                        principalColumn: "IrrigationPlanItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationPlanItem_LandAreaNotAgriculturalReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationPlanItemId = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    ReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationPlanItem_LandAreaNotAgriculturalReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_LandAreaNotAgriculturalReasons_Irrigation~",
                        column: x => x.IrrigationPlanItemId,
                        principalTable: "IrrigationPlanItems",
                        principalColumn: "IrrigationPlanItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_LandAreaNotAgriculturalReasons_Reasons_Re~",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationPlanItem_LandAreaNotIrrigationReasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IrrigationPlanItemId = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    ReasonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationPlanItem_LandAreaNotIrrigationReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_LandAreaNotIrrigationReasons_IrrigationPl~",
                        column: x => x.IrrigationPlanItemId,
                        principalTable: "IrrigationPlanItems",
                        principalColumn: "IrrigationPlanItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IrrigationPlanItem_LandAreaNotIrrigationReasons_Reasons_Reas~",
                        column: x => x.ReasonId,
                        principalTable: "Reasons",
                        principalColumn: "ReasonId",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CropGroupId",
                table: "Crops",
                column: "CropGroupId");

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

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationCanals_IrrigationGridId",
                table: "IrrigationCanals",
                column: "IrrigationGridId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationGrids_IrrigationSystemId",
                table: "IrrigationGrids",
                column: "IrrigationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_CropSowingAndIrrigations_CropId",
                table: "IrrigationPlanItem_CropSowingAndIrrigations",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_CropSowingAndIrrigations_IrrigationPlanIt~",
                table: "IrrigationPlanItem_CropSowingAndIrrigations",
                column: "IrrigationPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_LandAreaNotAgriculturalReasons_Irrigation~",
                table: "IrrigationPlanItem_LandAreaNotAgriculturalReasons",
                column: "IrrigationPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_LandAreaNotAgriculturalReasons_ReasonId",
                table: "IrrigationPlanItem_LandAreaNotAgriculturalReasons",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_LandAreaNotIrrigationReasons_IrrigationPl~",
                table: "IrrigationPlanItem_LandAreaNotIrrigationReasons",
                column: "IrrigationPlanItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItem_LandAreaNotIrrigationReasons_ReasonId",
                table: "IrrigationPlanItem_LandAreaNotIrrigationReasons",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItems_IrrigationPlanId",
                table: "IrrigationPlanItems",
                column: "IrrigationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlanItems_IrrigationSystemId",
                table: "IrrigationPlanItems",
                column: "IrrigationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IrrigationPlans_OrganizationDocumentationPlansId",
                table: "IrrigationPlans",
                column: "OrganizationDocumentationPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDocumentation_OrganizationId",
                table: "OrganizationDocumentation",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationDocumentationPlans_OrganizationDocumentationId",
                table: "OrganizationDocumentationPlans",
                column: "OrganizationDocumentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentOrganizationId",
                table: "Organizations",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationToIrrigationSystems_IrrigationSystemId",
                table: "OrganizationToIrrigationSystems",
                column: "IrrigationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationToIrrigationSystems_OrganizationId",
                table: "OrganizationToIrrigationSystems",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationToIrrigationSystems_OrganizationToSystemRelation~",
                table: "OrganizationToIrrigationSystems",
                column: "OrganizationToSystemRelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationToTypeOfActivities_OrganizationId",
                table: "OrganizationToTypeOfActivities",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationToTypeOfActivities_TypeOfActivityId",
                table: "OrganizationToTypeOfActivities",
                column: "TypeOfActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfActivities_RootTypeOfActivityId",
                table: "TypeOfActivities",
                column: "RootTypeOfActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignedPermissions");

            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPointToIrrigationCanals");

            migrationBuilder.DropTable(
                name: "IrrigationPlanItem_CropSowingAndIrrigations");

            migrationBuilder.DropTable(
                name: "IrrigationPlanItem_LandAreaNotAgriculturalReasons");

            migrationBuilder.DropTable(
                name: "IrrigationPlanItem_LandAreaNotIrrigationReasons");

            migrationBuilder.DropTable(
                name: "OrganizationToIrrigationSystems");

            migrationBuilder.DropTable(
                name: "OrganizationToTypeOfActivities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AppUserToOrganizations");

            migrationBuilder.DropTable(
                name: "SystemModules");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPoints");

            migrationBuilder.DropTable(
                name: "IrrigationCanalConnectionPointTypes");

            migrationBuilder.DropTable(
                name: "IrrigationCanals");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "IrrigationPlanItems");

            migrationBuilder.DropTable(
                name: "Reasons");

            migrationBuilder.DropTable(
                name: "OrganizationToSystemRelationTypes");

            migrationBuilder.DropTable(
                name: "TypeOfActivities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IrrigationGrids");

            migrationBuilder.DropTable(
                name: "CropGroups");

            migrationBuilder.DropTable(
                name: "IrrigationPlans");

            migrationBuilder.DropTable(
                name: "IrrigationSystems");

            migrationBuilder.DropTable(
                name: "OrganizationDocumentationPlans");

            migrationBuilder.DropTable(
                name: "OrganizationDocumentation");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
