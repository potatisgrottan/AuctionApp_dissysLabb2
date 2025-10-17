using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp_dissysLabb2.Migrations
{
    /// <inheritdoc />
    public partial class AddTheMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "HighestBidAmount",
                table: "Auctions",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "HighestBidder",
                table: "Auctions",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBidAmount",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "HighestBidder",
                table: "Auctions");
        }
    }
}
