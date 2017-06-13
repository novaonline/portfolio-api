using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portfolioapi.Migrations
{
    public partial class init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolio_api_models_profile_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_profile");

            migrationBuilder.DropIndex(
                name: "IX_portfolio_api_models_profile_ContactId",
                table: "portfolio_api_models_profile");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "portfolio_api_models_profile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "portfolio_api_models_profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_profile_ContactId",
                table: "portfolio_api_models_profile",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolio_api_models_profile_portfolio_api_models_contact_ContactId",
                table: "portfolio_api_models_profile",
                column: "ContactId",
                principalTable: "portfolio_api_models_contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
