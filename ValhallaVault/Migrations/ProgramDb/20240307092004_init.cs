using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValhallaVault.Migrations.ProgramDb
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Categories_CategoryId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Segments_SegmentId",
                table: "Subcategories");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segments_Categories_CategoryModelId",
                table: "Segments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Segments_SegmentModelId",
                table: "Subcategories");

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
    }
}
