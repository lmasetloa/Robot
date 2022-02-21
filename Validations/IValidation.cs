namespace Robot.Validations
{
    public interface IValidation
    {
        public bool validateID(string ID);
        public bool vadilateReporter(int repID, int zomID);
    }
}