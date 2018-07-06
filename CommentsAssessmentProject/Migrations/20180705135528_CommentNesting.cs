using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CommentsAssessmentProject.Migrations
{
    public partial class CommentNesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentIdId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentIdId",
                table: "Comments",
                newName: "ParentCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentIdId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ParentCommentId",
                table: "Comments",
                newName: "ParentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_ParentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentIdId",
                table: "Comments",
                column: "ParentIdId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
