using System.Collections.Generic;

namespace Robot.Models
{
    public class Survivor: Location
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public char Gender { get; set; }
        public int age { get; set; }
       
        public List<string> list { get; set; }
    }
}
