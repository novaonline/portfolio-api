using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioApi.Repository.EntityFramework.Migrations
{
    public partial class ProfileIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Portfolio");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Portfolio",
                table: "Profiles",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 536, DateTimeKind.Utc).AddTicks(5475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 413, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                schema: "Portfolio",
                table: "Profiles",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 537, DateTimeKind.Utc).AddTicks(7845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 414, DateTimeKind.Utc).AddTicks(5963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Portfolio",
                table: "Experiences",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 547, DateTimeKind.Utc).AddTicks(5603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(6826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                schema: "Portfolio",
                table: "Experiences",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 547, DateTimeKind.Utc).AddTicks(5922),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(7379));

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                schema: "Portfolio",
                table: "Experiences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProfileId",
                schema: "Portfolio",
                table: "Experiences",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Experiences_ProfileId",
                schema: "Portfolio",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                schema: "Portfolio",
                table: "Experiences");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Portfolio",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 413, DateTimeKind.Utc).AddTicks(4702),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 536, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                schema: "Portfolio",
                table: "Profiles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 414, DateTimeKind.Utc).AddTicks(5963),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 537, DateTimeKind.Utc).AddTicks(7845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                schema: "Portfolio",
                table: "Experiences",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(6826),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 547, DateTimeKind.Utc).AddTicks(5603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddDate",
                schema: "Portfolio",
                table: "Experiences",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 427, DateTimeKind.Utc).AddTicks(7379),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2021, 2, 23, 1, 32, 51, 547, DateTimeKind.Utc).AddTicks(5922));

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 416, DateTimeKind.Utc).AddTicks(5627)),
                    OwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2021, 2, 15, 17, 4, 58, 416, DateTimeKind.Utc).AddTicks(5311)),
                    Info_AddressType = table.Column<int>(type: "int", nullable: true),
                    Info_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Info_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_PhoneType = table.Column<int>(type: "int", nullable: true),
                    Info_Postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info_StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OwnerUserId",
                schema: "Portfolio",
                table: "Contacts",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Info_Email",
                schema: "Portfolio",
                table: "Contacts",
                column: "Info_Email");
        }
    }
}
