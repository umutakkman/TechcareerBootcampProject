using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete.EfCore{

    public class KiraSitesiContext : DbContext{

        public KiraSitesiContext(DbContextOptions<KiraSitesiContext> options) : base(options){}

        public DbSet<Araba> Arabalar => Set<Araba>();
        public DbSet<Kategori> Kategoriler => Set<Kategori>();
        public DbSet<Kullanıcı> Kullanıcılar => Set<Kullanıcı>();
    }
}