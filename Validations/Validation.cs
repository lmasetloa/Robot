using Serilog;
using System;

namespace Robot.Validations
{
    public class Validation:IValidation
    {
        public bool validateID(string ID)
        {
            try 
            {
                if (ID.Length == 13)
                    return true;
            }catch(Exception ex)
            {
                Log.Error($"error in checking the ID lenght {ex.Message}");
            }
            
            return false;
        }

        public bool vadilateReporter(int repID,int zomID)
        {
            if(repID != zomID)
                return true;
            return false;
        }
    }
}
