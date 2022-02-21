using Microsoft.AspNetCore.Mvc;
using Robot.Models;
using Robot.Serivces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddZombiController : ControllerBase
    {
        private readonly IReportZombieService _reportZombieService;
        public AddZombiController(IReportZombieService reportZombieService)
        {
            _reportZombieService = reportZombieService;
        }
    

      

        // PUT api/<AddZombiController>/5
        [HttpPut("{id}")]
        public Results Put(int id, int reportID)
        {
            Results results = new Results();
            results.message = _reportZombieService.reportZombie(reportID, id);
            return results;
        }

       
    }
}
