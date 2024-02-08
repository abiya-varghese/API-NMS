using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IExaminationRepository
    {
        void Add(Examination examination);
        List<Examination> GetAll();
        Examination GetExamByExamId(string examId);
        List<Examination> GetExamByClassId(string ClassId);
        void UpdateExam(Examination examination);
        void DeleteExam(string examId);

        void RecordResult(Mark mark);
        List<Mark> GetAllResult();
        Mark GetAllResultByStudId(string studId);
        List<Mark> GetAllResultByExamId(string examId);
        void UpdateResult(Mark mark);
        void DeleteResult(string markId);


    }
}
