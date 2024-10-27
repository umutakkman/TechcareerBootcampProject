using Microsoft.EntityFrameworkCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete.EfCore{

    public class SiteContext : DbContext{

        public SiteContext(DbContextOptions<SiteContext> options) : base(options){}

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
    }
}