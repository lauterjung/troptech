using System;
using System.Collections.Generic;
using ContaDeLuz.Domain;
using ContaDeLuz.Domain.Exceptions;
using ContaDeLuz.Infra.Data.DAO;

namespace ContaDeLuz.Infra.Data
{
    public class ElectricBillRepository : IElectricBillRepository
    {
        private ElectricBillDAO _electricBillDAO = new ElectricBillDAO();
        public void AddElectricBill(ElectricBill electricBill)
        {
            ElectricBill searchedElectricBill = _electricBillDAO.SearchElectricBillByUniqueDate(electricBill.Year, electricBill.Month);

            if (searchedElectricBill is not null)
            {
                throw new ExistingElectricBill();
            }

            _electricBillDAO.AddElectricBill(electricBill);
        }

        public void DeleteElectricBill(float readingNumber)
        {
            ElectricBill electricBill = _electricBillDAO.SearchElectricBillByReadingNumber(readingNumber);
            _electricBillDAO.DeleteElectricBill(electricBill);
        }

        public void PayElectricBill(ElectricBill electricBill, DateTime paymentDate)
        {
            ElectricBill searchedElectricBill = _electricBillDAO.SearchElectricBillByUniqueDate(electricBill.Year, electricBill.Month);

            searchedElectricBill.Pay(paymentDate);

            _electricBillDAO.UpdateElectricBill(searchedElectricBill);
        }

        public List<ElectricBill> SearchAllElectricBills()
        {
            List<ElectricBill> electricBillList = _electricBillDAO.SearchAllElectricBills();

            if (electricBillList.Count == 0)
            {
                throw new ZeroElectricBillsRegistered();
            }

            return electricBillList;
        }

        public ElectricBill SearchElectricBillByReadingNumber(float readingNumber)
        {
            ElectricBill electricBill = _electricBillDAO.SearchElectricBillByReadingNumber(readingNumber);

            if (electricBill is null)
            {
                throw new ElectricBillNotFound();
            }

            return electricBill;
        }

        public ElectricBill SearchElectricBillByUniqueDate(int year, int month)
        {
            ElectricBill electricBill = _electricBillDAO.SearchElectricBillByUniqueDate(year, month);

            if (electricBill is null)
            {
                throw new ElectricBillNotFound();
            }

            return electricBill;
        }

        public void UpdateElectricBill(ElectricBill electricBill)
        {
            _electricBillDAO.UpdateElectricBill(electricBill);
        }
    }
}