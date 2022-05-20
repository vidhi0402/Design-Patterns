using Data_Access_Layer.DataContext;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
   public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext context;

        public CommandRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(Employee emp)
        {
            if (emp.Id == 0)
            {
                await context.Tbl_Employees.AddAsync(emp);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
      
        public async Task Edit(Employee emp)
        {
            context.Tbl_Employees.Update(emp);
            await context.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var employee = await context.Tbl_Employees.FindAsync(id);
            if (employee != null)
            {
                employee.emp_status = true;
                context.Tbl_Employees.Update(employee);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
