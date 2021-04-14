using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAdvert.Web.Controllers
{
    public class TesteController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
