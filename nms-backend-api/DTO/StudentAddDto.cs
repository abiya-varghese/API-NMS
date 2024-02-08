using System.ComponentModel.DataAnnotations;

namespace nms_backend_api.DTO
{
    public class StudentAddDto
    {
        [Key]
        public string StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Rollno { get; set; }

        public string Address { get; set; }

        //public string Email { get; set; }

        public DateTime DOB { get; set; }


       // public string Contactno { get; set; }


        public string Gender { get; set; }//to be enum

        public DateTime RegDate { get; set; }

        public string ClassId { get; set; }//to be enum
    }
}
