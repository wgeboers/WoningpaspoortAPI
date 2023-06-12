using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHouseComplex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseComplex_Complexes_ComplexesComplexId",
                table: "HouseComplex");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseComplex_Houses_HousesObjectId",
                table: "HouseComplex");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseComplex",
                table: "HouseComplex");

            migrationBuilder.RenameTable(
                name: "HouseComplex",
                newName: "ComplexHouse");

            migrationBuilder.RenameIndex(
                name: "IX_HouseComplex_HousesObjectId",
                table: "ComplexHouse",
                newName: "IX_ComplexHouse_HousesObjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComplexHouse",
                table: "ComplexHouse",
                columns: new[] { "ComplexesComplexId", "HousesObjectId" });

            migrationBuilder.CreateTable(
                name: "HouseComplexes",
                columns: table => new
                {
                    HouseComplexId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplexesComplexId = table.Column<int>(type: "int", nullable: false),
                    HousesObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseComplexes", x => x.HouseComplexId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ComplexHouse_Complexes_ComplexesComplexId",
                table: "ComplexHouse",
                column: "ComplexesComplexId",
                principalTable: "Complexes",
                principalColumn: "ComplexId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplexHouse_Houses_HousesObjectId",
                table: "ComplexHouse",
                column: "HousesObjectId",
                principalTable: "Houses",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplexHouse_Complexes_ComplexesComplexId",
                table: "ComplexHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplexHouse_Houses_HousesObjectId",
                table: "ComplexHouse");

            migrationBuilder.DropTable(
                name: "HouseComplexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComplexHouse",
                table: "ComplexHouse");

            migrationBuilder.RenameTable(
                name: "ComplexHouse",
                newName: "HouseComplex");

            migrationBuilder.RenameIndex(
                name: "IX_ComplexHouse_HousesObjectId",
                table: "HouseComplex",
                newName: "IX_HouseComplex_HousesObjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseComplex",
                table: "HouseComplex",
                columns: new[] { "ComplexesComplexId", "HousesObjectId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HouseComplex_Complexes_ComplexesComplexId",
                table: "HouseComplex",
                column: "ComplexesComplexId",
                principalTable: "Complexes",
                principalColumn: "ComplexId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseComplex_Houses_HousesObjectId",
                table: "HouseComplex",
                column: "HousesObjectId",
                principalTable: "Houses",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
