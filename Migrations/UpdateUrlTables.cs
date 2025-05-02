#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TechcareerBootcampFest4Project.Migrations;

/// <inheritdoc />
public partial class UpdateUrlTables : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            "Url",
            "Cars",
            "TEXT",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Url",
            "Cars");
    }
}