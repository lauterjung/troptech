using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using MercadoSeuZe.ClassLib.Exceptions;

namespace MercadoSeuZe.ClassLib
{
    public class OrderDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
        private ProductDAO _productDAO = new ProductDAO();
        private ClientDAO _clientDAO = new ClientDAO();

        public void AddOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Pedidos VALUES 
                                    (@data_pedido, @hora, @produto_id, @quantidade_produto, @valor_total, @cpf_cliente);";
                    ObjectToSql(order, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();

                    double newFidelityPoints = order.Client.FidelityPoints + order.FidelityPoints;
                    _clientDAO.UpdateClientFidelityPoints(newFidelityPoints, order.Client.Cpf);

                    int newQuantity = order.OrderProduct.Quantity - order.ProductQuantity;
                    _productDAO.UpdateProductQuantityById(newQuantity, order.OrderProduct.ProductId.ToString());
                }
            }
        }

        public void UpdateOrder(Order modifiedOrder, Order oldOrder)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    Product oldProduct = _productDAO.SearchProductById(oldOrder.OrderProduct.ProductId.ToString());
                    int oldProductStartingQuantity = oldProduct.Quantity;
                    long oldProductId = oldProduct.ProductId;
                    
                    Client oldClient = _clientDAO.SearchClientByCpf(oldOrder.Client.Cpf);
                    double oldClientFidelityPoints = oldClient.FidelityPoints;

                    string sql = @"UPDATE Pedidos SET data_pedido = @data_pedido, hora = @hora, produto_id = @produto_id, quantidade_produto = @quantidade_produto, valor_total = @valor_total, cpf_cliente = @novo_cpf_cliente WHERE pedido_id = @pedido_id;";

                    ObjectToSql(modifiedOrder, command);
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@novo_cpf_cliente", modifiedOrder.Client.Cpf);
                    command.ExecuteNonQuery();

                    double oldClientUpdatedFidelityPoints = oldClientFidelityPoints - oldOrder.FidelityPoints;
                    _clientDAO.UpdateClientFidelityPoints(oldClientUpdatedFidelityPoints, oldOrder.Client.Cpf);

                    double newClientFidelityPoints = modifiedOrder.Client.FidelityPoints + modifiedOrder.FidelityPoints;
                    _clientDAO.UpdateClientFidelityPoints(newClientFidelityPoints, modifiedOrder.Client.Cpf);

                    int oldProductUpdatedQuantity = oldProductStartingQuantity + oldOrder.ProductQuantity;
                    _productDAO.UpdateProductQuantityById(oldProductUpdatedQuantity, oldProductId.ToString());

                    int newProductQuantity = modifiedOrder.OrderProduct.Quantity - modifiedOrder.ProductQuantity;
                    _productDAO.UpdateProductQuantityById(newProductQuantity, modifiedOrder.OrderProduct.ProductId.ToString());
                }
            }
        }

        public void DeleteOrderById(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    double newFidelityPoints = order.Client.FidelityPoints - order.FidelityPoints;
                    _clientDAO.UpdateClientFidelityPoints(newFidelityPoints, order.Client.Cpf);

                    int newQuantity = order.OrderProduct.Quantity + order.ProductQuantity;
                    _productDAO.UpdateProductQuantityById(newQuantity, order.OrderProduct.ProductId.ToString());

                    command.Connection = connection;
                    string sql = @"DELETE FROM Pedidos WHERE pedido_id = @pedido_id;";
                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@pedido_id", order.OrderId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Order> SearchAllOrders()
        {
            List<Order> orderList = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    string sql = @"SELECT pd.pedido_id, p.nome AS produto, p.descricao AS descricao_produto, pd.quantidade_produto, pd.valor_total, c.nome AS cliente, pd.data_pedido, pd.hora, pd.cpf_cliente, pd.produto_id
                                    FROM Pedidos pd
                                    JOIN Clientes c ON (c.cpf = pd.cpf_cliente)
                                    JOIN Produtos p ON (pd.produto_id = p.produto_id);";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        orderList.Add(SqlToObject(reader));
                    }
                }
            }
            return orderList;
        }

        public Order SearchOrderById(string orderId)
        {
            Order searchedOrder = new Order();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT pd.pedido_id, p.nome AS produto, p.descricao AS descricao_produto, pd.quantidade_produto, pd.valor_total, c.nome AS cliente, pd.data_pedido, pd.hora, pd.cpf_cliente, pd.produto_id
                                    FROM Pedidos pd
                                    JOIN Clientes c ON (c.cpf = pd.cpf_cliente)
                                    JOIN Produtos p ON (pd.produto_id = p.produto_id)
                                    WHERE pedido_id = @pedido_id;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@pedido_id", orderId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedOrder = SqlToObject(reader);
                    }
                }
            }
            return searchedOrder;
        }

        public List<Order> SearchOrdersByClientCpf(string cpf)
        {
            List<Order> searchedOrders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT pd.pedido_id, p.nome AS produto, p.descricao AS descricao_produto, pd.quantidade_produto, pd.valor_total, c.nome AS cliente, pd.data_pedido, pd.hora, pd.cpf_cliente, pd.produto_id
                                    FROM Pedidos pd
                                    JOIN Clientes c ON (c.cpf = pd.cpf_cliente)
                                    JOIN Produtos p ON (pd.produto_id = p.produto_id)
                                    WHERE cpf_cliente = @cpf_cliente;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@cpf_cliente", cpf);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedOrders.Add(SqlToObject(reader));
                    }
                }
            }
            return searchedOrders;
        }

        public List<Order> SearchOrdersByProductId(string productId)
        {
            List<Order> searchedOrders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT pd.pedido_id, p.nome AS produto, p.descricao AS descricao_produto, pd.quantidade_produto, pd.valor_total, c.nome AS cliente, pd.data_pedido, pd.hora, pd.cpf_cliente, pd.produto_id
                                    FROM Pedidos pd
                                    JOIN Clientes c ON (c.cpf = pd.cpf_cliente)
                                    JOIN Produtos p ON (pd.produto_id = p.produto_id)
                                    WHERE pd.produto_id = @produto_id;";

                    command.CommandText = sql;
                    command.Parameters.AddWithValue("@produto_id", productId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedOrders.Add(SqlToObject(reader));
                    }
                }
            }
            return searchedOrders;
        }

        public Order SqlToObject(SqlDataReader reader)
        {
            Order newOrder = new Order();

            newOrder.OrderId = Convert.ToInt64(reader["pedido_id"]);
            newOrder.OrderDate = Convert.ToDateTime(reader["data_pedido"], CultureInfo.InvariantCulture).Date;
            newOrder.OrderTime = TimeSpan.Parse(reader["hora"].ToString());
            newOrder.ProductQuantity = Convert.ToInt32(reader["quantidade_produto"]);
            newOrder.TotalPrice = Convert.ToDouble(reader["valor_total"]);

            newOrder.OrderProduct.Name = reader["produto"].ToString();
            newOrder.OrderProduct.Description = reader["descricao_produto"].ToString();
            newOrder.OrderProduct.ProductId = Convert.ToInt64(reader["produto_id"]);

            newOrder.Client.Name = reader["cliente"].ToString();
            newOrder.Client.Cpf = reader["cpf_cliente"].ToString();

            return newOrder;
        }

        public void ObjectToSql(Order order, SqlCommand command)
        {
            if (order.OrderProduct.Quantity < order.ProductQuantity)
            {
                throw new InsuficientQuantityException();
            }

            command.Parameters.AddWithValue("@pedido_id", order.OrderId);
            command.Parameters.AddWithValue("@data_pedido", order.OrderDate);
            command.Parameters.AddWithValue("@hora", order.OrderTime);
            command.Parameters.AddWithValue("@produto_id", order.OrderProduct.ProductId);
            command.Parameters.AddWithValue("@quantidade_produto", order.ProductQuantity);
            command.Parameters.AddWithValue("@valor_total", order.TotalPrice);
            command.Parameters.AddWithValue("@cpf_cliente", order.Client.Cpf);
        }
    }
}
