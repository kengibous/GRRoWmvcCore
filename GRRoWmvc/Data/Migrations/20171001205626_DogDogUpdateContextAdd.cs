using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GRRoWmvc.Data.Migrations
{
    public partial class DogDogUpdateContextAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdoptionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AdoptionFee = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BridgeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DogId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EnergyLevel = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    InteractionWithCats = table.Column<int>(type: "int", nullable: false),
                    InteractionWithDogs = table.Column<int>(type: "int", nullable: false),
                    InteractionWithKids = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SurrenderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogUpdates_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogUpdates_DogId",
                table: "DogUpdates",
                column: "DogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogUpdates");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
