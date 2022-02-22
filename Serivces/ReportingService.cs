using Robot.Database;
using Robot.Models;
using Robot.Tools;
using Serilog;
using System;
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
        public List<SuviviorViewModel> Nonsurvivors()
        {
            List<SuviviorViewModel> survivors = new List<SuviviorViewModel>();

            survivors = _sQLQuery.Nonsurvivors();

            return survivors;
        }
        public SurvivorsPerc roportPerc()
        {
            double NonSurvivor = 0.00;
            try 
            {
                Report report = _sQLQuery.SurvivorCount();
                SurvivorsPerc survivorsPerc = new SurvivorsPerc()
                {
                    NonSurvivorPerc = String.Format("Value: {0:P2}.",( (double)report.AllNonSurvivor / (double)report.Allpeople)),
                    SurvivorPerc = String.Format("Value: {0:P2}.", ((double)report.AllSurvivor / (double)report.Allpeople))

                };
                return survivorsPerc;
            }catch(Exception ex)
            {
                Log.Error($" {ex}");
                return null;
            }
           

        }

    }
}
