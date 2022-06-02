using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IConfiguration Configuration;

        private readonly EmployeeManagementDbContext employeeManagementDbContext;


        public AuthenticateController(IConfiguration configuration, EmployeeManagementDbContext context)
        {
            Configuration = configuration;
            employeeManagementDbContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User userData)
        {
            if (userData.Email != null && userData.Password != null)
            {
                var user = await GetUser(userData.Email, userData.Password);
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, Configuration["JWT:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, DateTime.UtcNow.ToString()),
                        new Claim("EmployeeId", user.EmployeeId.ToString()),
                        new Claim("Email", user.Email.ToString()),
                        new Claim("Role", user.Role.ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(Configuration["Jwt:Issuer"], Configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    string[] arr = { new JwtSecurityTokenHandler().WriteToken(token), user.EmployeeId.ToString(), user.Email.ToString(), user.Role.ToString() };
                    return Ok(arr);
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await employeeManagementDbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
