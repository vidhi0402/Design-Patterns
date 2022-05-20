using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Data
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
