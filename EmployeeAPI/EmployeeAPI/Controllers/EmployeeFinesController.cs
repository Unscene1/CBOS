using EmployeeAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFinesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeFinesController(DataContext context)
        {
            _context = context;
        }
        
        
        [HttpGet]
        public async Task<ActionResult<List<EmployeeFines>>> GetEmployeeFines(Employee employee)
        {
            return Ok(await _context.Employees.Where(x => x.EmployeeId == employee.EmployeeId).Select(x => x.EmployeeFines).ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult<List<EmployeeFines>>> CreateEmployeeFine(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.EmployeeFines = employee.EmployeeFines;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<EmployeeFines>>> UpdateEmployeeFine(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.EmployeeId);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.EmployeeFines.FineDescription = employee.EmployeeFines.FineDescription;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployeeFines>>> DeleteEmployeeFine(int id)
        {
            var dbFine = await _context.Fines.FindAsync(id);
            if (dbFine == null)
                return BadRequest("Fine not found.");
            
            _context.Fines.Remove(dbFine);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
