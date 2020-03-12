using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliceHook.Controllers
{
    [Route("/")]
    [ApiController]
    public class MyController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "It Worked!";
        }
    }
}