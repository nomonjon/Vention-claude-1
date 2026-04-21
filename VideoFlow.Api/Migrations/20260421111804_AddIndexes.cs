using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoFlow.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Videos_UserId",
                table: "Videos",
                newName: "idx_videos_user_id");

            migrationBuilder.CreateIndex(
                name: "idx_videos_created_at",
                table: "Videos",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "idx_users_email_unique",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_videos_created_at",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "idx_users_email_unique",
                table: "Users");

            migrationBuilder.RenameIndex(
                name: "idx_videos_user_id",
                table: "Videos",
                newName: "IX_Videos_UserId");
        }
    }
}
