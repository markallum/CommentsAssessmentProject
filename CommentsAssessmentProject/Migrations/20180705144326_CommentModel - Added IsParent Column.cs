using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CommentsAssessmentProject.Migrations
{
    public partial class CommentModelAddedIsParentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsParent",
                table: "Comments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsParent",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
