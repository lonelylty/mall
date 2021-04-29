using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Heals.CSX.Mall.Migrations
{
    public partial class AddedCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BuyerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Carts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_CartItems_CartId",
                table: "M_CartItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_M_CartItems_M_Carts_CartId",
                table: "M_CartItems",
                column: "CartId",
                principalTable: "M_Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_M_CartItems_M_Carts_CartId",
                table: "M_CartItems");

            migrationBuilder.DropTable(
                name: "M_Carts");

            migrationBuilder.DropIndex(
                name: "IX_M_CartItems_CartId",
                table: "M_CartItems");
        }
    }
}
