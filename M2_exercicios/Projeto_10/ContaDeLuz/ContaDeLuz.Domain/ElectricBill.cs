using System;
using ContaDeLuz.Domain.Exceptions;

namespace ContaDeLuz.Domain
{
    public class ElectricBill
    {
        public float ReadingNumber { get; set; }
        public DateTime ReadingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double ConsumedKw { get; set; }
        public double BillValue { get; set; }
        public double AverageConsumption { get; set; }
        public int Month
        {
            get { return ReadingDate.Month; }
        }
        public int Year
        {
            get { return ReadingDate.Year; }
        }
        public bool IsPaid 
        { 
            get { return (PaymentDate != null); }
        }

        public ElectricBill(float readingNumber, DateTime readingDate, DateTime? paymentDate, double consumedKw, double billValue, double averageConsumption)
        {
            ReadingNumber = readingNumber;
            ReadingDate = readingDate;
            PaymentDate = paymentDate;
            ConsumedKw = consumedKw;
            BillValue = billValue;
            AverageConsumption = averageConsumption;
        }

        public ElectricBill()
        {
            
        }

        public void Pay(DateTime paymentDate)
        {
            if (PaymentDate is not null)
            {
                throw new ElectricBillAlreadyPaid();
            }
            PaymentDate = paymentDate;
        }

        public override string ToString()
        {
            return $"{ReadingNumber} - Consumo: {String.Format("{0:0.00}", ConsumedKw)} - R$ {String.Format("{0:0.00}", BillValue)} - Consumo médio: {String.Format("{0:0.00}", AverageConsumption)} - Data Leitura: {ReadingDate.ToShortDateString()} - Data Pagamento: {PaymentDate?.ToShortDateString()}";
        }
    }
}
