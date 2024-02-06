using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUsers();
        User GetById(int id);
        void UpdateUser(User user);
    }
}
