using Microsoft.EntityFrameworkCore.Migrations;

namespace ThriftShop.Migrations
{
    public partial class FixedLocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Items",
                newName: "locationId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                newName: "IX_Items_locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Locations_locationId",
                table: "Items",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Locations_locationId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Items",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_locationId",
                table: "Items",
                newName: "IX_Items_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Locations_LocationId",
                table: "Items",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
