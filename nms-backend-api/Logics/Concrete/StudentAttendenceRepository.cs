using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace nms_backend_api.Logics.Concrete
{
    public class StudentAttendenceRepository : IStudentAttendenceRepository
    {

        private readonly MyContext _context;

        public StudentAttendenceRepository(MyContext context)
        {
            _context = context;
        }

        //addattendence
        //public void AddStudAttendence(StudentAttendence studattendance)
        //{
        //    try
        //    {
        //        _context.StudAttendences.Add(studattendance);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        

        //get all attendences
        public List<StudentAttendence> GetAllStudAttendances()
        {
            try
            {
                return _context.StudAttendences.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //get attendence by id
        public StudentAttendence GetStudAttendenceById(string studentId)
        {
            try
            {
                return _context.StudAttendences.Find(studentId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //get attendence by name

        //update 
        public void Update(StudentAttendence studattendance)
        {
            try
            {
                _context.Update(studattendance);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

            //delete
            public void Delete(string id)
            {
            try
            {
                StudentAttendence student = _context.StudAttendences.Find(id);
                _context.StudAttendences.Remove(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           }

        public List<StudentAttendence> GetStudentAttendencebyDate(DateTime date)
        {

            try
            {
                var studattendences = _context.StudAttendences.Where(
                       x => x.AttendanceDate.Date.Equals( date)).ToList();
                return studattendences;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public AttendenceModel AttendenceReportStudent(string id, DateTime month)
        {

            try
            {



                var attendances = _context.StudAttendences.Where(a => a.StudentId == id && a.AttendanceDate.Date.Month == month.Month).ToList();
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
        public List<StudentAttendence> AddStudAttendence(DateTime today, string classId, string section)
        {
            try
            {


                List<StudentAttendence> ST = (_context.StudAttendences.Where(s => today == s.AttendanceDate && s.Student.Class.ClassId == classId && s.Student.Class.Section == section).ToList());

                StudentAttendence sts = new StudentAttendence { AttendanceDate = today, StudAttendenceId = "STEST", StudentId = "S", status = false };

                List<Student> s = _context.students.Where(s => s.Class.ClassId == classId && s.Class.Section == section).ToList();

                if (ST.Count() == 0)
                {
                    foreach (Student ss in s)
                    {
                        Random rnd = new Random();
                        sts.StudentId = ss.StudentId;
                        sts.AttendanceDate = today;
                        sts.StudAttendenceId = Guid.NewGuid().ToString();
                        sts.status = false;
                        _context.StudAttendences.Add(sts);
                        _context.SaveChanges();
                    }
                    //_context.StudAttendences.Add(sts);
                    //_context.SaveChanges();

                    return _context.StudAttendences.ToList();


                }

                return _context.StudAttendences.ToList();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<StudentAttendence> GetStudAttendenceByClassAndSection(DateTime today, string classId, string section)
        {
            try
            {

                var studattendences = _context.StudAttendences.Where(
                         x => x.AttendanceDate.Date.Equals(today) && x.Student.Class.ClassId == classId && x.Student.Class.Section == section).ToList();

                return studattendences;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
 }
