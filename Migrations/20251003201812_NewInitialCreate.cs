using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VertoDevTest.Migrations
{
    /// <inheritdoc />
    public partial class NewInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageSections_MediaItems_MediaItemId",
                table: "PageSections");

            migrationBuilder.DropIndex(
                name: "IX_PageSections_MediaItemId",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "HtmlTag",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "MediaItemId",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "AltText",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "MediaItems");

            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "PageSections",
                newName: "DisplayOrder");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "MediaItems",
                newName: "FilePath");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PageSections",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PageSections",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PageSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "PageSections",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PageSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "PageSections",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SectionType",
                table: "PageSections",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MediaItems",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "MediaItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "MediaItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MediaItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MediaItems",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "MediaItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_DisplayOrder",
                table: "PageSections",
                column: "DisplayOrder");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_SectionType",
                table: "PageSections",
                column: "SectionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageSections_DisplayOrder",
                table: "PageSections");

            migrationBuilder.DropIndex(
                name: "IX_PageSections_SectionType",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "SectionType",
                table: "PageSections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MediaItems");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "MediaItems");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "PageSections",
                newName: "SortOrder");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "MediaItems",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "PageSections",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "PageSections",
                type: "NVARCHAR(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HtmlTag",
                table: "PageSections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MediaItemId",
                table: "PageSections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "MediaItems",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "MediaItems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "MediaItems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PageSections_MediaItemId",
                table: "PageSections",
                column: "MediaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageSections_MediaItems_MediaItemId",
                table: "PageSections",
                column: "MediaItemId",
                principalTable: "MediaItems",
                principalColumn: "Id");
        }
    }
}
