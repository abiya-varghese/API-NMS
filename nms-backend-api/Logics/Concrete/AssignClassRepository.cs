﻿using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;

namespace nms_backend_api.Logics.Concrete
{
    public class AssignClassRepository:IAssignClass
    {
        private readonly MyContext _context;

        public AssignClassRepository(MyContext context)
        {
            _context = context;
        }
        public Teacher GetTeacherById(string teacherId)
        {
            return _context.teachers.FirstOrDefault(t => t.TeacherId == teacherId);
        }

        public Class1 GetClassById(string classId)
        {
            return _context.class1.FirstOrDefault(c => c.ClassId == classId);
        }
        public void AssignTeacherToClass(string classid, string teacherid)
        {
            var teacher = GetTeacherById(teacherid);
            var classEntity = GetClassById(classid);

            if (teacher != null && classEntity != null)
            {
               teacher.TeacherId = classid;

                // Save changes
                _context.SaveChanges();
            }
            else
            {
            }
        }


    }
}

