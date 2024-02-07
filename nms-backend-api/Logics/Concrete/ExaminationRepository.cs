using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
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

        public void DeleteExam(int examId)
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

        public List<Examination> GetExamByClassId(int ClassId)
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

        public Examination GetExamByExamId(int examId)
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
        public Mark GetAllResultByStudId(int studId)
        {
            try
            {
                return _context.mark.Find(studId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Mark> GetAllResultByExamId(int examId)
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
        public void DeleteResult(int markId)
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
    }
}
