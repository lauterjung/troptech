using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A
{
    public class OrderRepository
    {
// using System;
// using System.Collections.Generic;
// using TropPizza.Domain.Exceptions;
// using TropPizza.Domain.Features.Orders;
// using TropPizza.Infra.Data.DAO;

// namespace TropPizza.Infra.Data.Repositories
// {
//     public class OrderRepository : IOrderRepository
//     {
//         private OrderDAO _orderDAO = new OrderDAO();

//         public void Create(Order order)
//         {
//             Order searchedOrder = _orderDAO.ReadById(order.Id);
//             if (searchedOrder != null)
//             {
//                 throw new AlreadyExists();
//             }

//             if (order.Validate())
//             {
//                 _orderDAO.Create(order);
//             }
//         }

//         public Order ReadById(Int64 id)
//         {
//             Order order = _orderDAO.ReadById(id);
//             if (order is null)
//             {
//                 throw new NotFound();
//             }

//             return order;
//         }

//         public List<Order> ReadAll()
//         {
//             List<Order> OrdersList = _orderDAO.ReadAll();

//             if (OrdersList.Count == 0)
//             {
//                 throw new NotFound();
//             }

//             return OrdersList;
//         }

//         public void Update(Order order)
//         {
//             Order searchedOrder = _orderDAO.ReadById(order.Id);
//             if (searchedOrder is null)
//             {
//                 throw new NotFound();
//             }
            
//             if (order.Validate())
//             {
//                 _orderDAO.Update(order);
//             }
//         }

//         public void Delete(Int64 id)
//         {
//             Order searchedOrder = _orderDAO.ReadById(id);

//             if (searchedOrder is null)
//             {
//                 throw new NotFound();
//             }

//             _orderDAO.Delete(id);
//         }
//     }
// }
    }
    public class Order
    {
        // public void AddProduct(Product product, int quantity)
        // {
        //     if (product.Quantity < quantity) 
        //     {
                
        //     }

        //     Products.Add(product);
        // }

        // public Order PlaceOrder()
        // {
        //     Order order = new Order();
        //     darBaixa(Products);
        // }
    }
    public class Product
    {
        // public void Activate()
        // {
        //     IsActive = true;
        // }

        // public void Deactivate()
        // {
        //     IsActive = false;
        // }
    }
    public class Customer
    {
        // public Customer(string cpf, string fullName, DateTime birthDate, string address)
        // {
        //     Cpf = cpf;
        //     FullName = fullName;
        //     BirthDate = birthDate;
        //     Address = address;
        //     FidelityPoints = 0;
        // }

        // public bool HasFidelityDiscount
        // {
        //     get { return CheckFidelityDiscount(); }
        // }

        // public double UseFidelityDiscount()
        // {
        //     throw new NotImplementedException();
        // }

        // private bool CheckFidelityDiscount()
        // {
        //     return FidelityPoints >= 10 ? true : false;
        // }
        //////////////////////////
    }
    public class CustomerTests
    {
        // [Test]
        // public void CheckFidelityDiscount_FidelityPointsHigherThan10_ReturnsTrue()
        // {
        //     // arrange
        //     _customer.FidelityPoints = 11;

        //     // act

        //     // assert
        //     Assert.True(_customer.HasFidelityDiscount);
        // }

        // [Test]
        // public void CheckFidelityDiscount_FidelityPointsEqualTo10_ReturnsTrue()
        // {
        //     // arrange
        //     _customer.FidelityPoints = 10;

        //     // act

        //     // assert
        //     Assert.True(_customer.HasFidelityDiscount);
        // }

        // [Test]
        // public void CheckFidelityDiscount_FidelityPointsLowerThan10_ReturnsFalse()
        // {
        //     // arrange
        //     _customer.FidelityPoints = 0;

        //     // act

        //     // assert
        //     Assert.False(_customer.HasFidelityDiscount);
        // }
    }
}