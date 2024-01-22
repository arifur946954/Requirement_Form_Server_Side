/*using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RequirementForm.Models;

namespace RequirementForm.Service
{
    public class EmployeeServiceImp : EmployeeService
  
    {
        private readonly ModelContext modelContext;
        private readonly IMapper mapper;
        public EmployeeServiceImp(ModelContext modelContext, IMapper mapper)
        {
            this.modelContext = modelContext;
            this.mapper = mapper;
        }






        public Employee findByID(int id)
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
               
                // Handle case where employee with given ID is not found

            }

            return employee;

        }
    }

       

        
    
}
*/