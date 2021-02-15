using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioApi.Repository.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Portfolio");

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 416, DateTimeKind.Utc).AddTicks(5627)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 416, DateTimeKind.Utc).AddTicks(5311)),
                    OwnerUserId = table.Column<string>(nullable: true),
                    ProfileId = table.Column<int>(nullable: false),
                    Info_Email = table.Column<string>(nullable: true),
                    Info_StreetAddress = table.Column<string>(nullable: true),
                    Info_City = table.Column<string>(nullable: true),
                    Info_State = table.Column<string>(nullable: true),
                    Info_Postal = table.Column<string>(nullable: true),
                    Info_Country = table.Column<string>(nullable: true),
                    Info_PhoneNumber = table.Column<string>(nullable: true),
                    Info_AddressType = table.Column<int>(nullable: true),
                    Info_PhoneType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(7379)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(6826)),
                    OwnerUserId = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Info_Title = table.Column<string>(nullable: true),
                    Info_BackgroundUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 414, DateTimeKind.Utc).AddTicks(5963)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 413, DateTimeKind.Utc).AddTicks(4702)),
                    OwnerUserId = table.Column<string>(nullable: true),
                    Info_FirstName = table.Column<string>(nullable: true),
                    Info_LastName = table.Column<string>(nullable: true),
                    Info_BirthDate = table.Column<DateTime>(nullable: true),
                    Info_ImageUrl = table.Column<string>(nullable: true),
                    Info_AboutMe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceSection",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExperienceInfoExperienceId = table.Column<int>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    Info_Meta = table.Column<string>(nullable: true),
                    Info_Body = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceSection", x => new { x.ExperienceInfoExperienceId, x.Id });
                    table.ForeignKey(
                        name: "FK_ExperienceSection_Experiences_ExperienceInfoExperienceId",
                        column: x => x.ExperienceInfoExperienceId,
                        principalSchema: "Portfolio",
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerUserId",
                schema: "Portfolio",
                table: "Contacts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Info_Email",
                schema: "Portfolio",
                table: "Contacts",
                column: "Info_Email");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_OwnerUserId",
                schema: "Portfolio",
                table: "Experiences",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Type",
                schema: "Portfolio",
                table: "Experiences",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Info_Title",
                schema: "Portfolio",
                table: "Experiences",
                column: "Info_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerUserId",
                schema: "Portfolio",
                table: "Profiles",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Info_LastName_Info_FirstName",
                schema: "Portfolio",
                table: "Profiles",
                columns: new[] { "Info_LastName", "Info_FirstName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Portfolio");

            migrationBuilder.DropTable(
                name: "ExperienceSection",
                schema: "Portfolio");

            migrationBuilder.DropTable(
                name: "Profiles",
                schema: "Portfolio");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "Portfolio");
        }
    }
}
