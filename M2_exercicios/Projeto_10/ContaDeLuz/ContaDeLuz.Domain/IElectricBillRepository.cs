using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContaDeLuz.Domain
{
    public interface IElectricBillRepository
    {
        void AddElectricBill(ElectricBill electricBill);
        void UpdateElectricBill(ElectricBill electricBill);
        void DeleteElectricBill(float readingNumber);
        void PayElectricBill(ElectricBill electricBill, DateTime paymentDate);
        List<ElectricBill> SearchAllElectricBills();
        ElectricBill SearchElectricBillByUniqueDate(int year, int month);
    }
}