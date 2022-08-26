using System;

namespace MercadoSeuZe.ClassLib
{
    public class Product
    {
        private long _productId;
        public long ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { _expirationDate = value; }
        }

        private double _unitPrice;
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Product(string name, string description, DateTime expirationDate, double unitPrice, string unit, int quantity)
        {
            Name = name;
            Description = description;
            ExpirationDate = expirationDate;
            UnitPrice = unitPrice;
            Unit = unit;
            Quantity = quantity;
        }

        public Product()
        {

        }

        public void StockIn(int quantity)
        {
            Quantity += quantity;
        }

        public void StockOut(int quantity)
        {
            Quantity -= quantity;
        }

        public override string ToString()
        {
            return $"{ProductId} - {Name} - {Description} - {ExpirationDate.ToShortDateString()} - {UnitPrice} - {Unit} - {Quantity}";
        }
    }
}
