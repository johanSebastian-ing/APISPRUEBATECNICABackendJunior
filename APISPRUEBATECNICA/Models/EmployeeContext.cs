using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APISPRUEBATECNICA.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
         
    public DbSet<Employee> tblEmployee { get; set; }
    }
}
