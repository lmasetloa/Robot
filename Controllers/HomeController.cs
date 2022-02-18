using Microsoft.AspNetCore.Mvc;
using Robot.Models;
using Robot.Serivces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISurvivorSerivces _SurvivorSerivces1;

        public HomeController(ISurvivorSerivces SurvivorSerivces)
        {
            _SurvivorSerivces1 = SurvivorSerivces;
        }

        //// GET: api/<HomeController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<HomeController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<HomeController>
        [HttpPost]
        public string Post(Survivor survivor)
        {           
           string results = _SurvivorSerivces1.addSurvivors(survivor);

            return results; 
        }

        // PUT api/<HomeController>/5
        [HttpPut("{idnumber}")]
        public string Put(string id, Location location)
        {
           bool update = _SurvivorSerivces1.updateLocation(id, location);
            if (update)
            {
                return "Location has been updated";
            }
            return "Location not updated";
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
