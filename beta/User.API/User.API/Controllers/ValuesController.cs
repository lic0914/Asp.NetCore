using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.API.Data;

namespace User.API.Controllers
{
    [Route("api/[controller]")]

    public class ValuesController : Controller
    {
        private readonly UserContext _userContext;
        public ValuesController(UserContext userContext)
        {
            _userContext = userContext;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var u= await _userContext.AppUser.SingleOrDefaultAsync(e => e.Name == "lic");
            return Json(u);
        }
        
    }
}
