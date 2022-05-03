using Microsoft.EntityFrameworkCore.Migrations;

namespace Juan_Back_End_Final.Migrations
{
    public partial class UpdateDb_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials");

            migrationBuilder.DropIndex(
                name: "IX_Socials_SettingId",
                table: "Socials");

            migrationBuilder.DropColumn(
                name: "SettingId",
                table: "Socials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettingId",
                table: "Socials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Socials_SettingId",
                table: "Socials",
                column: "SettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Socials_Settings_SettingId",
                table: "Socials",
                column: "SettingId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
