using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Robot.Models
{
    public class SuviviorViewModel:Location
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IDNumber { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public int age { get; set; }

        public List<string> list { get; set; } = new List<string>();
    }
}
