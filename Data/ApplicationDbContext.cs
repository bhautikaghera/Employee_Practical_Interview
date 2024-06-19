using EmployeeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Employee> employees { get; set; }
    }
}
