using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class Hired : IReceiver
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }       
        

         public decimal CalculatePayment()
         {

            if (Amount <= 0)
            {
                throw new NegativeHoursException("A quantidade de serviço deve ser maior que 0!");
            }
            if (UnitPrice <= 0)
            {
                throw new InvalidValueException("O valor do serviço deve ser maior que 0!");
            }
            decimal totalPayment = UnitPrice * Amount;
            return totalPayment;
         }        
    }
}