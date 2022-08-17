using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MercadoSeuZeDAO;

namespace MercadoSeuZe
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemActions.RunProgram();
            // string connectionString = "server=.\\SQLexpress; initial catalog=MERCADOSEUZEDB; integrated security=true";
            // SqlConnection connection = new SqlConnection(connectionString);

            // // Create
            // connection.Open();

            // SqlCommand insertCommand = new SqlCommand(@"INSERT INTO Produtos VALUES
            // ('Refrigerante', 'Picolino Cola', '2022-11-15', 5.25, '2 L', 4),
            // ('Pão', 'Pão de forma', '2022-08-16', 6.75, '300 g', 5),
            // ('Chocolate', 'Chocolate Nestle', '2022-12-27', 7.52, '120 g', 6),
            // ('Amaciante', 'Comfort', '2022-08-18', 8.25, '1 L', 7),
            // ('Refrigerante', 'Picolino Guaraná', '2022-12-15', 4.25, '2 L', 9),
            // ('Pão', 'Pão francês', '2022-08-10', 0.40, '1 u', 50),
            // ('Chocolate', 'Chocolate Hersheys', '2022-12-10', 5.20, '120 g', 23),
            // ('Sabão em pó', 'Omo', '2023-01-15', 10.25, '1 kg', 7),
            // ('Refrigerante', 'Picolino Laranjinha', '2022-12-25', 4.25, '2 L', 1),
            // ('Água', 'Picolino Água', '2023-05-15', 2.25, '500 mL', 6)
            // ", connection);

            // insertCommand.ExecuteNonQuery();
            // connection.Close();

            // // Update
            // connection.Open();
            // string updateConcat = "UPDATE Produtos SET quantidade_estoque = 2 WHERE produto_id = 1;" +
            //                       "UPDATE Produtos SET quantidade_estoque = 4 WHERE produto_id = 2;" +
            //                       "UPDATE Produtos SET quantidade_estoque = 5 WHERE produto_id = 3;" +
            //                       "UPDATE Produtos SET quantidade_estoque = 6 WHERE produto_id = 4;" +
            //                       "UPDATE Produtos SET quantidade_estoque = 4 WHERE produto_id = 10";

            // SqlCommand updateCommand = new SqlCommand(updateConcat, connection);
            // updateCommand.ExecuteNonQuery();
            // connection.Close();

            // // Delete
            // connection.Open();
            // string deleteConcat = "DELETE FROM Produtos WHERE produto_id = 1;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 2;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 3;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 4;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 5;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 6;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 7;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 8;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 9;" +
            //                       "DELETE FROM Produtos WHERE produto_id = 10";

            // SqlCommand deleteCommand = new SqlCommand(deleteConcat, connection);
            // deleteCommand.ExecuteNonQuery();
            // connection.Close();

            // ProductDAO.ViewAllProducts();
            // ProductDAO.ViewProductById("1");
            // ProductDAO.ViewProductByDescription("Picolino Cola");
            // // ProductDAO.ConsoleAddProduct();
            // // ProductDAO.DeleteFromProductsById("1");
            // ProductDAO.UpdateProducts("quantidade_estoque", "0", "1");
            // ProductDAO.ViewProductById("1");
            // ProductDAO.ViewAllProducts();
        }
    }
}
