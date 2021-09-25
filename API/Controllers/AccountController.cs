using API.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using System.Security.Cryptography;
using System.Text;
using API.DTOs;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
       private readonly DataContext _context;
        public AccountController(DataContext context)
        {

            _context = context;
            
        }
       

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username))return BadRequest("Username has been taken");
	{

	}

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = RegisterDto.Username,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(RegisterDto.password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private async Task<bool> UserExist(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());

        }
    }
}