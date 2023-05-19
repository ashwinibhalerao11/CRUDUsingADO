using System.ComponentModel.DataAnnotations;
namespace CRUDUsingADO.Models
{
    public class Employees
    {

        [Key] // to define Id is a PK in the DB table
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
