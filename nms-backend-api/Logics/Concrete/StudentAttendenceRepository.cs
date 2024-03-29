﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nms_backend_api.DTO;
using nms_backend_api.Entity;
using nms_backend_api.Logics.Contract;
using nms_backend_api.Models;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using static System.Reflection.Metadata.BlobBuilder;

namespace nms_backend_api.Logics.Concrete
{
    public class StudentAttendenceRepository : IStudentAttendenceRepository
    {

        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public StudentAttendenceRepository(MyContext context,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        //addattendence
        public void AddStudentAttendence(StudAttendanceDTO data)
        {
            try
            {
                var item = _mapper.Map<StudentAttendence>(data);
                item.AttendanceDate = DateTime.Now;
                _context.StudAttendences.Add(item);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }



        //get all attendences
        public List<StudentAttendence> GetAllStudAttendances()
        {
            try
            {
                return _context.StudAttendences.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //get attendence by id
        public StudentAttendence GetStudAttendenceById(string studentId)
        {
            try
            {
                return _context.StudAttendences.Find(studentId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //get attendence by name

        //update 
        public void Update(StudentAttendence studattendance)
        {
            try
            {
                _context.Update(studattendance);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

            //delete
            public void Delete(string id)
            {
            try
            {
                StudentAttendence student = _context.StudAttendences.Find(id);
                _context.StudAttendences.Remove(student);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           }

        public List<StudentAttendence> GetStudentAttendencebyDate(DateTime date)
        {

            try
            {
                var studattendences = _context.StudAttendences.Where(
                       x => x.AttendanceDate.Date.Equals( date)).ToList();
                return studattendences;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public AttendenceModel AttendenceReportStudent(string id, DateTime month)
        {

            try
            {



                var getids = _context.StudAttendences.Where(x => x.StudentId == id);
                List<StudentAttendence> ta = _context.StudAttendences.Where(t => t.StudentId == id && t.AttendanceDate.Month == month.Month).ToList();
                var dates = getids.ToList();
                float TotalDays = ta.Count();
                float totalPresentDays = ta.Count(a => a.status == "P");
                int totalAbsentDays = ta.Count(a => a.status == "A");
                double attendancePercentage = ((double)totalPresentDays / TotalDays) * 100;

                AttendenceModel att = new AttendenceModel();

                att.TotalPresentDays = totalPresentDays.ToString();
                att.TotalAbsentDays = totalAbsentDays.ToString();
                att.Percentage = attendancePercentage.ToString() + "%";
                att.TotalWorkingDays = TotalDays.ToString();
                return att;
              
            }
            catch (Exception)
            {

                throw;
            }

        }
        //public List<StudentAttendence> AddStudAttendence(DateTime today, string classId, string section)
        //{
        //    try
        //    {


        //        List<StudentAttendence> ST = (_context.StudAttendences.Where(s => today == s.AttendanceDate && s.Student.Class.ClassId == classId && s.Student.Class.Section == section).ToList());

        //        StudentAttendence sts = new StudentAttendence { AttendanceDate = today, StudAttendenceId = "STEST", StudentId = "S", status = false };

        //        List<Student> s = _context.students.Where(s => s.Class.ClassId == classId && s.Class.Section == section).ToList();

        //        if (ST.Count() == 0)
        //        {
        //            foreach (Student ss in s)
        //            {
        //                Random rnd = new Random();
        //                sts.StudentId = ss.StudentId;
        //                sts.AttendanceDate = today;
        //                sts.StudAttendenceId = Guid.NewGuid().ToString();
        //                sts.status = false;
        //                _context.StudAttendences.Add(sts);
        //                _context.SaveChanges();
        //            }
        //            //_context.StudAttendences.Add(sts);
        //            //_context.SaveChanges();

        //            return _context.StudAttendences.ToList();


        //        }

        //        return _context.StudAttendences.ToList();


        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public List<StudentAttendence> GetStudAttendenceByClassAndSection(DateTime today, string classId, string section)
        {
            try
            {

                var studattendences = _context.StudAttendences.Where(
                         x => x.AttendanceDate.Date.Equals(today) && x.Student.Class.ClassId == classId && x.Student.Class.Section == section).ToList();

                return studattendences;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
 }
