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
    public class ManagersController : ControllerBase
    {
        private readonly OfficeContext _context;
        private IEmployeesRepostiory _employeesRepostiory;

        public ManagersController(OfficeContext context, IEmployeesRepostiory employeesRepostiory)
        {
            _context = context;
            _employeesRepostiory = employeesRepostiory;
        }
        // GET: api/Managers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manager>>> Getmanager()
        {
            return Ok(await _employeesRepostiory.GetEmployeesAsync());
        }

        // GET: api/Managers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manager>> GetManager(Guid id)
        {
            var manager = await _employeesRepostiory.GetEmployeeAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        // PUT: api/Managers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManager(Guid id, IEmployee employee)
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

        // POST: api/Managers
        [HttpPost]
        public async Task<ActionResult<Manager>> PostManager(IEmployee employee)
        {
            await _employeesRepostiory.PostEmployeeAsync(employee);
            return CreatedAtAction("GetManager", new { id = employee.Id }, employee);
        }

        // DELETE: api/Managers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manager>> DeleteManager(Guid id)
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

        private bool ManagerExists(Guid id)
        {
            return _context.managers.Any(e => e.Id == id);
        }
    }
}
