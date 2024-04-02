using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Author_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Book_Available = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Lent_By_User_id = table.Column<int>(type: "int", nullable: false),
                    Currently_Borrowed_By_User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tokens_Available = table.Column<int>(type: "int", nullable: false),
                    Books_Borrowed = table.Column<int>(type: "int", nullable: false),
                    Books_Lent = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Books_Borrowed", "Books_Lent", "ConfirmPassword", "Email", "Name", "Password", "Token", "Tokens_Available", "UserName" },
                values: new object[,]
                {
                    { 1, 0, 0, "mark@123", "mark@gmail.com", "Mark Stark", "mark@123", " ", 1, "stark123" },
                    { 2, 0, 0, "rupali@123", "rups@gmail.com", "Rupali Singh", "rupali@123", " ", 1, "rups" },
                    { 3, 0, 0, "ronitroy@123", "ronit@gmail.com", "Ronit Roy", "ronitroy@123", " ", 1, "ronit" },
                    { 4, 0, 0, "abc@123", "john@gmail.com", "John Disouza", "abc@123", " ", 1, "john" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
