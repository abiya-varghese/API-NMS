using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
using System.Text.RegularExpressions;

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
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Check if the exception is due to a unique constraint violation
                if (ex.InnerException is SqlException sqlEx &&
                    sqlEx.Number == 2627)// SQL Server error code for unique constraint violation
                {
                    // Extract the name of the constraint from the exception message
                    var match = Regex.Match(sqlEx.Message, @"'(?<name>.+?)'");
                    if (match.Success && match.Groups["name"].Value == "PK_tbl_user")
                    {
                        // Throw a new exception with a custom error message
                        
                        throw new Exception("This email is already used.");
                    }
                }

                // Re-throw the original exception if it's not due to a unique constraint violation
                throw;
            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                User user = _context.users.Find(id);
                _context.users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.users.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetById(string id)
        {
            try
            {
                User user = _context.users.Find(id);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {

                _context.users.Update(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User UserValidation(Login login)
        {
            try
            {
                var user = _context.users.SingleOrDefault(x => x.UserName == login.UserName && x.Password==login.Password);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CheckRegister(string Role,string id)
        {
            if (Role == "Student")
            {
               return _context.students.Any(x=>x.StudentId == id);
            }
            else if (Role =="Teacher")
            {
               return _context.teachers.Any(x=>x.TeacherId == id);
            }
            else
            {
                return false;
            }
        }
        public User GetByMail(string email)
        {
            try
            {
                var user = _context.users.FirstOrDefault(x => x.Emailid == email);
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
