using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI
{
    public class EmployeeFines
    {
        [Key]
        public int EmployeeFineId { get; set; }
        public int EmployeeId { get; set; }
        public string FineDescription { get; set; } = string.Empty;
    }
}
