using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GRRoWmvc.Data.Migrations
{
    public partial class DogCreateLastModifed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITRequests_ITRequests_ITRequestId",
                table: "ITRequests");

            migrationBuilder.DropIndex(
                name: "IX_ITRequests_ITRequestId",
                table: "ITRequests");

            migrationBuilder.DropColumn(
                name: "ITRequestId",
                table: "ITRequests");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreateDate",
                table: "Dogs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "Dogs",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Dogs");

            migrationBuilder.AddColumn<int>(
                name: "ITRequestId",
                table: "ITRequests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ITRequests_ITRequestId",
                table: "ITRequests",
                column: "ITRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ITRequests_ITRequests_ITRequestId",
                table: "ITRequests",
                column: "ITRequestId",
                principalTable: "ITRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
