namespace HospitalControl.Exceptions
{
    public class InvalidPaymentException : SystemException
    {
        public InvalidPaymentException(string message) : base(message)
        {
            
        }
    }
}