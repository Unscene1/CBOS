namespace EmployeeAPI
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + ' ' + LastName;
        public string ContactNumber { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public EmployeeFines EmployeeFines { get; set; } = new EmployeeFines();
    }
}
