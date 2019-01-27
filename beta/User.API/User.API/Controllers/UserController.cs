using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using User.API.Data;

namespace User.API.Controllers
{
    [Route("api/[controller]")]

    public class UserController : BaseController
    {
        private readonly UserContext _userContext;
        private readonly ILogger<UserController> _logger;
        public UserController(UserContext userContext,ILogger<UserController> logger)
        {
            _logger = logger;
            _userContext = userContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var u= await _userContext.AppUser.SingleOrDefaultAsync(e => e.Name == "lic");
            return Json(u);
        }
        public async Task<IActionResult> Patch([FromBody] JsonPatchDocument<Models.AppUser> patch)
        {
            var user = await _userContext.AppUser
                .SingleOrDefaultAsync(u => u.Id == Identity.Id);
            patch.ApplyTo(user);

            _userContext.SaveChanges();
            return Json(user);

        }
        
    }
}
