using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using Database.Utility;
using Database.Services;

namespace Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly OfficeContext _context;
        private IEmployeesRepostiory _employeesRepostiory;

        public EmployeesController(OfficeContext context, IEmployeesRepostiory employeesRepostiory)
        {
            _context = context;
            _employeesRepostiory = employeesRepostiory;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEmployee>>> GetEmployees()
        {
            return  Ok(await _employeesRepostiory.GetEmployeesAsync());
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEmployee>> GetEmployee(Guid id)
        {
            var employee = await _employeesRepostiory.GetEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, IEmployee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }          

            try
            {
                await _employeesRepostiory.PutEmployeeAsync(id, employee);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<IEmployee>> PostEmployee(IEmployee employee)
        {
            await _employeesRepostiory.PostEmployeeAsync(employee);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEmployee>> DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _employeesRepostiory.DeleteEmployeeAsync(id);
                return Ok(employee);
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
