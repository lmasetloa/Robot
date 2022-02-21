using Robot.Database;
using Robot.Models;
using Robot.Validations;

namespace Robot.Serivces
{
    public class ReportZombieService: IReportZombieService
    {
        private readonly ISQLQuery _sQLQuery;
        private readonly IValidation _validation;
        public ReportZombieService(ISQLQuery sQLQuery, IValidation validation)
        {
            _sQLQuery = sQLQuery;
            _validation = validation;
        }

        public string reportZombie(int RepID, int ZomID)
        {
            if (!_validation.vadilateReporter(RepID, ZomID))
                return "A person can't report them selve";
 
            return _sQLQuery.AddZombi(RepID, ZomID);
        }
    }
}
