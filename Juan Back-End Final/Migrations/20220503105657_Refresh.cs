using Microsoft.EntityFrameworkCore.Migrations;

namespace Juan_Back_End_Final.Migrations
{
    public partial class Refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Color_ColorId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Size_SizeId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Size",
                table: "Size");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "Size",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Colors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colors",
                table: "Colors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Colors_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Sizes_SizeId",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductColor_Colors_ColorId",
                table: "ProductColor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSize_Sizes_SizeId",
                table: "ProductSize");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colors",
                table: "Colors");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "Size");

            migrationBuilder.RenameTable(
                name: "Colors",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Size",
                table: "Size",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductColor_Color_ColorId",
                table: "ProductColor",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSize_Size_SizeId",
                table: "ProductSize",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
