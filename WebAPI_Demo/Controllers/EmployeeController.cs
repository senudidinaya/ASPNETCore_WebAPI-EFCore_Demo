using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        // GET API
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeContext.Employees.ToListAsync();
            if (employees == null || employees.Count == 0)
            {
                return NotFound("No employees found");
            }

            return Ok(employees);
        }

        // GET by ID API
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            return Ok(employee);
        }

        // POST API
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data");
            }

            try
            {
                _employeeContext.Employees.Add(employee);
                await _employeeContext.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = employee.Id }, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // PUT API
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee updatedEmployee)
        {
            var existingEmployee = await _employeeContext.Employees.FindAsync(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            existingEmployee.First_Name = updatedEmployee.First_Name;
            existingEmployee.Last_Name = updatedEmployee.Last_Name;
            existingEmployee.Department = updatedEmployee.Department;

            try
            {
                await _employeeContext.SaveChangesAsync();
                return Ok(existingEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // DELETE API
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found");
            }

            try
            {
                _employeeContext.Employees.Remove(employee);
                await _employeeContext.SaveChangesAsync();
                return Ok($"Employee with ID {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
