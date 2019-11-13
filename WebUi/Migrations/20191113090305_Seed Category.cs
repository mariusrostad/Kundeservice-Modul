using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUi.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    UserQuestionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.UserQuestionId);
                    table.ForeignKey(
                        name: "FK_UserQuestions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { -1, "Test 1" });

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_CategoryId",
                table: "UserQuestions",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
