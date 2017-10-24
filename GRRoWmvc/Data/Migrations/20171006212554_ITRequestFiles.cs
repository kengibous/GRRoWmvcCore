using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GRRoWmvc.Data.Migrations
{
    public partial class ITRequestFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ITRequestId",
                table: "ITRequests",
                type: "int",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
