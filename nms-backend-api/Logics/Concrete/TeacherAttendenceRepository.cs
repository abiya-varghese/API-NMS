using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class TeacherAttendenceRepository : ITeacherAttendenceRepository
    {
        private readonly MyContext _context;

        public TeacherAttendenceRepository(MyContext context)
        {
            _context = context;
        }

        //add teacher attendence
        public void AddTeachAttendence(TeacherAttendence teachattendance)
        {
            try
            {
                _context.TeachAttendences.Add(teachattendance);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //GetAllTeachAttendences
        public List<TeacherAttendence> GetAllTeachAttendences()
        {
            try
            {
                return _context.TeachAttendences.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TeacherAttendence GetTeachAttendenceById(int id)
        {
            try
            {
                return _context.TeachAttendences.Find(id);
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void Delete(int id)
        {
            try
            {
                TeacherAttendence teachattendance = _context.TeachAttendences.Find(id);
                _context.TeachAttendences.Remove(teachattendance);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }



        public void Update(TeacherAttendence teachattendance)
        {
            try
            {
                _context.Update(teachattendance);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TeacherAttendence> GetTeachersAttendencebyDate(DateTime date)
        {
            try
            {
                var taechattendences = _context.TeachAttendences.Where(
                       x => x.AttendanceDate.Date.Equals(date)).ToList();
                return taechattendences;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}