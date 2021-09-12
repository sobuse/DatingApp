using API.Data;
using System.Threading.Task;
using Microsoft.AspNetCore.Mvc;
using api.Entities;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context
        public AccountController(DataContext context)
        {

            _context = context;
            
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> register()
    }
}