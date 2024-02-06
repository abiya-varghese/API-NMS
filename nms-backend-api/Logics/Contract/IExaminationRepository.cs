using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IExaminationRepository
    {
        void Add(Examination examination);
        List<Examination> GetAll();
        Examination GetExamByExamId( int examId );
        Examination GetExamByClassId( int ClassId);
        void UpdateExam(Examination examination);
        void DeleteExam(int examId );
    }
}
