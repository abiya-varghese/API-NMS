using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

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

        public Examination GetExamByClassId(int ClassId)
        {
            try
            {
                return _context.examination.Find(ClassId);
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
    }
}
