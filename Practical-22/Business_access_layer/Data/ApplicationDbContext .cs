using Business_access_layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_access_layer.Data
{
    public  class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {

        }

        public DbSet<Department> Tbl_Departments { get; set; }
        public DbSet<Employee> Tbl_Employees { get; set; }
    }
}
