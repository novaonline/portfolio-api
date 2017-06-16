using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PortfolioApi.Migrations
{
    public partial class modelUpdates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client",
                columns: new[] { "Name", "Secret" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [Secret] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client");

            migrationBuilder.CreateIndex(
                name: "IX_pfm_clients_client_Name_Secret",
                table: "pfm_clients_client",
                columns: new[] { "Name", "Secret" });
        }
    }
}
