using TechcareerBootcampFest4Project.Entity;

namespace TechcareerBootcampFest4Project.Data.Abstract
{

    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User User);
        void DeleteUser(User User);
    }
}