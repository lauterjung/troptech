using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class Payments
    {
        private int _month;
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }
        private decimal _payment;
        public decimal Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        public Payments(int month, decimal payment)
        {
            if (month <= 0 || month > 12)
            {
                throw new InvalidMonthException("Mês inválido! Deve estar entre 1 e 12!");
            }

            if (payment < 0)
            {
                throw new InvalidPaymentException("Pagamento inválido! Deve ser maior que zero!");
            }

            _month = month;
            _payment = payment;
        }

        public override string ToString()
        {
            return ($"Mês: {_month}    Valor Pago: {_payment}");
        }
    }
}