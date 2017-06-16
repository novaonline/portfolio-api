using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PortfolioApi.Migrations
{
    public partial class modelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pfm_clients_info");

            migrationBuilder.DropIndex(
                name: "IX_pfm_clients_client_Secret",
                table: "pfm_clients_client");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_libraries_info");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_languages_info");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_frameworks_info");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "pfm_projects_info");

            migrationBuilder.DropColumn(
                name: "HtmlId",
                table: "pfm_contents_info");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_libraries_library",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_languages_language",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_frameworks_framework",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_projects_project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HtmlId",
                table: "pfm_contents_content",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "pfm_clients_client",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_libraries_library_Title",
                table: "pfm_rankableitems_libraries_library",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_languages_language_Title",
                table: "pfm_rankableitems_languages_language",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_rankableitems_frameworks_framework_Title",
                table: "pfm_rankableitems_frameworks_framework",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_projects_project_Title",
                table: "pfm_projects_project",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_contents_content_HtmlId",
                table: "pfm_contents_content",
                column: "HtmlId");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client",
                columns: new[] { "Name", "Secret" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pfm_rankableitems_libraries_library_Title",
                table: "pfm_rankableitems_libraries_library");

            migrationBuilder.DropIndex(
                name: "IX_pfm_rankableitems_languages_language_Title",
                table: "pfm_rankableitems_languages_language");

            migrationBuilder.DropIndex(
                name: "IX_pfm_rankableitems_frameworks_framework_Title",
                table: "pfm_rankableitems_frameworks_framework");

            migrationBuilder.DropIndex(
                name: "IX_pfm_projects_project_Title",
                table: "pfm_projects_project");

            migrationBuilder.DropIndex(
                name: "IX_pfm_contents_content_HtmlId",
                table: "pfm_contents_content");

            migrationBuilder.DropIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_libraries_library");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_languages_language");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_rankableitems_frameworks_framework");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "pfm_projects_project");

            migrationBuilder.DropColumn(
                name: "HtmlId",
                table: "pfm_contents_content");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "pfm_clients_client");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_libraries_info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_languages_info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "pfm_rankableitems_frameworks_info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "pfm_projects_info",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HtmlId",
                table: "pfm_contents_info",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pfm_clients_info",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pfm_clients_info", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_pfm_clients_info_pfm_clients_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "pfm_clients_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pfm_clients_client_Secret",
                table: "pfm_clients_client",
                column: "Secret");
        }
    }
}
