using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechcareerBootcampFest4Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arabalar",
                columns: table => new
                {
                    ArabaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Başlık = table.Column<string>(type: "TEXT", nullable: true),
                    Marka = table.Column<string>(type: "TEXT", nullable: true),
                    Model = table.Column<string>(type: "TEXT", nullable: true),
                    Görsel = table.Column<string>(type: "TEXT", nullable: true),
                    KoltukSayısı = table.Column<int>(type: "INTEGER", nullable: false),
                    KiraÜcreti = table.Column<int>(type: "INTEGER", nullable: false),
                    Kiralanabilir = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arabalar", x => x.ArabaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KategoriAdı = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Şifre = table.Column<string>(type: "TEXT", nullable: true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    ArabaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Arabalar_ArabaID",
                        column: x => x.ArabaID,
                        principalTable: "Arabalar",
                        principalColumn: "ArabaID");
                });

            migrationBuilder.CreateTable(
                name: "ArabaKategori",
                columns: table => new
                {
                    ArabalarArabaID = table.Column<int>(type: "INTEGER", nullable: false),
                    KategorilerKategoriID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArabaKategori", x => new { x.ArabalarArabaID, x.KategorilerKategoriID });
                    table.ForeignKey(
                        name: "FK_ArabaKategori_Arabalar_ArabalarArabaID",
                        column: x => x.ArabalarArabaID,
                        principalTable: "Arabalar",
                        principalColumn: "ArabaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArabaKategori_Kategoriler_KategorilerKategoriID",
                        column: x => x.KategorilerKategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArabaKategori_KategorilerKategoriID",
                table: "ArabaKategori",
                column: "KategorilerKategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_ArabaID",
                table: "Kullanıcılar",
                column: "ArabaID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArabaKategori");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Arabalar");
        }
    }
}
