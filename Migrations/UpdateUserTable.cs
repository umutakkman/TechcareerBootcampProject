#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TechcareerBootcampFest4Project.Migrations;

/// <inheritdoc />
public partial class UpdateUserTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            "Surname",
            "Users",
            "Password");

        migrationBuilder.RenameColumn(
            "Name",
            "Users",
            "NameSurname");

        migrationBuilder.AddColumn<string>(
            "Email",
            "Users",
            "TEXT",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            "Email",
            "Users");

        migrationBuilder.RenameColumn(
            "Password",
            "Users",
            "Surname");

        migrationBuilder.RenameColumn(
            "NameSurname",
            "Users",
            "Name");
    }
}