using Robot.Database;
using Robot.Models;
using System.Collections.Generic;

namespace Robot.Serivces
{
    public class ReportingService: IReportingService
    {
        private readonly ISQLQuery _sQLQuery;
        public ReportingService(ISQLQuery sQLQuery)
        {
            _sQLQuery = sQLQuery;
           
        }
        public List<SuviviorViewModel> survivors()
        {
            List<SuviviorViewModel> survivors = new List<SuviviorViewModel>();

            survivors = _sQLQuery.survivors();

            return survivors;
        }
    }
}
