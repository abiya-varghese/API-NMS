using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;

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

        public TeacherAttendence GetTeachAttendenceById(string id)
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


        public void Delete(string id)
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
        public AttendenceModel AttendenceReportTeacher(string id, DateTime month)
        {

            try
            {
                var attendances = _context.TeachAttendences.Where(a => a.TeacherId == id && a.AttendanceDate.Date.Month == month.Month).ToList();
                float TotalDays = attendances.Count();
                float totalPresentDays = attendances.Count(a => a.status);
                int totalAbsentDays = attendances.Count(a => !a.status);
                double attendancePercentage = ((double)totalPresentDays / TotalDays) * 100;

                AttendenceModel att = new AttendenceModel();

                att.TotalPresentDays = totalPresentDays.ToString();
                att.TotalAbsentDays = totalAbsentDays.ToString();
                att.Percentage = attendancePercentage.ToString() + "%";
                att.TotalWorkingDays = TotalDays.ToString();
                return att;


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}