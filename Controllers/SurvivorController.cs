using Microsoft.AspNetCore.Mvc;
using Robot.Models;
using Robot.Serivces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorController : ControllerBase
    {
        private readonly ISurvivorSerivces _SurvivorSerivces1;

        public SurvivorController(ISurvivorSerivces SurvivorSerivces)
        {
            _SurvivorSerivces1 = SurvivorSerivces;
        }

        [HttpPost]
        public string Post(Survivor survivor)
        {           
           string results = _SurvivorSerivces1.addSurvivors(survivor);

            return results; 
        }

        // PUT api/<HomeController>/5
        [HttpPut("{Id}")]
        public string Put(string id, Location location)
        {
           bool update = _SurvivorSerivces1.updateLocation(id, location);
            if (update)
            {
                return "Location has been updated";
            }
            return "Location not updated";
        }

    }
}
