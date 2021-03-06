using Robot.Models;
using System.Collections.Generic;

namespace Robot.Serivces
{
    public interface IReportingService
    {
        public List<SuviviorViewModel> survivors();
        public List<SuviviorViewModel> Nonsurvivors();
        public SurvivorsPerc roportPerc();
    }
}