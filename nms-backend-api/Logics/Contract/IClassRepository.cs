using nms_backend_api.Entity;

namespace nms_backend_api.Logics.Contract
{
    public interface IClassRepository
    {
        void Create(Class1 clas );
        void Update(Class1 clas);
        void Delete(int id);
        Class1 GetClassBySemName(string name);
        Class1 GetClassByTeacherName(string name);

        List<Class1> GetAll();
       
    }
}
