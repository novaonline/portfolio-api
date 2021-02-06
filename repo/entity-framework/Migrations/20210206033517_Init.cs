using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioApi.Repository.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 74, DateTimeKind.Utc).AddTicks(9846)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 74, DateTimeKind.Utc).AddTicks(9590)),
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
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 83, DateTimeKind.Utc).AddTicks(7737)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 83, DateTimeKind.Utc).AddTicks(7459)),
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
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 73, DateTimeKind.Utc).AddTicks(3)),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2021, 2, 6, 3, 35, 17, 71, DateTimeKind.Utc).AddTicks(8418)),
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
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerUserId",
                table: "Contacts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Info_Email",
                table: "Contacts",
                column: "Info_Email");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_OwnerUserId",
                table: "Experiences",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Type",
                table: "Experiences",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Info_Title",
                table: "Experiences",
                column: "Info_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_OwnerUserId",
                table: "Profiles",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Info_LastName_Info_FirstName",
                table: "Profiles",
                columns: new[] { "Info_LastName", "Info_FirstName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ExperienceSection");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Experiences");
        }
    }
}
