using TechcareerBootcampFest4Project.Data.Abstract;
using TechcareerBootcampFest4Project.Data.Concrete.EfCore;
using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private SiteContext _context;
        public EfUserRepository(SiteContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void AddUser(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }

        public void DeleteUser(User User)
        {
            _context.Users.Remove(User);
            _context.SaveChanges();
        }
    }
}