namespace HospitalControl
{
    public class Member : IReceiver
    {
        protected MemberType type;
        public MemberType Type
        {
            get { return type; }
            set { type = value; }
        }

        protected decimal valueHour;
        public decimal ValueHour
        {
            get { return valueHour; }
            protected set { valueHour = value; }
        }

        protected int workHours;
        public int WorkHours
        {
            get { return workHours; }
            set { workHours = value; }
        }

        protected string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected int limitHours;
        public int LimitHours
        {
            get { return limitHours; }
            set { limitHours = value; }
        }

        protected List<Payments> paymentList;
        public List<Payments> PaymentList
        {
            get { return paymentList; }
            set { paymentList = value; }
        }

        public Member(string id)
        {
            _id = id;
            paymentList = new List<Payments>();
        }

        public virtual decimal CalculatePayment()
        {
            return 0m;
        }
    }
}