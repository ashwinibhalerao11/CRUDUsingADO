using System.ComponentModel.DataAnnotations;
namespace CRUDUsingADO.Models
{
    public class Student
    {

        [Key] // to define rollno is a PK in the DB table
        [ScaffoldColumn(false)]
        public int RollNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal Percentage { get; set; }

    }
}
