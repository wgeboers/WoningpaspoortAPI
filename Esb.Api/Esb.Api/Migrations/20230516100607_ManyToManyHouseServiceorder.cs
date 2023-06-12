using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyHouseServiceorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseServiceorders",
                columns: table => new
                {
                    HouseObjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceorderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseServiceorders", x => new { x.HouseObjectId, x.ServiceorderId });
                    table.ForeignKey(
                        name: "FK_HouseServiceorders_Houses_HouseObjectId",
                        column: x => x.HouseObjectId,
                        principalTable: "Houses",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseServiceorders_Serviceorders_ServiceorderId",
                        column: x => x.ServiceorderId,
                        principalTable: "Serviceorders",
                        principalColumn: "ServiceorderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseServiceorders_ServiceorderId",
                table: "HouseServiceorders",
                column: "ServiceorderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseServiceorders");
        }
    }
}
