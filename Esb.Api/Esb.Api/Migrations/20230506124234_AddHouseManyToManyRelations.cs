using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddHouseManyToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseDocument",
                columns: table => new
                {
                    DocumentsDocumentId = table.Column<int>(type: "int", nullable: false),
                    HousesObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDocument", x => new { x.DocumentsDocumentId, x.HousesObjectId });
                    table.ForeignKey(
                        name: "FK_HouseDocument_Documents_DocumentsDocumentId",
                        column: x => x.DocumentsDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseDocument_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseImage",
                columns: table => new
                {
                    HousesObjectId = table.Column<int>(type: "int", nullable: false),
                    ImagesImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImage", x => new { x.HousesObjectId, x.ImagesImageId });
                    table.ForeignKey(
                        name: "FK_HouseImage_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseImage_Images_ImagesImageId",
                        column: x => x.ImagesImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseServiceContract",
                columns: table => new
                {
                    HousesObjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceContractsServiceContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseServiceContract", x => new { x.HousesObjectId, x.ServiceContractsServiceContractId });
                    table.ForeignKey(
                        name: "FK_HouseServiceContract_Houses_HousesObjectId",
                        column: x => x.HousesObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseServiceContract_ServiceContracts_ServiceContractsServiceContractId",
                        column: x => x.ServiceContractsServiceContractId,
                        principalTable: "ServiceContracts",
                        principalColumn: "ServiceContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseDocument_HousesObjectId",
                table: "HouseDocument",
                column: "HousesObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_ImagesImageId",
                table: "HouseImage",
                column: "ImagesImageId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseServiceContract_ServiceContractsServiceContractId",
                table: "HouseServiceContract",
                column: "ServiceContractsServiceContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseDocument");

            migrationBuilder.DropTable(
                name: "HouseImage");

            migrationBuilder.DropTable(
                name: "HouseServiceContract");
        }
    }
}
