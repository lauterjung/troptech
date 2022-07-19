using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class Nurse : Member
    {
        public Nurse(string id) : base(id)
        {
            Type = MemberType.Nurse;
            ValueHour = 40m;
            LimitHours = 200;
        }

        public override decimal CalculatePayment()
        {            
            decimal salary = 0;
            
            if (WorkHours < 0)
            {
                throw new NegativeHoursException("O número mínimo de horas é inválido!");
            }
            if (WorkHours > LimitHours)
            {
                throw new LimitHoursException("O número máximo de horas foi ultrapassado!");
            }
            if (WorkHours >= 0 &&  WorkHours <= 180)
            {
                salary = (ValueHour * WorkHours);
            }
            if (WorkHours > 180)
            {
                salary = (ValueHour * 180) + ((WorkHours - 180) * (ValueHour * 2));
            }

            return salary;
        }
    }
}