using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class ClassRepository : IClassRepository
    {
        private readonly MyContext _context;
        public List<Class1> classs = new List<Class1>();
        private readonly IMapper _mapper;
        public ClassRepository(MyContext context,IMapper mapper)
        {
            _context = context;
        }
        public void Create(Class1 clas)
        {
            try
            {
                _context.class1.Add(clas);
                _context.SaveChanges();
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
                Class1 classes = _context.class1.Find(id);
                _context.class1.Remove(classes);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Class1> GetAll()
        {
            try
            {
                return _context.class1.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Class1 GetClassBySemName(string name)
        {
            try
            {
                var clas = _context.class1.FirstOrDefault(x => x.ClassName == name);
                return clas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Class1 GetClassByTeacherName(string name)
        {
            try
            {
                var cls=_context.class1.FirstOrDefault(x=>x.ClassName == name);
                return cls;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Class1 clas)
        {
            try
            {
                _context.class1.Update(clas);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
