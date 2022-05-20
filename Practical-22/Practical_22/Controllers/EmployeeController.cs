﻿using BAL_Abstract_Factory;
using Business_access_layer;
using Business_access_layer.Data;
using Business_access_layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Practical_22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly DepartmentFactory departmentFactory;
        private readonly FactoryType factoryType;

        public EmployeeController(ApplicationDbContext context, DepartmentFactory departmentFactory, FactoryType factoryType)
        {
            this.context = context;
            this.departmentFactory = departmentFactory;
            this.factoryType = factoryType;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee emp)
        {
            if (emp.Id == 0)
            {
                await context.Tbl_Employees.AddAsync(emp);
                await context.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Adding Employee");
        }
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int? id)
        {
            if (id == null)
            {
                var result = await context.Tbl_Employees.Include(x => x.Department).ToListAsync();
                await context.SaveChangesAsync();
                return Ok(result);
            }
            else if (id != null)
            {
                var result = await context.Tbl_Employees.Include(x => x.Department).Where(x => x.Id == id).ToListAsync();
                return Ok(result);
            }
            return NotFound("Data Not found");
        }
        [HttpPut("EditEmployee/{id}")]
        public async Task<IActionResult> EditEmployee(int id, [FromBody] Employee emp)
        {
            if (id == emp.Id)
            {
                context.Tbl_Employees.Update(emp);
                await context.SaveChangesAsync();
                return Ok(emp);
            }
            return BadRequest("Error in Updation of Employee");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Tbl_Employees.FindAsync(id);
            if (employee != null)
            {
                employee.emp_status = true;
                context.Tbl_Employees.Update(employee);
                await context.SaveChangesAsync();
                return Ok("Employee Delete Successfully");
            }
            return NotFound("Employee Can not Deleted");
        }
        [HttpGet("OvertimePayFactory")]
        public async Task<ActionResult> OvertimePay(int id, int hour)
        {
            if (id != 0)
            {
                var deptname = await context.Tbl_Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.dept_name).FirstOrDefaultAsync();
                var result = departmentFactory.Getobj(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok("Your OverTime is: "+overtimepay);
            }
            return NotFound("Data Not found");
        }


        [HttpGet("OvertimePayAbstractFactory")]
        public async Task<ActionResult> OvertimePayAbstractFactory(int id, int hour, string factorytype)
        {
            if (id != 0)
            {
                var obj = factoryType.getfactorytype(factorytype);
                var deptname = await context.Tbl_Employees.Include(x => x.Department).Where(x => x.Id == id).Select(x => x.Department.dept_name).FirstOrDefaultAsync();
                var result = obj.GetFactory(deptname);
                var overtimepay = result.MyOverTimePay(hour);
                return Ok("Overtime pay for"+factorytype+" is: " +overtimepay);
            }
            return NotFound("Data Not found");
        }
    }
}
