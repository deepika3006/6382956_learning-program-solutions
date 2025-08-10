using EmployeeJwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeJwtApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded employee list
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = """HR""", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 70000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 65000 }
        };

        // GET all employees
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(employees);
        }

        // GET employee by ID
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound($"Employee with ID {id} not found");
            return Ok(emp);
        }

        // POST - Add employee
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee newEmployee)
        {
            newEmployee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT - Update employee
        [HttpPut("{id}")]
        [AllowAnonymous]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = updatedEmployee.Name;
            emp.Department = updatedEmployee.Department;
            emp.Salary = updatedEmployee.Salary;

            return Ok(emp);
        }

        // DELETE - Remove employee
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public ActionResult DeleteEmployee(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");

            employees.Remove(emp);
            return Ok($"Employee {id} deleted");
        }
    }
}
