namespace HospitalControl
{
    public interface IReceiver
    {
        string Id { get; set; }
        public decimal CalculatePayment();
    }
}