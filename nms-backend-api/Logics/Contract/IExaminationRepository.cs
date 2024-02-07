using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IExaminationRepository
    {
        void Add(Examination examination);
        List<Examination> GetAll();
        Examination GetExamByExamId(int examId);
        List<Examination> GetExamByClassId(int ClassId);
        void UpdateExam(Examination examination);
        void DeleteExam(int examId);

        void RecordResult(Mark mark);
        List<Mark> GetAllResult();
        Mark GetAllResultByStudId(int studId);
        List<Mark> GetAllResultByExamId(int examId);
        void UpdateResult(Mark mark);
        void DeleteResult(int markId);


    }
}
