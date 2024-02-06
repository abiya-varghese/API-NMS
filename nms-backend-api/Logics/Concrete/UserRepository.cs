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
            string tempPass = "Password@123";
            string tempUname = (from s in _context.students
                                where s.StudentId == user.UserId
                                select s.FirstName).FirstOrDefault();
            user.Password = tempPass;
            if (user.Role == "student")
            {
                user.UserName = "snex" + tempUname;
            }
            else if (user.Role == "teacher")
            {
                user.UserName = "tnex" + tempUname;
            }
            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = _context.users.Find(id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.users.ToList();
        }

        public User GetById(int id)
        {
            User user = _context.users.Find(id);
            return user;
        }

        public void UpdateUser(User user)
        {
            if (user.Role == "student")
            {
                string tempUname = (from s in _context.students
                                    join u in _context.users on s.StudentId equals u.UserId
                                    select s.FirstName).SingleOrDefault();

                user.UserName = "snex" + tempUname;
            }
            else if (user.Role == "teacher")
            {
                string tempUname = (from t in _context.teachers
                                    join u in _context.users on t.TeacherId equals u.UserId
                                    where t.TeacherId == u.UserId
                                    select t.FName).SingleOrDefault();
                user.UserName = "tnex" + tempUname;
            }
            _context.users.Update(user);
            _context.SaveChanges();
        }
    }
}
