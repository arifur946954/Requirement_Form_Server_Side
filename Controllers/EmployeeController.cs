using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using RequirementForm.DTO;
using RequirementForm.Models;

using System;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ModelContext modelContext;
        private readonly IMapper mapper;
        
        public EmployeeController(ModelContext modelContext, IMapper mapper)
        {
            this.modelContext = modelContext;
            this.mapper = mapper;
           
        }

        [HttpPost]
        public async Task<IActionResult> PostAllCustomer(Employee tempEmployee)

        {
            //var newEmployee = mapper.Map<Employee>(tempEmployee);
            var empl = await modelContext.Employees.FirstOrDefaultAsync
             (x => x.Mobilenumber == tempEmployee.Mobilenumber);
            if (empl != null)
            {
                return BadRequest(new { message = "Number is allready exist" });
            }
            modelContext.Employees.Add(tempEmployee);
            await modelContext.SaveChangesAsync();
            
            return Ok((tempEmployee,new{}));
            
        }
        //get all

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var allData = modelContext.Employees
           //retrive all  address
           .Include(e => e.Presentaddresses)
             .Include(e => e.Parmanentaddresses)

            //retrive all Accademic Qualification
            .Include(e => e.Accademicqulifications)
           //Retrive all Exprience
           .Include(e => e.Experiences)
           .ToList();
            return Ok(allData);

        }



        [HttpGet]
        [Route("{id:int}")]
        public IActionResult FindEmployeeByID(int id)
        {


            var employee = modelContext.Employees
                     .Include(e => e.Presentaddresses)
                    .Include(e => e.Parmanentaddresses)
                 //retrive all Accademic Qualification
                 .Include(e => e.Accademicqulifications)
                   .Include(e => e.Experiences)
                  .FirstOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                return Ok(employee);
                // Handle case where employee with given ID is not found

            }
            return NotFound();


        }

        //get by mail
        [HttpGet]
        [Route("{mail}")]
        public IActionResult FindEmployeeByEmail(string mail)
        {


            var employee = modelContext.Employees
                     .Include(e => e.Presentaddresses)
                    .Include(e => e.Parmanentaddresses)
                 //retrive all Accademic Qualification
                 .Include(e => e.Accademicqulifications)
                   .Include(e => e.Experiences)
                  .FirstOrDefault(e => e.Email == mail);

            if (employee != null)
            {
                return Ok(employee);
                // Handle case where employee with given ID is not found

            }
            return NotFound();


        }





        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = modelContext.Employees
                     .Include(e => e.Presentaddresses)
           .Include(e => e.Parmanentaddresses)
         //retrive all Accademic Qualification
         .Include(e => e.Accademicqulifications)
        //Retrive all Exprience
        .Include(e => e.Experiences)
            .FirstOrDefault(e => e.EmployeeId == id);
            // Remove the employee from the database
            if (employee != null)
            {
                modelContext.Employees.Remove(employee);
                modelContext.SaveChanges();

                return Ok(employee);
            }
            return NotFound();

        }

        //update
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee([FromBody] Employee tempEmployee, decimal id)
        {
            var result = modelContext.Employees.Find(id);
            var employee = modelContext.Employees
                    .Include(e => e.Presentaddresses)
              .Include(e => e.Parmanentaddresses)
        //retrive all Accademic Qualification
        .Include(e => e.Accademicqulifications)

       //Retrive all Exprience
       .Include(e => e.Experiences)

           .FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }
           
            employee.Mobilenumber = tempEmployee.Name;
            employee.Name = tempEmployee.Name;
            employee.Fathername = tempEmployee.Fathername;
            employee.Mothername = tempEmployee.Mothername;
            employee.Nid = tempEmployee.Nid;
            employee.Dateofbirthd = tempEmployee.Dateofbirthd;
            employee.Birthplace = tempEmployee.Birthplace;
            employee.Religion = tempEmployee.Religion;
            employee.Bloodgroup = tempEmployee.Bloodgroup;
            employee.Gender = tempEmployee.Gender;

            employee.Maritalstatus = tempEmployee.Maritalstatus;
            employee.Spousename = tempEmployee.Spousename;
            employee.Email = tempEmployee.Email;
            employee.Interviewdate = tempEmployee.Interviewdate;
            employee.Appliedpost = tempEmployee.Appliedpost;
            employee.Probablyjoiningdate = tempEmployee.Probablyjoiningdate;
            employee.Expectedselery = tempEmployee.Expectedselery;
            employee.Appliedby = tempEmployee.Appliedby;

            employee.Accademicqulifications = tempEmployee.Accademicqulifications;
            employee.Experiences = tempEmployee.Experiences;
            employee.Parmanentaddresses = tempEmployee.Parmanentaddresses;
            employee.Presentaddresses = tempEmployee.Presentaddresses;

            //mapper.Map( tempEmployee, employee);

            modelContext.SaveChanges();
            return Ok(employee);


            /* var newEmployee = mapper.Map<Employee>(tempCustommer);
             modelContext.Employees.Update(newEmployee);
             modelContext.SaveChanges();*/
            //return Ok(newEmployee);

        }














    }
}
