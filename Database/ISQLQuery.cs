using Robot.Models;
using System.Collections.Generic;

namespace Robot.Database
{
    public interface ISQLQuery
    {
        public bool findUserByID(string ID);
        public string createSurvior(Survivor survivor);
        public bool updateLocation(int Id, Location location);
        public string AddZombi(int ReporterID, int newZombiID);
        public List<SuviviorViewModel> survivors();
        public List<SuviviorViewModel> Nonsurvivors();
        public Report SurvivorCount();
    }
}
