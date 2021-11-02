using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendUppgift1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Adresses_AdressesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AdressesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AdressesId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AdressId",
                table: "Customers",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Adresses_AdressId",
                table: "Customers",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Adresses_AdressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AdressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "AdressesId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AdressesId",
                table: "Customers",
                column: "AdressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Adresses_AdressesId",
                table: "Customers",
                column: "AdressesId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
