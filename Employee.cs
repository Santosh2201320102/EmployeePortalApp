using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspCrud.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("ID")]  //display id hoga but in database col ka name emp_id hoga
        public int Emp_Id { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Employee Name")]
        public string Emp_Name { get; set; }

        [Required]
        [DisplayName("Employee Gender")]
        public string Emp_Gender { get; set; }

        [Required]
        [DisplayName("Employee age")]
        public int Emp_Age { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime Emp_Dob { get; set; }

    }
}
