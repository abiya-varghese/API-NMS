using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
           
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
