using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequirementForm.Helper;
using RequirementForm.Models;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private readonly ModelContext modelContext;
        private readonly IWebHostEnvironment environment;


        private readonly IMapper mapper;

        public CVController(ModelContext modelContext, IMapper mapper)
        {

            this.modelContext = modelContext;
            this.mapper = mapper;
        }




        [HttpPut("UploadCV")]
        public async Task<IActionResult> DbMultipleUploadImage(IFormFileCollection fileCollection)
        {


            ApiResponse response = new ApiResponse();
            int passcount = 0; int errorCount = 0;

            try
            {
                foreach (var file in fileCollection)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        this.modelContext.Cvtables.Add(new Cvtable()
                        {
                            //Productcode = productCode,
                            Cv = stream.ToArray(),
                            //ImgId=id,
                            //EmpId=emp_id

                        });
                        await this.modelContext.SaveChangesAsync();
                        passcount++;
                    }
                }

            }
            catch (Exception ex)
            {
                errorCount++;
                response.Message = ex.Message;
            }
            response.ResponseCode = 200;
            response.Result = passcount + " File Upload & " + errorCount + "files failed";
            return Ok(response);
        }


        [HttpGet("DownloadPdf")]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            try
            {
                var productImages = await this.modelContext.Cvtables.FirstOrDefaultAsync(i => i.CvId == id);
                if (productImages != null)
                {
                    return File(productImages.Cv, "img/pdf",id + ".pdf");
                }
                else
                {
                    return NotFound();
                }
            }

            catch (Exception ex)
            {
                return NotFound();
            }
        }




















    }
}
