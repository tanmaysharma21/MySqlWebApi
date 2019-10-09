using Database.Models;
using Database.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Services
{
    public class ManagerRepository : IEmployeesRepostiory
    {
        private OfficeContext _context;


        public ManagerRepository(OfficeContext officeContext)
        {
            _context = officeContext;
        }

        public async Task<IEmployee> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public bool EmployeeExists(Guid id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        public  async Task<IEmployee> GetEmployeeAsync(Guid id)
        {

            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<IEmployee>> GetEmployeesAsync()
        {
            return await _context.managers.ToListAsync();
        }

        public async Task PostEmployeeAsync(IEmployee employee)
        {
            _context.managers.Add((Manager)employee);
            await _context.SaveChangesAsync();
        }

        public async Task PutEmployeeAsync(Guid id, IEmployee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    throw new KeyNotFoundException();
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
