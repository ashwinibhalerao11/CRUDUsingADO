
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Books
    {

        [Key] // to define Id is a PK in the DB table
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthName { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
