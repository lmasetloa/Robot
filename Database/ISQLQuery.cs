using Robot.Models;

namespace Robot.Database
{
    public interface ISQLQuery
    {
        public bool findUserByID(string ID);
        public string createSurvior(Survivor survivor);
        public bool updateLocation(string Id, Location location);
    }
}
