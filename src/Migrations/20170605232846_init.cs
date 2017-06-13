using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace portfolioapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "portfolio_api_models_contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_interest",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_interest", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_rank",
                columns: table => new
                {
                    RankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_rank", x => x.RankId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_addresses_address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    ContactId = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_addresses_address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_addresses_address_portfolio_api_models_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "portfolio_api_models_contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_phones_phonenumber",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_phones_phonenumber", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_phones_phonenumber_portfolio_api_models_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "portfolio_api_models_contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AboutMe = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_profile_portfolio_api_models_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "portfolio_api_models_contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_frameworksandlibs",
                columns: table => new
                {
                    FrameworksAndLibsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_frameworksandlibs", x => x.FrameworksAndLibsId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_frameworksandlibs_portfolio_api_models_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "portfolio_api_models_rank",
                        principalColumn: "RankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_language", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_language_portfolio_api_models_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "portfolio_api_models_rank",
                        principalColumn: "RankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_addresses_address_ContactId",
                table: "portfolio_api_models_addresses_address",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_frameworksandlibs_RankId",
                table: "portfolio_api_models_frameworksandlibs",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_language_RankId",
                table: "portfolio_api_models_language",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_phones_phonenumber_ContactId",
                table: "portfolio_api_models_phones_phonenumber",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_profile_ContactId",
                table: "portfolio_api_models_profile",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolio_api_models_addresses_address");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_frameworksandlibs");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_interest");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_language");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_phones_phonenumber");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_profile");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_project");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_rank");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_contact");
        }
    }
}
