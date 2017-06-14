using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portfolioapi.Migrations
{
    public partial class ModelIndependance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_addresses_address_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_addresses_address");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_frameworksandlibs_portfolio_api_models_rank_RankId",
                table: "portfolio_api_models_frameworksandlibs");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_language_portfolio_api_models_rank_RankId",
                table: "portfolio_api_models_language");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_phones_phonenumber_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_phones_phonenumber");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_section_portfolio_api_models_content_ContentId",
                table: "portfolio_api_models_section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_section",
                table: "portfolio_api_models_section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_rank",
                table: "portfolio_api_models_rank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_project",
                table: "portfolio_api_models_project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_profile",
                table: "portfolio_api_models_profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_phones_phonenumber",
                table: "portfolio_api_models_phones_phonenumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_language",
                table: "portfolio_api_models_language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_interest",
                table: "portfolio_api_models_interest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_frameworksandlibs",
                table: "portfolio_api_models_frameworksandlibs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_content",
                table: "portfolio_api_models_content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_contact",
                table: "portfolio_api_models_contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_client",
                table: "portfolio_api_models_client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolio_api_models_addresses_address",
                table: "portfolio_api_models_addresses_address");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_section",
                newName: "portfolioapi_models_section");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_rank",
                newName: "portfolioapi_models_rank");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_project",
                newName: "portfolioapi_models_project");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_profile",
                newName: "portfolioapi_models_profile");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_phones_phonenumber",
                newName: "portfolioapi_models_phones_phonenumber");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_language",
                newName: "portfolioapi_models_language");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_interest",
                newName: "portfolioapi_models_interest");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_frameworksandlibs",
                newName: "portfolioapi_models_frameworksandlibs");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_content",
                newName: "portfolioapi_models_content");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_contact",
                newName: "portfolioapi_models_contact");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_client",
                newName: "portfolioapi_models_client");

            migrationBuilder.RenameTable(
                name: "portfolio_api_models_addresses_address",
                newName: "portfolioapi_models_addresses_address");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_section_ContentId",
                table: "portfolioapi_models_section",
                newName: "IX_portfolioapi_models_section_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_phones_phonenumber_ContactId",
                table: "portfolioapi_models_phones_phonenumber",
                newName: "IX_portfolioapi_models_phones_phonenumber_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_language_Title",
                table: "portfolioapi_models_language",
                newName: "IX_portfolioapi_models_language_Title");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_language_RankId",
                table: "portfolioapi_models_language",
                newName: "IX_portfolioapi_models_language_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_interest_Description",
                table: "portfolioapi_models_interest",
                newName: "IX_portfolioapi_models_interest_Description");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_frameworksandlibs_Title",
                table: "portfolioapi_models_frameworksandlibs",
                newName: "IX_portfolioapi_models_frameworksandlibs_Title");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_frameworksandlibs_RankId",
                table: "portfolioapi_models_frameworksandlibs",
                newName: "IX_portfolioapi_models_frameworksandlibs_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_client_Name_Secret",
                table: "portfolioapi_models_client",
                newName: "IX_portfolioapi_models_client_Name_Secret");

            migrationBuilder.RenameIndex(
                name: "IX_portfolio_api_models_addresses_address_ContactId",
                table: "portfolioapi_models_addresses_address",
                newName: "IX_portfolioapi_models_addresses_address_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_section",
                table: "portfolioapi_models_section",
                column: "SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_rank",
                table: "portfolioapi_models_rank",
                column: "RankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_project",
                table: "portfolioapi_models_project",
                column: "ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_profile",
                table: "portfolioapi_models_profile",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_phones_phonenumber",
                table: "portfolioapi_models_phones_phonenumber",
                column: "PhoneNumberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_language",
                table: "portfolioapi_models_language",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_interest",
                table: "portfolioapi_models_interest",
                column: "InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_frameworksandlibs",
                table: "portfolioapi_models_frameworksandlibs",
                column: "FrameworksAndLibsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_content",
                table: "portfolioapi_models_content",
                column: "ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_contact",
                table: "portfolioapi_models_contact",
                column: "ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_client",
                table: "portfolioapi_models_client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioapi_models_addresses_address",
                table: "portfolioapi_models_addresses_address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioapi_models_addresses_address_portfolioapi_models_contact_ContactId",
                table: "portfolioapi_models_addresses_address",
                column: "ContactId",
                principalTable: "portfolioapi_models_contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioapi_models_frameworksandlibs_portfolioapi_models_rank_RankId",
                table: "portfolioapi_models_frameworksandlibs",
                column: "RankId",
                principalTable: "portfolioapi_models_rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioapi_models_language_portfolioapi_models_rank_RankId",
                table: "portfolioapi_models_language",
                column: "RankId",
                principalTable: "portfolioapi_models_rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioapi_models_phones_phonenumber_portfolioapi_models_contact_ContactId",
                table: "portfolioapi_models_phones_phonenumber",
                column: "ContactId",
                principalTable: "portfolioapi_models_contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioapi_models_section_portfolioapi_models_content_ContentId",
                table: "portfolioapi_models_section",
                column: "ContentId",
                principalTable: "portfolioapi_models_content",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolioapi_models_addresses_address_portfolioapi_models_contact_ContactId",
                table: "portfolioapi_models_addresses_address");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolioapi_models_frameworksandlibs_portfolioapi_models_rank_RankId",
                table: "portfolioapi_models_frameworksandlibs");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolioapi_models_language_portfolioapi_models_rank_RankId",
                table: "portfolioapi_models_language");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolioapi_models_phones_phonenumber_portfolioapi_models_contact_ContactId",
                table: "portfolioapi_models_phones_phonenumber");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolioapi_models_section_portfolioapi_models_content_ContentId",
                table: "portfolioapi_models_section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_section",
                table: "portfolioapi_models_section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_rank",
                table: "portfolioapi_models_rank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_project",
                table: "portfolioapi_models_project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_profile",
                table: "portfolioapi_models_profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_phones_phonenumber",
                table: "portfolioapi_models_phones_phonenumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_language",
                table: "portfolioapi_models_language");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_interest",
                table: "portfolioapi_models_interest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_frameworksandlibs",
                table: "portfolioapi_models_frameworksandlibs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_content",
                table: "portfolioapi_models_content");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_contact",
                table: "portfolioapi_models_contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_client",
                table: "portfolioapi_models_client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioapi_models_addresses_address",
                table: "portfolioapi_models_addresses_address");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_section",
                newName: "portfolio_api_models_section");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_rank",
                newName: "portfolio_api_models_rank");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_project",
                newName: "portfolio_api_models_project");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_profile",
                newName: "portfolio_api_models_profile");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_phones_phonenumber",
                newName: "portfolio_api_models_phones_phonenumber");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_language",
                newName: "portfolio_api_models_language");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_interest",
                newName: "portfolio_api_models_interest");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_frameworksandlibs",
                newName: "portfolio_api_models_frameworksandlibs");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_content",
                newName: "portfolio_api_models_content");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_contact",
                newName: "portfolio_api_models_contact");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_client",
                newName: "portfolio_api_models_client");

            migrationBuilder.RenameTable(
                name: "portfolioapi_models_addresses_address",
                newName: "portfolio_api_models_addresses_address");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_section_ContentId",
                table: "portfolio_api_models_section",
                newName: "IX_portfolio_api_models_section_ContentId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_phones_phonenumber_ContactId",
                table: "portfolio_api_models_phones_phonenumber",
                newName: "IX_portfolio_api_models_phones_phonenumber_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_language_Title",
                table: "portfolio_api_models_language",
                newName: "IX_portfolio_api_models_language_Title");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_language_RankId",
                table: "portfolio_api_models_language",
                newName: "IX_portfolio_api_models_language_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_interest_Description",
                table: "portfolio_api_models_interest",
                newName: "IX_portfolio_api_models_interest_Description");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_frameworksandlibs_Title",
                table: "portfolio_api_models_frameworksandlibs",
                newName: "IX_portfolio_api_models_frameworksandlibs_Title");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_frameworksandlibs_RankId",
                table: "portfolio_api_models_frameworksandlibs",
                newName: "IX_portfolio_api_models_frameworksandlibs_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_client_Name_Secret",
                table: "portfolio_api_models_client",
                newName: "IX_portfolio_api_models_client_Name_Secret");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioapi_models_addresses_address_ContactId",
                table: "portfolio_api_models_addresses_address",
                newName: "IX_portfolio_api_models_addresses_address_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_section",
                table: "portfolio_api_models_section",
                column: "SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_rank",
                table: "portfolio_api_models_rank",
                column: "RankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_project",
                table: "portfolio_api_models_project",
                column: "ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_profile",
                table: "portfolio_api_models_profile",
                column: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_phones_phonenumber",
                table: "portfolio_api_models_phones_phonenumber",
                column: "PhoneNumberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_language",
                table: "portfolio_api_models_language",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_interest",
                table: "portfolio_api_models_interest",
                column: "InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_frameworksandlibs",
                table: "portfolio_api_models_frameworksandlibs",
                column: "FrameworksAndLibsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_content",
                table: "portfolio_api_models_content",
                column: "ContentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_contact",
                table: "portfolio_api_models_contact",
                column: "ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_client",
                table: "portfolio_api_models_client",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolio_api_models_addresses_address",
                table: "portfolio_api_models_addresses_address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_addresses_address_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_addresses_address",
                column: "ContactId",
                principalTable: "portfolio_api_models_contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_frameworksandlibs_portfolio_api_models_rank_RankId",
                table: "portfolio_api_models_frameworksandlibs",
                column: "RankId",
                principalTable: "portfolio_api_models_rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_language_portfolio_api_models_rank_RankId",
                table: "portfolio_api_models_language",
                column: "RankId",
                principalTable: "portfolio_api_models_rank",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_phones_phonenumber_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_phones_phonenumber",
                column: "ContactId",
                principalTable: "portfolio_api_models_contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_section_portfolio_api_models_content_ContentId",
                table: "portfolio_api_models_section",
                column: "ContentId",
                principalTable: "portfolio_api_models_content",
                principalColumn: "ContentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
