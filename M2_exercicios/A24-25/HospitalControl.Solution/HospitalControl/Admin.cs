using HospitalControl.Exceptions;

namespace HospitalControl
{
    public class Admin : Member
    {
        public Admin(string id) : base(id)
        {
            Type = MemberType.Admin;
            ValueHour = 110m;
            LimitHours = 200;
        }

        // public override decimal CalculateSalary()
        // {
        //     int extraHour = 0;

        //     if (WorkHours > 180)
        //     {
        //         extraHour = (WorkHours - 180);
        //     }
        //     decimal salary = ValueHour * (WorkHours - extraHour) + ValueHour * 2 * extraHour;
        //                                     // 19800                        // 4400
        //     return salary;
        // }
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
            if (WorkHours > 180)
            {
                salary = (ValueHour * 180) + ((WorkHours - 180) * (ValueHour * 2));
            }

            return salary;
        }


    }
}