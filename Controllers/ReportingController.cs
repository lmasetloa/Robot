using Microsoft.AspNetCore.Mvc;
using Robot.Models;
using Robot.Serivces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Robot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IRobotService _robotService;
        private readonly IReportingService _reportingService;




        public ReportingController(IRobotService robotService,IReportingService reportingService)
        {
            _robotService = robotService;
            _reportingService = reportingService;
        }
        // GET: api/<ReportingController>
        [HttpGet]
        public object AllRebots()
        {
            return _robotService.CallWebAPIAsync();
        }
        [HttpGet]
        public List<SuviviorViewModel> AllSurvivors()
        {
            return _reportingService.survivors();
        }

        [HttpGet]
        public List<SuviviorViewModel> AllNonSurvivors()
        {
            return _reportingService.Nonsurvivors();
        }

        // GET api/<ReportingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReportingController>
      
    }
}
