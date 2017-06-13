using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace portfolioapi.Migrations
{
    public partial class added_content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "portfolio_api_models_content",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackgroundUrl = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    HtmlId = table.Column<string>(nullable: true),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_content", x => x.ContentId);
                });

            migrationBuilder.CreateTable(
                name: "portfolio_api_models_section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    ContentId = table.Column<int>(nullable: false),
                    Meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolio_api_models_section", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_portfolio_api_models_section_portfolio_api_models_content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "portfolio_api_models_content",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolio_api_models_section_ContentId",
                table: "portfolio_api_models_section",
                column: "ContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolio_api_models_section");

            migrationBuilder.DropTable(
                name: "portfolio_api_models_content");
        }
    }
}
