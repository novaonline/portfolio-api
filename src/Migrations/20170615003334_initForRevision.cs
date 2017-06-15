using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PortfolioApi.Migrations
{
    public partial class initForRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "portfolioapi_models_clients_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_clients_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_addresses_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_addresses_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_phones_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_phones_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contents_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgroundUrl = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    HtmlId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contents_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contents_sections_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contents_sections_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_interests_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_interests_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_profiles_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AboutMe = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_profiles_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_projects_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_projects_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_frameworks_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_frameworks_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_languages_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_languages_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_libraries_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_libraries_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_ranks_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_ranks_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_clients_client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    Secret = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_clients_client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_clients_client_portfolioapi_models_clients_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_clients_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_addresses_address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContactId = table.Column<int>(nullable: false),
                    InfoId = table.Column<int>(nullable: true),
                    InfoId1 = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_addresses_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contacts_addresses_address_portfolioapi_models_contacts_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_contacts_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contacts_addresses_address_portfolioapi_models_contacts_addresses_info_InfoId1",
                        column: x => x.InfoId1,
                        principalTable: "portfolioapi_models_contacts_addresses_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contacts_contact_portfolioapi_models_contacts_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_contacts_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contacts_phones_phone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContactId = table.Column<int>(nullable: false),
                    InfoId = table.Column<int>(nullable: true),
                    InfoId1 = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contacts_phones_phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contacts_phones_phone_portfolioapi_models_contacts_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_contacts_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contacts_phones_phone_portfolioapi_models_contacts_phones_info_InfoId1",
                        column: x => x.InfoId1,
                        principalTable: "portfolioapi_models_contacts_phones_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contents_content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contents_content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contents_content_portfolioapi_models_contents_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_contents_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_interests_interest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_interests_interest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_interests_interest_portfolioapi_models_interests_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_interests_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_profiles_profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_profiles_profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_profiles_profile_portfolioapi_models_profiles_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_profiles_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_projects_project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_projects_project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_projects_project_portfolioapi_models_projects_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_projects_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_ranks_rank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_ranks_rank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_ranks_rank_portfolioapi_models_rankableitems_ranks_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_rankableitems_ranks_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_contents_sections_section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContentId = table.Column<int>(nullable: false),
                    InfoId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_contents_sections_section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contents_sections_section_portfolioapi_models_contents_content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "portfolioapi_models_contents_content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_contents_sections_section_portfolioapi_models_contents_sections_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_contents_sections_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_frameworks_framework",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_frameworks_framework", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_frameworks_framework_portfolioapi_models_rankableitems_frameworks_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_rankableitems_frameworks_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_frameworks_framework_portfolioapi_models_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "portfolioapi_models_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_languages_language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_languages_language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_languages_language_portfolioapi_models_rankableitems_languages_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_rankableitems_languages_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_languages_language_portfolioapi_models_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "portfolioapi_models_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolioapi_models_rankableitems_libraries_library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    InfoId = table.Column<int>(nullable: true),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioapi_models_rankableitems_libraries_library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_libraries_library_portfolioapi_models_rankableitems_libraries_info_InfoId",
                        column: x => x.InfoId,
                        principalTable: "portfolioapi_models_rankableitems_libraries_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_portfolioapi_models_rankableitems_libraries_library_portfolioapi_models_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "portfolioapi_models_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_clients_client_InfoId",
                table: "portfolioapi_models_clients_client",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contacts_addresses_address_InfoId",
                table: "portfolioapi_models_contacts_addresses_address",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contacts_addresses_address_InfoId1",
                table: "portfolioapi_models_contacts_addresses_address",
                column: "InfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contacts_contact_InfoId",
                table: "portfolioapi_models_contacts_contact",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contacts_phones_phone_InfoId",
                table: "portfolioapi_models_contacts_phones_phone",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contacts_phones_phone_InfoId1",
                table: "portfolioapi_models_contacts_phones_phone",
                column: "InfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contents_content_InfoId",
                table: "portfolioapi_models_contents_content",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contents_sections_section_ContentId",
                table: "portfolioapi_models_contents_sections_section",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_contents_sections_section_InfoId",
                table: "portfolioapi_models_contents_sections_section",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_interests_interest_InfoId",
                table: "portfolioapi_models_interests_interest",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_profiles_profile_InfoId",
                table: "portfolioapi_models_profiles_profile",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_projects_project_InfoId",
                table: "portfolioapi_models_projects_project",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_frameworks_framework_InfoId",
                table: "portfolioapi_models_rankableitems_frameworks_framework",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_frameworks_framework_RankId",
                table: "portfolioapi_models_rankableitems_frameworks_framework",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_languages_language_InfoId",
                table: "portfolioapi_models_rankableitems_languages_language",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_languages_language_RankId",
                table: "portfolioapi_models_rankableitems_languages_language",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_libraries_library_InfoId",
                table: "portfolioapi_models_rankableitems_libraries_library",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_libraries_library_RankId",
                table: "portfolioapi_models_rankableitems_libraries_library",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioapi_models_rankableitems_ranks_rank_InfoId",
                table: "portfolioapi_models_rankableitems_ranks_rank",
                column: "InfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolioapi_models_clients_client");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_addresses_address");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_contact");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_phones_phone");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contents_sections_section");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_interests_interest");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_profiles_profile");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_projects_project");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_frameworks_framework");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_languages_language");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_libraries_library");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_clients_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_addresses_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contacts_phones_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contents_content");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contents_sections_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_interests_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_profiles_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_projects_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_frameworks_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_languages_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_libraries_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_ranks_rank");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_contents_info");

            migrationBuilder.DropTable(
                name: "portfolioapi_models_rankableitems_ranks_info");
        }
    }
}
