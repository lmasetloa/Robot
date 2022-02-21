using System;
using System.ComponentModel.DataAnnotations;

namespace Robot.Models
{
    public class Robots
    {
        
        public string model { get; set; }
        public string serialNumber { get; set; }
        public DateTime manufacturedDate { get; set; }

        public string category { get; set; }
    }
}
