using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Models;

namespace User.API.Controllers
{
    public class BaseController:Controller
    {
        protected UserIdentity Identity = new UserIdentity { Id = 1, Name = "lic" };
    }
}
