using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esb.Api.Migrations
{
    /// <inheritdoc />
    public partial class imagesExternalUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalURL",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalURL",
                table: "Images");
        }
    }
}
