using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIProj.Filters;
using WebAPIProj.Models;


namespace WebAPIProj.Controllers
{
    [CustomAuthFilter]
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        //private static List<string> employees = new() { "Alice", "Boba", "David" };

        private static List<Employee> _employees = new List<Employee>();

        public EmployeeController()
        {
            if (_employees.Count == 0)
                _employees = GetStandardEmployeeList();
        }

        // READ - All
        [HttpGet]
        //[CustomAuthFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //public ActionResult<List<string>> Get() => employees;


        public ActionResult<List<EmployeeDto>> Get()
        {
            var employeeDtos = _employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Permanent = e.Permanent,
                DepartmentName = e.Department?.Name,
                Skills = e.Skills?.Select(s => s.Name).ToList(),
                DateOfBirth = e.DateOfBirth
            }).ToList();

            return Ok(employeeDtos);
        }

        //CRASH
        [HttpGet("crash")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrashTest()
        {
            throw new Exception("Test exception - simulated crash.");
        }

        // CREATE - POST
        [HttpPost]
        public ActionResult Add([FromBody] EmployeeDto employeeDto)
        {
            var newEmployee = new Employee
            {
                Id = _employees.Max(e => e.Id) + 1,
                Name = employeeDto.Name,
                Salary = employeeDto.Salary,
                Permanent = employeeDto.Permanent,
                Department = new Department { Name = employeeDto.DepartmentName },
                Skills = employeeDto.Skills?.Select(s => new Skill { Name = s }).ToList(),
                DateOfBirth = employeeDto.DateOfBirth
            };

            //employees.Add(employeeDto.Name);

            _employees.Add(newEmployee);
            return Ok("Employee added.");
        }

        // UPDATE - PUT
        //[HttpPut("{index}")]
        //public ActionResult Update(int index, [FromBody] EmployeeDto updatedEmployee)
        //{
        //    if (index < 0 || index >= _employees.Count)
        //        return NotFound();

        //    var employee = _employees[index];
        //    employee.Name = updatedEmployee.Name;
        //    employee.Salary = updatedEmployee.Salary;
        //    employee.Permanent = updatedEmployee.Permanent;
        //    employee.Department = new Department { Name = updatedEmployee.DepartmentName };
        //    employee.Skills = updatedEmployee.Skills?.Select(s => new Skill { Name = s }).ToList();
        //    employee.DateOfBirth = updatedEmployee.DateOfBirth;

        //    return Ok("Employee updated.");
        //}

        //[HttpPut("{index}")]
        //public ActionResult Update(int index, [FromBody] EmployeeDto employeeDto)
        //{
        //    if (index < 0 || index >= employees.Count)
        //        return NotFound();

        //    employees[index] = employeeDto.Name;
        //    return Ok("Employee updated.");
        //}

        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> Update(int id, [FromBody] EmployeeDto updatedEmployee)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return BadRequest("Invalid employee id");

            // Update employee data
            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Permanent = updatedEmployee.Permanent;
            employee.Department = new Department { Name = updatedEmployee.DepartmentName };
            employee.Skills = updatedEmployee.Skills?.Select(s => new Skill { Name = s }).ToList();
            employee.DateOfBirth = updatedEmployee.DateOfBirth;

            // Map back to DTO and return
            var resultDto = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                Permanent = employee.Permanent,
                DepartmentName = employee.Department?.Name,
                Skills = employee.Skills?.Select(s => s.Name).ToList(),
                DateOfBirth = employee.DateOfBirth
            };

            return Ok(resultDto);
        }

        // DELETE
        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= _employees.Count)
                return NotFound();

            _employees.RemoveAt(index);
            return Ok("Employee deleted.");
        }

        //public ActionResult Delete(int index)
        //{
        //    if (index < 0 || index >= employees.Count)
        //        return NotFound();

        //    employees.RemoveAt(index);
        //    return Ok("Employee deleted.");
        //}

        // Private helper to return standard data
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Alice",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill> {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 5, 1)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bob",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "IT" },
                    Skills = new List<Skill> {
                        new Skill { Id = 3, Name = "Java" },
                        new Skill { Id = 4, Name = "React" }
                    },
                    DateOfBirth = new DateTime(1988, 10, 15)
                }
            };
        }
    }
}
