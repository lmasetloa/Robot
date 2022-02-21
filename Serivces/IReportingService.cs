using Robot.Models;
using System.Collections.Generic;

namespace Robot.Serivces
{
    public interface IReportingService
    {
        public List<SuviviorViewModel> survivors();
    }
}