using System.ComponentModel.DataAnnotations.Schema;

namespace Evolent.Repository.Models
{
    public class EmployeeAddress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int employeeId { get; set; }
        public string address { get; set; }
    }
}
