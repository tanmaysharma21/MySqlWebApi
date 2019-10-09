using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace Database.Services
{
    public interface IEmployeesRepostiory
    {
        Task<IEnumerable<IEmployee>> GetEmployeesAsync();
        Task<IEmployee> GetEmployeeAsync(Guid id);
        Task PutEmployeeAsync(Guid id, IEmployee employee);
        Task PostEmployeeAsync(IEmployee employee);
        Task<IEmployee> DeleteEmployeeAsync(Guid id);
        bool EmployeeExists(Guid id);

    }
}