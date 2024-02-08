using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IScheduleClass
    {
        void Create(ScheduleClass clas);
        void Update(ScheduleClass clas);
        void Delete(string id);
        List<ScheduleClass> GetClassByTeacherID(string teacherId);
        List<ScheduleClass> GetClassByClassID(string classId);
        List<ScheduleClass> GetAll();


    }
}