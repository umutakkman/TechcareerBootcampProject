namespace TechcareerBootcampFest4Project.Entity{

    public class Kategori{

        public int KategoriID { get; set; }
        public string? KategoriAdı { get; set; }
        public List<Araba> Arabalar { get; set; } = new List<Araba>();
    }
}