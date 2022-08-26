using System;
using ClubeDaLeitura.Domain;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ClubeDaLeitura.Infra.Data
{
    public class BookLoanDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=CLUBEDALEITURADB; integrated security=true";

        public void AddBookLoan(BookLoan bookLoan)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Emprestimos VALUES 
                                    (@id_amigo, @id_revista, @data_emprestimo, @preco, @data_devolucao);";

                    ObjectToSql(bookLoan, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<BookLoan> SearchAllBookLoans()
        {
            List<BookLoan> bookLoanList = new List<BookLoan>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT e.*, a.nome_amigo, r.tipo_colecao, r.numero_edicao, r.ano_revista
                                    FROM Emprestimos e
                                    JOIN Amigos a ON (a.id_amigo = e.id_amigo)
                                    JOIN Revistas r ON (r.id_revista = e.id_revista);";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bookLoanList.Add(SqlToObject(reader));
                    }
                }
            }
            return bookLoanList;
        }
        public BookLoan SearchBookLoanByComicBookParameters(string comicBookCollectionType, string comicBookYear, string comicBookEditionNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT TOP(1) e.*, a.nome_amigo, r.tipo_colecao, r.numero_edicao, r.ano_revista, r.locada
                                    FROM Emprestimos e
                                    JOIN Amigos a ON (a.id_amigo = e.id_amigo)
                                    JOIN Revistas r ON (r.id_revista = e.id_revista)
                                    WHERE r.tipo_colecao = @tipo_colecao AND r.numero_edicao = @numero_edicao AND r.ano_revista = @ano_revista AND r.locada = 1;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@tipo_colecao", comicBookCollectionType);
                    command.Parameters.AddWithValue("@ano_revista", comicBookYear);
                    command.Parameters.AddWithValue("@numero_edicao", comicBookEditionNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        BookLoan bookLoan = SqlToObject(reader);
                        return bookLoan;
                    }
                }
            }
            return null;            
        }

        public void UpdateBookLoan(BookLoan bookLoan)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Emprestimos SET 
                                    id_amigo = @id_amigo, id_revista = @id_revista, data_emprestimo = @data_emprestimo, preco = @preco, data_devolucao = @data_devolucao WHERE id_emprestimo = @id_emprestimo;";

                    ObjectToSql(bookLoan, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public BookLoan SqlToObject(SqlDataReader reader)
        {
            BookLoan BookLoan = new BookLoan();

            BookLoan.BookLoanId = Convert.ToInt64(reader["id_emprestimo"]);
            BookLoan.BookLoanId = Convert.ToInt64(reader["id_revista"]);
            BookLoan.LoanDate = Convert.ToDateTime(reader["data_emprestimo"]);
            BookLoan.Price = Convert.ToDouble(reader["preco"]);
            BookLoan.ReturnDate = reader["data_devolucao"] as DateTime?;

            BookLoan.BorrowingFriend.FriendId = Convert.ToInt64(reader["id_amigo"]);
            BookLoan.BorrowingFriend.Name = reader["nome_amigo"].ToString();

            BookLoan.BorrowedComicBook.ComicBookId = Convert.ToInt64(reader["id_revista"]);
            BookLoan.BorrowedComicBook.CollectionType = reader["tipo_colecao"].ToString();
            BookLoan.BorrowedComicBook.EditionNumber = Convert.ToInt32(reader["numero_edicao"]);
            BookLoan.BorrowedComicBook.ComicBookYear = Convert.ToInt32(reader["ano_revista"]);

            return BookLoan;
        }

        public void ObjectToSql(BookLoan BookLoan, SqlCommand command)
        {
            command.Parameters.AddWithValue("@id_emprestimo", BookLoan.BookLoanId);
            command.Parameters.AddWithValue("@id_amigo", BookLoan.BorrowingFriend.FriendId);
            command.Parameters.AddWithValue("@id_revista", BookLoan.BorrowedComicBook.ComicBookId);
            command.Parameters.AddWithValue("@data_emprestimo", BookLoan.LoanDate);
            command.Parameters.AddWithValue("@preco", BookLoan.Price);
            command.Parameters.AddWithValue("@data_devolucao", (BookLoan.ReturnDate is null) ? DBNull.Value : BookLoan.ReturnDate);
        }
    }
}