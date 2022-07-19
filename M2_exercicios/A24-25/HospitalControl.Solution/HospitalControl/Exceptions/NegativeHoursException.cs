namespace HospitalControl.Exceptions
{
    public class NegativeHoursException : SystemException
    {
        public NegativeHoursException(string message) : base(message)
        {
            
        }
    }
}