using Robot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Robot.Serivces
{
    public interface IRobotService
    {
        public object CallWebAPIAsync();
        public List<RobotData> robots();
    }
}