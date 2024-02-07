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

        public void Delete(int id)
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
                foreach (var k in classs)
                {
                    if (k.ClassName == name)
                    {
                        return k;
                    }
                }
                return null;
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
                foreach (var k in classs)
                {
                    if (k.Teacher.FName == name)
                    {
                        return k;
                    }
                }
                return null;
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
