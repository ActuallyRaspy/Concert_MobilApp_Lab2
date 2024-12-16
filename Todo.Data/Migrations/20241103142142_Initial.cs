using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nchar(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "ID", "Comments", "Completed", "Name", "Notes" },
                values: new object[,]
                {
                    { "6bb8a868-dba1-4f1a-93b7-24ebce87e243", "Maybe take Coursera Courses too?", true, "Learn app development", "Take Microsoft Learn Courses" },
                    { "b94afb54-a1cb-4313-8af3-b7511551b33b", "Maybe use Visual Studio Code instead?", false, "Develop apps", "Use Visual Studio and Visual Studio for Mac" },
                    { "ecfa6f80-3671-4911-aabe-63cc442c1ecf", null, false, "Publish apps", "All app stores" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItems");
        }
    }
}
