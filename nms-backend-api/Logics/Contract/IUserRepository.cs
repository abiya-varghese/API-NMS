using nms_backend_api.Entity;
using nms_backend_api.Models;

namespace nms_backend_api.Logics.Contract
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUser(string id);
        List<User> GetAllUsers();
        User GetById(string id);
        User GetByMail(string emailid);
        void UpdateUser(User user);

        User UserValidation(Login login);
        bool CheckRegister(string Role, string id);
    }
}
