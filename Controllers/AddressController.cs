using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequirementForm.Models;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ModelContext modelContext;
        private readonly IMapper mapper;

        public AddressController(ModelContext modelContext, IMapper mapper)
        {
            this.modelContext = modelContext;
            this.mapper = mapper;

        }


        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var allData = modelContext.Divisions
           //retrive all  address
           .Include(e => e.Districts)
             .ThenInclude(e => e.Thanas)
           .ToList();
            return Ok(allData);

        }
        //git division by id
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult FindAddressByID(int id)
        {


            var address = modelContext.Divisions
                     .Include(e => e.Districts)
                    .ThenInclude(e => e.Thanas)
                 
                  .FirstOrDefault(e => e.DivId == id);

            if (address != null)
            {
                return Ok(address);
                // Handle case where employee with given ID is not found

            }
            return NotFound();}

        //get division by name

        [HttpGet]
        [Route("{name}")]
        public IActionResult FindAddressByName(string name)
        {


            var address = modelContext.Divisions
                     .Include(e => e.Districts)
                    .ThenInclude(e => e.Thanas)

                  .FirstOrDefault(e => e.Name == name);

            if (address != null)
            {
                return Ok(address);
                // Handle case where employee with given ID is not found

            }
            return NotFound();
        }


        //get district by name
        [HttpGet]
        [Route("{name}/{names}")]
        public IActionResult FindDistrictByName(string name,string names)
        {


            var address = modelContext.Divisions
                     .Include(e => e.Districts)
                    .ThenInclude(f => f.Thanas)

                  .FirstOrDefault(e => e.Name == name);

            if (address != null)
            {
                var district = address.Districts.FirstOrDefault(d => d.Name == names);

                if (district != null)
                {
                    return Ok(district);
                }
            }
            return NotFound();
        }

        //git district

        [HttpGet]
        [Route("{id:int}/districts")]

        public async Task<IActionResult> GetDistrict()
        {
            var allData = modelContext.Districts
           //retrive all  address
           .Include(e => e.Thanas)
            
           .ToList();
            return Ok(allData);

        }
        //find district by one

        [HttpGet]
        [Route("{id:int}/districts/{distId:int}")]


        public async Task<IActionResult> GetDistrictByOne(int id, int distId)
        {
            var address = modelContext.Districts
                   .Include(e => e.Thanas)


                 .FirstOrDefault(e => e.DivId == id && e.DisId== distId);

            if (address != null)
            {
                return Ok(address);
                // Handle case where employee with given ID is not found

            }
            return NotFound();

        }

        //find add District only
        //


        [HttpGet("Dis")]
       // [Route("dis/{district}")]
        public IActionResult FindDistrictByName(string name)
        {


            var address = modelContext.Districts
                     .Include(e => e.Thanas)
                    /*.ThenInclude(e => e.Thanas)*/

                  .FirstOrDefault(e => e.Name == name);

            if (address != null)
            {
                return Ok(address);
                // Handle case where employee with given ID is not found

            }
            return NotFound();
        }










    }








}
