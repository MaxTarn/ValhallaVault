using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations.ProgramDb
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionModelId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subcategories_SubcategoryModelId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Categories_CategoryModelId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Segments_SegmentModelId",
                table: "Subcategories");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionIds",
                table: "Subcategories");

            migrationBuilder.DropColumn(
                name: "SubcategoryIds",
                table: "Segments");

            migrationBuilder.DropColumn(
                name: "SegmentIds",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "SegmentModelId",
                table: "Subcategories",
                newName: "SegmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_SegmentModelId",
                table: "Subcategories",
                newName: "IX_Subcategories_SegmentId");

            migrationBuilder.RenameColumn(
                name: "CategoryModelId",
                table: "Segments",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Segments_CategoryModelId",
                table: "Segments",
                newName: "IX_Segments_CategoryId");

            migrationBuilder.RenameColumn(
                name: "SubcategoryModelId",
                table: "Questions",
                newName: "SubcategoryId");

            migrationBuilder.RenameColumn(
                name: "AnswerIds",
                table: "Questions",
                newName: "Explanation");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SubcategoryModelId",
                table: "Questions",
                newName: "IX_Questions_SubcategoryId");

            migrationBuilder.RenameColumn(
                name: "QuestionModelId",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionModelId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Att skydda sig mot Bedrägerier" },
                    { 2, "Cybersäkerhet för företag" },
                    { 3, "Cyberspionage" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subcategories_SubcategoryId",
                table: "Questions",
                column: "SubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Categories_CategoryId",
                table: "Segments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Segments_SegmentId",
                table: "Subcategories",
                column: "SegmentId",
                principalTable: "Segments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subcategories_SubcategoryId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Categories_CategoryId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Segments_SegmentId",
                table: "Subcategories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "SegmentId",
                table: "Subcategories",
                newName: "SegmentModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Subcategories_SegmentId",
                table: "Subcategories",
                newName: "IX_Subcategories_SegmentModelId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Segments",
                newName: "CategoryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Segments_CategoryId",
                table: "Segments",
                newName: "IX_Segments_CategoryModelId");

            migrationBuilder.RenameColumn(
                name: "SubcategoryId",
                table: "Questions",
                newName: "SubcategoryModelId");

            migrationBuilder.RenameColumn(
                name: "Explanation",
                table: "Questions",
                newName: "AnswerIds");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_SubcategoryId",
                table: "Questions",
                newName: "IX_Questions_SubcategoryModelId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "QuestionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuestionModelId");

            migrationBuilder.AddColumn<string>(
                name: "QuestionIds",
                table: "Subcategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubcategoryIds",
                table: "Segments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegmentIds",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_QuestionId",
                table: "UserQuestions",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionModelId",
                table: "Answers",
                column: "QuestionModelId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subcategories_SubcategoryModelId",
                table: "Questions",
                column: "SubcategoryModelId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_Categories_CategoryModelId",
                table: "Segments",
                column: "CategoryModelId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Segments_SegmentModelId",
                table: "Subcategories",
                column: "SegmentModelId",
                principalTable: "Segments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
