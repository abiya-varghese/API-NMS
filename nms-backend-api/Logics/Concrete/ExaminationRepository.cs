using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nms_backend_api.Logics.Concrete
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly MyContext _context;

        public ExaminationRepository(MyContext context)
        {
            _context = context;
        }
        public void Add(Examination examination)
        {
            try
            {
                _context.examination.Add(examination);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteExam(string examId)
        {
            try
            {
                Examination examination = _context.examination.Find(examId);
                _context.examination.Remove(examination);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Examination> GetAll()
        {
            try
            {
                return _context.examination.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Examination> GetExamByClassId(string ClassId)
        {
            try
            {
                var exam = _context.examination.Where(
                       x => x.ClassId.Equals(ClassId)).ToList();
                return exam;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Examination GetExamByExamId(string examId)
        {
            try
            {
                return _context.examination.Find(examId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateExam(Examination examination)
        {
            try
            {
                _context.examination.Update(examination);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void RecordResult(Mark mark)
        {
            try
            {
                _context.mark.Add(mark);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mark> GetAllResult()
        {
            try
            {
                return _context.mark.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mark> GetAllResultByStudId(string studId)
        {
            try
            {
                var exam = _context.mark.Where(
                    x => x.StudentId.Equals(studId)).ToList();
                return exam;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mark> GetAllResultByExamId(string examId)
        {
            try
            {
                var exam = _context.mark.Where(
                       x => x.ExamId.Equals(examId)).ToList();
                return exam;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateResult(Mark mark)
        {
            try
            {
                _context.mark.Update(mark);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteResult(string markId)
        {
            try
            {
                Mark mark = _context.mark.Find(markId);
                _context.mark.Remove(mark);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Mark GetMarkByMarkId(string markId)
        {
            try
            {
                return _context.mark.Find(markId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public StudentReportModel ReportStudent(string id)
        //{
        //    try
        //    {



        //        var student = _context.students.Where(a => a.StudentId == id).ToList();
        //        var total = 0.0;
        //        foreach (Mark s in student)
        //        {
        //            total = total + s.Marks;
        //        }
        //        var totalNoofMarks = student.Count();
        //        double Percentage = ((double)total / totalNoofMarks) * 100;
        //        string studentName = _context.mark.Select(a => a.StudentId).ToString();
        //        StudentReportModel att = new StudentReportModel();

        //        att.StudentName = student.
        //        att.TotalAbsentDays = totalAbsentDays.ToString();
        //        att.Percentage = attendancePercentage.ToString() + "%";
        //        att.TotalWorkingDays = TotalDays.ToString();
        //        return att;


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
