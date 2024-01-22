using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequirementForm.Models;
using System;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ModelContext modelContext;
        private readonly IMapper mapper;
        public AdminController(ModelContext modelContext, IMapper mapper)
        {
            this.modelContext = modelContext;
            this.mapper = mapper;
        }

       
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





    }
}
