using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evolent.Repository.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required] 
        public string lastName { get; set; }
        [Required]
        public string email { get; set; }
        public string address { get; set; }
        public int age { get; set; }
    }
}
