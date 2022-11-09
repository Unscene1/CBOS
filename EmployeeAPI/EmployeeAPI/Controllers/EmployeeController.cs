using EmployeeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");
            
            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.ContactNumber = employee.ContactNumber;
            dbEmployee.EmailAddress = employee.EmailAddress;
            dbEmployee.IsActive = employee.IsActive;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.IsActive = employee.IsActive;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
