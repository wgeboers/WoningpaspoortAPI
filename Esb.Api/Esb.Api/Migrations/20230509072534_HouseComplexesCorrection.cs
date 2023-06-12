using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class HouseComplexesCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseDocument_Documents_DocumentsDocumentId",
                table: "HouseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseDocument_Houses_HousesObjectId",
                table: "HouseDocument");

            migrationBuilder.DropTable(
                name: "ComplexHouse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseComplexes",
                table: "HouseComplexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseDocument",
                table: "HouseDocument");

            migrationBuilder.DropColumn(
                name: "HouseComplexId",
                table: "HouseComplexes");

            migrationBuilder.RenameTable(
                name: "HouseDocument",
                newName: "DocumentHouse");

            migrationBuilder.RenameColumn(
                name: "HousesObjectId",
                table: "HouseComplexes",
                newName: "HouseObjectId");

            migrationBuilder.RenameColumn(
                name: "ComplexesComplexId",
                table: "HouseComplexes",
                newName: "ComplexId");

            migrationBuilder.RenameIndex(
                name: "IX_HouseDocument_HousesObjectId",
                table: "DocumentHouse",
                newName: "IX_DocumentHouse_HousesObjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseComplexes",
                table: "HouseComplexes",
                columns: new[] { "ComplexId", "HouseObjectId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentHouse",
                table: "DocumentHouse",
                columns: new[] { "DocumentsDocumentId", "HousesObjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_HouseComplexes_HouseObjectId",
                table: "HouseComplexes",
                column: "HouseObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentHouse_Documents_DocumentsDocumentId",
                table: "DocumentHouse",
                column: "DocumentsDocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentHouse_Houses_HousesObjectId",
                table: "DocumentHouse",
                column: "HousesObjectId",
                principalTable: "Houses",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseComplexes_Complexes_ComplexId",
                table: "HouseComplexes",
                column: "ComplexId",
                principalTable: "Complexes",
                principalColumn: "ComplexId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseComplexes_Houses_HouseObjectId",
                table: "HouseComplexes",
                column: "HouseObjectId",
                principalTable: "Houses",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentHouse_Documents_DocumentsDocumentId",
                table: "DocumentHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentHouse_Houses_HousesObjectId",
                table: "DocumentHouse");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseComplexes_Complexes_ComplexId",
                table: "HouseComplexes");

            migrationBuilder.DropForeignKey(
                name: "FK_HouseComplexes_Houses_HouseObjectId",
                table: "HouseComplexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseComplexes",
                table: "HouseComplexes");

            migrationBuilder.DropIndex(
                name: "IX_HouseComplexes_HouseObjectId",
                table: "HouseComplexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentHouse",
                table: "DocumentHouse");

            migrationBuilder.RenameTable(
                name: "DocumentHouse",
                newName: "HouseDocument");

            migrationBuilder.RenameColumn(
                name: "HouseObjectId",
                table: "HouseComplexes",
                newName: "HousesObjectId");

            migrationBuilder.RenameColumn(
                name: "ComplexId",
                table: "HouseComplexes",
                newName: "ComplexesComplexId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentHouse_HousesObjectId",
                table: "HouseDocument",
                newName: "IX_HouseDocument_HousesObjectId");

            migrationBuilder.AddColumn<int>(
                name: "HouseComplexId",
                table: "HouseComplexes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseComplexes",
                table: "HouseComplexes",
                column: "HouseComplexId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseDocument",
                table: "HouseDocument",
                columns: new[] { "DocumentsDocumentId", "HousesObjectId" });

            migrationBuilder.CreateTable(
                name: "ComplexHouse",
                columns: table => new
                {
                    ComplexesComplexId = table.Column<int>(type: "int", nullable: false),
                    HousesObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexHouse", x => new { x.ComplexesComplexId, x.HousesObjectId });
                    table.ForeignKey(
                        name: "FK_ComplexHouse_Complexes_ComplexesComplexId",
                        column: x => x.ComplexesComplexId,
                        principalTable: "Complexes",
                        principalColumn: "ComplexId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComplexHouse_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComplexHouse_HousesObjectId",
                table: "ComplexHouse",
                column: "HousesObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseDocument_Documents_DocumentsDocumentId",
                table: "HouseDocument",
                column: "DocumentsDocumentId",
                principalTable: "Documents",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HouseDocument_Houses_HousesObjectId",
                table: "HouseDocument",
                column: "HousesObjectId",
                principalTable: "Houses",
                principalColumn: "ObjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
