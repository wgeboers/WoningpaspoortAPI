using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class HouseImagesHouseServiceContracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImage");

            migrationBuilder.DropTable(
                name: "HouseServiceContract");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HouseImages",
                columns: table => new
                {
                    HouseObjectId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImages", x => new { x.HouseObjectId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_HouseImages_Houses_HouseObjectId",
                        column: x => x.HouseObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseServiceContracts",
                columns: table => new
                {
                    HouseObjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceContractId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseServiceContracts", x => new { x.HouseObjectId, x.ServiceContractId });
                    table.ForeignKey(
                        name: "FK_HouseServiceContracts_Houses_HouseObjectId",
                        column: x => x.HouseObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseServiceContracts_ServiceContracts_ServiceContractId",
                        column: x => x.ServiceContractId,
                        principalTable: "ServiceContracts",
                        principalColumn: "ServiceContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseImages_ImageId",
                table: "HouseImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseServiceContracts_ServiceContractId",
                table: "HouseServiceContracts",
                column: "ServiceContractId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImages");

            migrationBuilder.DropTable(
                name: "HouseServiceContracts");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Houses");

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
                name: "IX_HouseImage_ImagesImageId",
                table: "HouseImage",
                column: "ImagesImageId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseServiceContract_ServiceContractsServiceContractId",
                table: "HouseServiceContract",
                column: "ServiceContractsServiceContractId");
        }
    }
}
