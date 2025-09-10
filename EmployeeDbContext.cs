using Microsoft.EntityFrameworkCore;

namespace AspCrud.Models
{
    public class EmployeeDbContext : DbContext
    {
        //create constructor(ctor)
        public EmployeeDbContext(DbContextOptions option ) : base( option ) 
        {
            
        }
        //create dbset (Employee -> In our Program file ; Employees -> db name)
       public DbSet<Employee> Employees { get; set; }
    }
}
