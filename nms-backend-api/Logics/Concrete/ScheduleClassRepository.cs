﻿using AutoMapper;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace nms_backend_api.Logics.Concrete
{
    public class ScheduleClassRepository : IScheduleClass
    {
        private readonly MyContext _context;
        public List<ScheduleClass> classs = new List<ScheduleClass>();
        private readonly IMapper _mapper;
        public ScheduleClassRepository(MyContext context, IMapper mapper)
        {
            _context = context;
        }
        public void Create(ScheduleClass clas)
        {
            try
            {
                _context.Schclass.Add(clas);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ScheduleClass> GetAll()
        {
            try
            {
                return _context.Schclass.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ScheduleClass> GetClassByClassID(string classId)
        {
            try
            {
                var scheclassById = _context.Schclass.Where(
                      x => x.ClassId.Equals(classId)).ToList();
                return scheclassById;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<ScheduleClass> GetClassBySubject(string subject)
        {
            try
            {
                var scheclassBysub = _context.Schclass.Where(
                      x => x.Subject.Equals(subject)).ToList();
                return scheclassBysub;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ScheduleClass> GetClassByTeacherID(string teacherId)
        {
            try
            {
                var scheclassBytrId = _context.Schclass.Where(
                     x => x.Teacher.TeacherId.Equals(teacherId)).ToList();
                return scheclassBytrId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(ScheduleClass clas)
        {
            try
            {
                _context.Schclass.Update(clas);
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
                ScheduleClass schclass = _context.Schclass.Find(id);
                _context.Schclass.Remove(schclass);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AssignTeacherToClass(ScheduleClass cls)
        {

            try
            {
                _context.Schclass.Update(cls);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<ScheduleClass> GetAllAssignedDetails()
        {
            try
            {
                return _context.Schclass.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}