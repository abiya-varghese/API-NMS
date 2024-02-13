using AutoMapper;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;

namespace nms_backend_api.Logics.Concrete
{
    public class TeacherAttendenceRepository : ITeacherAttendenceRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;
        public TeacherAttendenceRepository(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //add teacher attendence
        public void AddTeacherAttendence(TeacherAttendenceDTO data)
        {
            try
            {
                var item = _mapper.Map<TeacherAttendence>(data);
                item.AttendanceDate = DateTime.Now;
                _context.TeachAttendences.Add(item);
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
                float totalPresentDays = attendances.Count(a => a.status == "P");
                int totalAbsentDays = attendances.Count(a => a.status == "A");
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
        //public List<TeacherAttendence> AddTeacherAttendenceAutogenerate(DateTime today)
        //{
        //    try
        //    {


        //        List<TeacherAttendence> ST = (_context.TeachAttendences.Where(s => today == s.AttendanceDate).ToList());

        //        TeacherAttendence sts = new TeacherAttendence { AttendanceDate = today, TeacherAttendId = "STEST", TeacherId = "S", status = false };

        //        List<Teacher> s = _context.teachers.ToList();

        //        if (ST.Count() == 0)
        //        {
        //            foreach (Teacher ss in s)
        //            {
        //                Random rnd = new Random();
        //                sts.TeacherId = ss.TeacherId;
        //                sts.AttendanceDate = today;
        //                sts.TeacherAttendId = Guid.NewGuid().ToString();
        //                sts.status = false;
        //                _context.TeachAttendences.Add(sts);
        //                _context.SaveChanges();
        //            }
        //            //_context.StudAttendences.Add(sts);
        //            //_context.SaveChanges();

        //            return _context.TeachAttendences.ToList();


        //        }

        //        return _context.TeachAttendences.ToList();


        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}