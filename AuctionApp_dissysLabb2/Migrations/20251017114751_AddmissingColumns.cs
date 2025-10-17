using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp_dissysLabb2.Migrations
{
    /// <inheritdoc />
    public partial class AddmissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Auctions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
