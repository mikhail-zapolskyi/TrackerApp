using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project777.Repositories.Migrations
{
    public partial class UpdateJobWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCategories_JobCategoryID",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "JobCategoryID",
                table: "Jobs",
                newName: "JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobCategoryID",
                table: "Jobs",
                newName: "IX_Jobs_JobCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Jobs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCategories_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCategories_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "Jobs",
                newName: "JobCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                newName: "IX_Jobs_JobCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCategories_JobCategoryID",
                table: "Jobs",
                column: "JobCategoryID",
                principalTable: "JobCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
