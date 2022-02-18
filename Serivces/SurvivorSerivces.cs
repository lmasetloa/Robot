using Robot.Database;
using Robot.Models;
using Robot.Validations;

namespace Robot.Serivces
{
    public class SurvivorSerivces: ISurvivorSerivces
    {


        private readonly ISQLQuery _sQLQuery;
        private readonly IValidation _validation;
        public SurvivorSerivces(ISQLQuery sQLQuery, IValidation validation)
        {
            _sQLQuery = sQLQuery;
            _validation = validation;
        }

        public string addSurvivors(Survivor survivor)
        {
            if (!_validation.validateID(survivor.IDNumber))
                return "Id number should have 13 charactors";
            if (_sQLQuery.findUserByID(survivor.IDNumber))
                return "ID number already exist";
            string results = _sQLQuery.createSurvior(survivor);

            return results;
        }

        public bool updateLocation(string IDnumber, Location location)
        {
            bool update = _sQLQuery.updateLocation(IDnumber,  location);
            return update;
        }
              
    }
}
