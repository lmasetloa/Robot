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

        // GET api/<RobotController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RobotController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RobotController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RobotController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
