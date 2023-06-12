using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddHouseManyToManyComplex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseComplex",
                columns: table => new
                {
                    ComplexesComplexId = table.Column<int>(type: "int", nullable: false),
                    HousesObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseComplex", x => new { x.ComplexesComplexId, x.HousesObjectId });
                    table.ForeignKey(
                        name: "FK_HouseComplex_Complexes_ComplexesComplexId",
                        column: x => x.ComplexesComplexId,
                        principalTable: "Complexes",
                        principalColumn: "ComplexId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseComplex_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseComplex_HousesObjectId",
                table: "HouseComplex",
                column: "HousesObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseComplex");
        }
    }
}
