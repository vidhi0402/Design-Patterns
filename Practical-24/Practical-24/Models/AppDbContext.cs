using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> op ) : base(op)
        {

        }


        public DbSet<Department> Tbl_Departments { get; set; }
        public DbSet<Employee> Tbl_Employees { get; set; }
    }
}
