using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restaurant_api.Migrations
{
    /// <inheritdoc />
    public partial class ColumnProdutosIdsVinculationTableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdutosIds",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "OrderModelId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_OrderModelId",
                table: "Produtos",
                column: "OrderModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_OrderModelId",
                table: "Produtos",
                column: "OrderModelId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_OrderModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_OrderModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "OrderModelId",
                table: "Produtos");

            migrationBuilder.AddColumn<string>(
                name: "ProdutosIds",
                table: "Pedidos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
