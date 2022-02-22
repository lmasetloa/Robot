using Microsoft.AspNetCore.Mvc;
using Robot.Models;
using Robot.Serivces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _robotService;

        public RobotController(IRobotService robotService)
        {
            _robotService = robotService;
        }
        // GET: api/<RobotController>
        [HttpGet]
        public object Get()
        {          
            return _robotService.CallWebAPIAsync();
        }

       
    }
}
