#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TechcareerBootcampFest4Project.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Cars",
            table => new
            {
                CarID = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Title = table.Column<string>("TEXT", nullable: false),
                Brand = table.Column<string>("TEXT", nullable: true),
                Type = table.Column<string>("TEXT", nullable: true),
                Model = table.Column<string>("TEXT", nullable: true),
                Image = table.Column<string>("TEXT", nullable: true),
                Seats = table.Column<int>("INTEGER", nullable: false),
                RentPrice = table.Column<decimal>("TEXT", nullable: false),
                IsActive = table.Column<bool>("INTEGER", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Cars", x => x.CarID); });

        migrationBuilder.CreateTable(
            "Categories",
            table => new
            {
                CategoryID = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                TypeCategory = table.Column<string>("TEXT", nullable: true),
                BrandCategory = table.Column<string>("TEXT", nullable: true),
                SeatCategory = table.Column<int>("INTEGER", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Categories", x => x.CategoryID); });

        migrationBuilder.CreateTable(
            "Users",
            table => new
            {
                UserID = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Username = table.Column<string>("TEXT", nullable: true),
                Name = table.Column<string>("TEXT", nullable: true),
                Surname = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Users", x => x.UserID); });

        migrationBuilder.CreateTable(
            "CarCategory",
            table => new
            {
                CarsCarID = table.Column<int>("INTEGER", nullable: false),
                CategoriesCategoryID = table.Column<int>("INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CarCategory", x => new { x.CarsCarID, x.CategoriesCategoryID });
                table.ForeignKey(
                    "FK_CarCategory_Cars_CarsCarID",
                    x => x.CarsCarID,
                    "Cars",
                    "CarID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_CarCategory_Categories_CategoriesCategoryID",
                    x => x.CategoriesCategoryID,
                    "Categories",
                    "CategoryID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_CarCategory_CategoriesCategoryID",
            "CarCategory",
            "CategoriesCategoryID");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "CarCategory");

        migrationBuilder.DropTable(
            "Users");

        migrationBuilder.DropTable(
            "Cars");

        migrationBuilder.DropTable(
            "Categories");
    }
}