using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API.Migrations
{
    /// <inheritdoc />
    public partial class editQsnAnsMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Answers_AnswerId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Articles_ArticleId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Questions_QuestionId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswerMaps_Users_UserId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerMaps_AnswerId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerMaps_ArticleId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerMaps_QuestionId",
                table: "QuestionAnswerMaps");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswerMaps_UserId",
                table: "QuestionAnswerMaps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerMaps_AnswerId",
                table: "QuestionAnswerMaps",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerMaps_ArticleId",
                table: "QuestionAnswerMaps",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerMaps_QuestionId",
                table: "QuestionAnswerMaps",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswerMaps_UserId",
                table: "QuestionAnswerMaps",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Answers_AnswerId",
                table: "QuestionAnswerMaps",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Articles_ArticleId",
                table: "QuestionAnswerMaps",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Questions_QuestionId",
                table: "QuestionAnswerMaps",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswerMaps_Users_UserId",
                table: "QuestionAnswerMaps",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
