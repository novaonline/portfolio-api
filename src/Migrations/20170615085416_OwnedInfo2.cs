using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PortfolioApi.Migrations
{
    public partial class OwnedInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pfm_clients_client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    Secret = table.Column<string>(nullable: true, defaultValueSql: "NEWID()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_clients_client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contents_content",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contents_content", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_interests_interest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_interests_interest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_profiles_profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_profiles_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_projects_project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_projects_project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_ranks_rank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_ranks_rank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pfm_clients_client_Info",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_clients_client_Info", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_pfm_clients_client_Info_pfm_clients_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "pfm_clients_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_contact_Info",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_contact_Info", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_pfm_contacts_contact_Info_pfm_contacts_contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "pfm_contacts_contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contents_sections_section",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContentId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contents_sections_section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_contents_sections_section_pfm_contents_content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "pfm_contents_content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contents_content_Info",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false),
                    BackgroundUrl = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    HtmlId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contents_content_Info", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_pfm_contents_content_Info_pfm_contents_content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "pfm_contents_content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_interests_interest_Info",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_interests_interest_Info", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_pfm_interests_interest_Info_pfm_interests_interest_InterestId",
                        column: x => x.InterestId,
                        principalTable: "pfm_interests_interest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_profiles_profile_Info",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false),
                    AboutMe = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_profiles_profile_Info", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_pfm_profiles_profile_Info_pfm_profiles_profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "pfm_profiles_profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_projects_project_Info",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_projects_project_Info", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_pfm_projects_project_Info_pfm_projects_project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "pfm_projects_project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_frameworks_framework",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_frameworks_framework", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_frameworks_framework_pfm_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "pfm_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_languages_language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_languages_language", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_languages_language_pfm_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "pfm_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_libraries_library",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    RankId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_libraries_library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_libraries_library_pfm_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "pfm_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_ranks_rank_Info",
                columns: table => new
                {
                    RankId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_ranks_rank_Info", x => x.RankId);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_ranks_rank_Info_pfm_rankableitems_ranks_rank_RankId",
                        column: x => x.RankId,
                        principalTable: "pfm_rankableitems_ranks_rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_addresses_address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContactId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_addresses_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_contacts_addresses_address_pfm_contacts_contact_Info_ContactId",
                        column: x => x.ContactId,
                        principalTable: "pfm_contacts_contact_Info",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_phones_phone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ContactId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_phones_phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pfm_contacts_phones_phone_pfm_contacts_contact_Info_ContactId",
                        column: x => x.ContactId,
                        principalTable: "pfm_contacts_contact_Info",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contents_sections_section_Info",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contents_sections_section_Info", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_pfm_contents_sections_section_Info_pfm_contents_sections_section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "pfm_contents_sections_section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_frameworks_framework_Info",
                columns: table => new
                {
                    FrameworkId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_frameworks_framework_Info", x => x.FrameworkId);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_frameworks_framework_Info_pfm_rankableitems_frameworks_framework_FrameworkId",
                        column: x => x.FrameworkId,
                        principalTable: "pfm_rankableitems_frameworks_framework",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_languages_language_Info",
                columns: table => new
                {
                    LanguageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_languages_language_Info", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_languages_language_Info_pfm_rankableitems_languages_language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "pfm_rankableitems_languages_language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_rankableitems_libraries_library_Info",
                columns: table => new
                {
                    LibraryId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_rankableitems_libraries_library_Info", x => x.LibraryId);
                    table.ForeignKey(
                        name: "FK_pfm_rankableitems_libraries_library_Info_pfm_rankableitems_libraries_library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "pfm_rankableitems_libraries_library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_addresses_address_Info",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_addresses_address_Info", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_pfm_contacts_addresses_address_Info_pfm_contacts_addresses_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "pfm_contacts_addresses_address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pfm_contacts_phones_phone_Info",
                columns: table => new
                {
                    PhoneId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_contacts_phones_phone_Info", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_pfm_contacts_phones_phone_Info_pfm_contacts_phones_phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "pfm_contacts_phones_phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pfm_contacts_addresses_address_ContactId",
                table: "pfm_contacts_addresses_address",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_contacts_phones_phone_ContactId",
                table: "pfm_contacts_phones_phone",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_contents_sections_section_ContentId",
                table: "pfm_contents_sections_section",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_frameworks_framework_RankId",
                table: "pfm_rankableitems_frameworks_framework",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_languages_language_RankId",
                table: "pfm_rankableitems_languages_language",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_libraries_library_RankId",
                table: "pfm_rankableitems_libraries_library",
                column: "RankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pfm_clients_client_Info");

            migrationBuilder.DropTable(
                name: "pfm_contacts_addresses_address_Info");

            migrationBuilder.DropTable(
                name: "pfm_contacts_phones_phone_Info");

            migrationBuilder.DropTable(
                name: "pfm_contents_content_Info");

            migrationBuilder.DropTable(
                name: "pfm_contents_sections_section_Info");

            migrationBuilder.DropTable(
                name: "pfm_interests_interest_Info");

            migrationBuilder.DropTable(
                name: "pfm_profiles_profile_Info");

            migrationBuilder.DropTable(
                name: "pfm_projects_project_Info");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_frameworks_framework_Info");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_languages_language_Info");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_libraries_library_Info");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_ranks_rank_Info");

            migrationBuilder.DropTable(
                name: "pfm_clients_client");

            migrationBuilder.DropTable(
                name: "pfm_contacts_addresses_address");

            migrationBuilder.DropTable(
                name: "pfm_contacts_phones_phone");

            migrationBuilder.DropTable(
                name: "pfm_contents_sections_section");

            migrationBuilder.DropTable(
                name: "pfm_interests_interest");

            migrationBuilder.DropTable(
                name: "pfm_profiles_profile");

            migrationBuilder.DropTable(
                name: "pfm_projects_project");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_frameworks_framework");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_languages_language");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_libraries_library");

            migrationBuilder.DropTable(
                name: "pfm_contacts_contact_Info");

            migrationBuilder.DropTable(
                name: "pfm_contents_content");

            migrationBuilder.DropTable(
                name: "pfm_rankableitems_ranks_rank");

            migrationBuilder.DropTable(
                name: "pfm_contacts_contact");
        }
    }
}
