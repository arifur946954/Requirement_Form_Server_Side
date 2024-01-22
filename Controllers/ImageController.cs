using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RequirementForm.Helper;
using RequirementForm.Models;
using System;
using System.DirectoryServices.Protocols;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ModelContext modelContext;
        private readonly IWebHostEnvironment environment;


        private readonly IMapper mapper;

        public ImageController( ModelContext modelContext, IMapper mapper)
        {
            
            this.modelContext = modelContext;
            this.mapper = mapper;
        }



        [HttpPost("DBUploadImages")]
        public async Task<IActionResult> DbMultipleUploadImage(IFormFileCollection fileCollection,string productCode)
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
                        this.modelContext.Imagetbls.Add(new Imagetbl()
                        {
                            Name = productCode,
                            Image = stream.ToArray(),
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

        [HttpGet("GetDBMultiImages")]
        public async Task<IActionResult> getDbMultiImage(int id)
        {
            List<string> ImageUrl = new List<string>();

            try
            {
                var productImge = this.modelContext.Imagetbls.Where(i => i.ImgId == id).ToList();
                if (productImge != null && productImge.Count > 0)
                {
                    productImge.ForEach(i => { ImageUrl.Add(Convert.ToBase64String(i.Image)); });
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

            }
            return Ok(ImageUrl);
        }



        [HttpGet("DbDownloadImages")]
        public async Task<IActionResult> DownloadImages(string id)
        {
            try
            {
                var productImages = await this.modelContext.Imagetbls.FirstOrDefaultAsync(i => i.Name == id);
                if (productImages != null)
                {
                    return File(productImages.Image, "img/png", id + ".png");
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

        //db retrive image
        [HttpGet("DbDownloadImages/{id}")]
        public async Task<IActionResult> RetriveImage(string id)
        {
            try
            {
                var image = await this.modelContext.Imagetbls.FirstOrDefaultAsync(i => i.Name == id);

                if (image != null)
                {
                    return File(image.Image, "image/png");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }














    }
}
