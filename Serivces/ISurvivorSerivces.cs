using Robot.Models;

namespace Robot.Serivces
{
    public interface ISurvivorSerivces
    {
        public string addSurvivors(Survivor survivor);
        public bool updateLocation(string IDnumber, Location location);
    }
}