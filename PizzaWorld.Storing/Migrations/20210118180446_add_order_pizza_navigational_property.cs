using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class add_order_pizza_navigational_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_OrderEntityID",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "OrderEntityID",
                table: "Pizzas");

            migrationBuilder.CreateTable(
                name: "APizzaModelOrder",
                columns: table => new
                {
                    OrdersEntityID = table.Column<long>(type: "bigint", nullable: false),
                    PizzasEntityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APizzaModelOrder", x => new { x.OrdersEntityID, x.PizzasEntityID });
                    table.ForeignKey(
                        name: "FK_APizzaModelOrder_Orders_OrdersEntityID",
                        column: x => x.OrdersEntityID,
                        principalTable: "Orders",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APizzaModelOrder_Pizzas_PizzasEntityID",
                        column: x => x.PizzasEntityID,
                        principalTable: "Pizzas",
                        principalColumn: "EntityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APizzaModelOrder_PizzasEntityID",
                table: "APizzaModelOrder",
                column: "PizzasEntityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APizzaModelOrder");

            migrationBuilder.AddColumn<long>(
                name: "OrderEntityID",
                table: "Pizzas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderEntityID",
                table: "Pizzas",
                column: "OrderEntityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderEntityID",
                table: "Pizzas",
                column: "OrderEntityID",
                principalTable: "Orders",
                principalColumn: "EntityID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
