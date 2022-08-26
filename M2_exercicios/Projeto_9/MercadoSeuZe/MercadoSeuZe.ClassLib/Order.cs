using System;
using MercadoSeuZe.ClassLib.Exceptions;

namespace MercadoSeuZe.ClassLib
{
    public class Order
    {
        private ClientDAO _clientDAO = new ClientDAO();
        private ProductDAO _productDAO = new ProductDAO();

        private long _orderId;
        public long OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; }
        }

        private TimeSpan _orderTime;
        public TimeSpan OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        private Product _orderProduct;
        public Product OrderProduct
        {
            get { return _orderProduct; }
            set { _orderProduct = value; }
        }

        private int _productQuantity;
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set { _productQuantity = value; }
        }

        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        private double _fidelityPoints;
        public double FidelityPoints
        {
            get { return _totalPrice * 2; }
        }

        private Client _client;
        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Order(Product orderProduct, int productQuantity, Client client)
        {
            if (productQuantity <= 0)
            {
                throw new ZeroOrNegativeQuantityException();
            }

            OrderDate = DateTime.Now;
            OrderTime = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            OrderProduct = orderProduct;
            ProductQuantity = productQuantity;
            Client = client;

            TotalPrice = CalculateTotalPrice();
        }

        public Order()
        {
            Client = new Client();
            OrderProduct = new Product();
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = OrderProduct.UnitPrice * ProductQuantity;
            return totalPrice;
        }

        public override string ToString()
        {
            return $"{OrderId} - {OrderProduct.Name} - {OrderProduct.Description} - {ProductQuantity} - {TotalPrice} - {Client.Name} - {OrderDate.ToShortDateString()} - {OrderTime}";
        }
    }
}
