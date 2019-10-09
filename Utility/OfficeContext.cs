using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Utility
{
    public class OfficeContext : DbContext
    {
        public OfficeContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> managers { get; set; }
    }
}

