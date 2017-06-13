using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portfolioapi.Migrations
{
    public partial class addedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "portfolio_api_models_language",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "portfolio_api_models_interest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "portfolio_api_models_frameworksandlibs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_language_Title",
                table: "portfolio_api_models_language",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_interest_Description",
                table: "portfolio_api_models_interest",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_frameworksandlibs_Title",
                table: "portfolio_api_models_frameworksandlibs",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_portfolio_api_models_language_Title",
                table: "portfolio_api_models_language");

            migrationBuilder.DropIndex(
                name: "IX_portfolio_api_models_interest_Description",
                table: "portfolio_api_models_interest");

            migrationBuilder.DropIndex(
                name: "IX_portfolio_api_models_frameworksandlibs_Title",
                table: "portfolio_api_models_frameworksandlibs");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "portfolio_api_models_language",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "portfolio_api_models_interest",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "portfolio_api_models_frameworksandlibs",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
