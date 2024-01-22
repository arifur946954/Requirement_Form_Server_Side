using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RequirementForm.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RequirementForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ModelContext modelContext;
        //private readonly IMapper mapper;
        public RegisterController(ModelContext modelContext)
        {
            this.modelContext = modelContext;
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var length = register.Mobilenumber.Length;
            if (register.Mobilenumber == null)
            {
                return BadRequest();
            }

            else if (length != 11)
            {
                return BadRequest(new { message = "Mobile number must contain be 11 digit" });
            }
            else if (await modelContext.Registers.AnyAsync(u => u.Mobilenumber == register.Mobilenumber))
            {
                return BadRequest( new { message= "Mobile Number is Already Exist Please try another Number" });
            }
             else if (await modelContext.Registers.AnyAsync(u => u.Email == register.Email))
            {
                return BadRequest(new { message = "Email is Already Exist please try another Email" });
            }
            register.Role = "User";
            register.Token = "";
         
            await modelContext.Registers.AddAsync(register);
            await modelContext.SaveChangesAsync();
            return Ok(new { message = "Register successdfull" });
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Authentication([FromBody] Register register)
        {
           
            if (register == null)
            {

                return BadRequest(new { message = "Please provide mail and password" });

            }
           
            var empl = await modelContext.Registers.FirstOrDefaultAsync
                (x => x.Email == register.Email && x.Password == register.Password);

            /* var empl = await appDBContext.registers.FirstOrDefaultAsync
                 (x => logis.Email == register.Email && logis.password == register.password);*/



            if (empl == null)
            {
                return BadRequest(new { message = "Email or password incorrect" });
            }


            register.Token = CreateJwt(register);

            //await modelContext.SaveChangesAsync();

                 return Ok(new


              { 
                  token=register.Token,
                  message = "Login Successfull"
                  
              }

              );
       
           

        }
       
        private string CreateJwt(Register user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                //new Claim(ClaimTypes.Role, user.Role),
                // new Claim(ClaimTypes.Email,$"{user.Email}"),
            


                new Claim(ClaimTypes.Email,user.Email),
                
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
               // Expires = DateTime.Now.AddSeconds(10),
                Expires=DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Register>> getAllUser()
        {
            return Ok(await modelContext.Registers.ToListAsync());
        }






    }
}
