using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class HospitalControl
    {
        private HospitalPayable _hospitalPayable;
        public HospitalPayable HospitalPayable
        {
            get { return _hospitalPayable; }
            set { _hospitalPayable = value; }
        }

        public HospitalControl()
        {
            _hospitalPayable = new HospitalPayable();
        }

        public HospitalControl(HospitalPayable hospitalPayable)
        {
            _hospitalPayable = hospitalPayable;
        }

        public void MakePayments()
        {
            foreach (IReceiver receiver in _hospitalPayable.Receivers)
            {
                int month = DateTime.Now.Month;
                Payments payment = new Payments(month, receiver.CalculatePayment());
                receiver.PaymentList.Add(payment);
                receiver.WorkHours = 0;
            }
        }

        public void InformHours(string identification, int hours)
        {
            if (hours <= 0)
            {
                throw new NegativeHoursException("Horas inválidas, de ser maior que 0!");
            }
            
            var ind = _hospitalPayable.SearchReceiver(identification);
            if (hours > ind.LimitHours)
            {
                throw new LimitHoursException("Limite de horas foi excedido!");
            }
            ind.WorkHours = hours;
        }

        public List<Payments> ShowPayments(string identification)
        {
            var ind = _hospitalPayable.SearchReceiver(identification);
            return ind.PaymentList;
        }
    }
}