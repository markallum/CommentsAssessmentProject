using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CommentsAssessmentProject.Migrations
{
    public partial class ChangedColumnnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRoot",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "CommentContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "Comments",
                newName: "Content");

            migrationBuilder.AddColumn<bool>(
                name: "IsRoot",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
