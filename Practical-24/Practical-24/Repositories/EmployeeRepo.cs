using Microsoft.EntityFrameworkCore;
using Practical_24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = GetEmployee(id);
            employee.emp_status = false;
            var res = _appDbContext.Update(employee);
            await _appDbContext.SaveChangesAsync();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public Employee GetEmployee(int id)
        {
            return _appDbContext.Tbl_Employees.Where(x => x.Id == id && x.emp_status == true).FirstOrDefault();
            

        }

        public List<Employee> GetAllEmployee()
        {
            return  _appDbContext.Tbl_Employees.Include(x => x.Department).Where(x => x.emp_status == true).ToList();
        }

        public async Task<Employee> PostEmployee(Employee employee)
        {
            var result = await _appDbContext.Tbl_Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _appDbContext.Tbl_Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
