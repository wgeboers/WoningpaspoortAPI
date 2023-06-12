using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class HouseDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentHouse");

            migrationBuilder.CreateTable(
                name: "HouseDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    HouseObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDocuments", x => new { x.DocumentId, x.HouseObjectId });
                    table.ForeignKey(
                        name: "FK_HouseDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseDocuments_Houses_HouseObjectId",
                        column: x => x.HouseObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseDocuments_HouseObjectId",
                table: "HouseDocuments",
                column: "HouseObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseDocuments");

            migrationBuilder.CreateTable(
                name: "DocumentHouse",
                columns: table => new
                {
                    DocumentsDocumentId = table.Column<int>(type: "int", nullable: false),
                    HousesObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentHouse", x => new { x.DocumentsDocumentId, x.HousesObjectId });
                    table.ForeignKey(
                        name: "FK_DocumentHouse_Documents_DocumentsDocumentId",
                        column: x => x.DocumentsDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentHouse_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentHouse_HousesObjectId",
                table: "DocumentHouse",
                column: "HousesObjectId");
        }
    }
}
