using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class Medic : Member
    {
        public Medic(string id) : base(id)
        {
            Type = MemberType.Medic;
            ValueHour = 300m;
            LimitHours = 300;
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
            if (WorkHours >= 0 && WorkHours <= 180)
            {
                salary = (ValueHour * WorkHours);
            }
            if (WorkHours > 180 && WorkHours <= 250)
            {
                salary = (ValueHour * 180) + ((WorkHours - 180) * (ValueHour * 2));
            }
            if (WorkHours > 250)
            {
                salary = (ValueHour * 180) + ((WorkHours - 230) * (ValueHour * 2)) + ((WorkHours - 250) * (ValueHour * 3));
            }
            
            return salary;
        }
    }
}