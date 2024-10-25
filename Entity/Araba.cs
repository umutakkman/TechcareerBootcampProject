namespace TechcareerBootcampFest4Project.Entity{

    public class Araba{

        public int ArabaID { get; set; }
        public string? Başlık { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public string? Görsel { get; set; }
        public int KoltukSayısı { get; set; }
        public int KiraÜcreti { get; set; }
        public bool Kiralanabilir { get; set; }
        public Kullanıcı? KiralayanKullanıcı { get; set; }
        public List<Kategori> Kategoriler { get; set; } = new List<Kategori>();
    }
}