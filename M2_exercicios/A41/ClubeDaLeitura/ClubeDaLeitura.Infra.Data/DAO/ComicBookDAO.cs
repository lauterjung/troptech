using System;
using ClubeDaLeitura.Domain;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ClubeDaLeitura.Infra.Data
{
    public class ComicBookDAO
    {
        private const string _connectionString = "server=.\\SQLexpress; initial catalog=CLUBEDALEITURADB; integrated security=true";

        public void AddComicBook(ComicBook comicBook)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"INSERT INTO Revistas VALUES 
                                    (@tipo_colecao, @numero_edicao, @ano_revista, @cor_caixa);";
                    ObjectToSql(comicBook, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ComicBook> SearchAllComicBooks()
        {
            List<ComicBook> comicBookList = new List<ComicBook>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Revistas";
                    command.CommandText = sql;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comicBookList.Add(SqlToObject(reader));
                    }
                }
            }
            return comicBookList;
        }

        public ComicBook SearchComicBookById(string comicBookId)
        {
            ComicBook searchedComicBook = new ComicBook();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT * FROM Revistas WHERE id_revista = @id_revista;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@id_revista", comicBookId);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedComicBook = SqlToObject(reader);
                    }
                }
            }
            return searchedComicBook;
        }

        public ComicBook SqlToObject(SqlDataReader reader)
        {
            ComicBook comicBook = new ComicBook();

            comicBook.ComicBookId = Convert.ToInt64(reader["id_revista"]);
            comicBook.CollectionType = reader["tipo_colecao"].ToString();
            comicBook.EditionNumber = Convert.ToInt32(reader["numero_edicao"].ToString());
            comicBook.ComicBookYear = Convert.ToInt32(reader["ano_revista"]);
            comicBook.BoxColor = reader["cor_caixa"].ToString();

            return comicBook;
        }

        public void ObjectToSql(ComicBook comicBook, SqlCommand command)
        {
            command.Parameters.AddWithValue("@tipo_colecao", comicBook.CollectionType);
            command.Parameters.AddWithValue("@numero_edicao", comicBook.EditionNumber);
            command.Parameters.AddWithValue("@ano_revista", comicBook.ComicBookYear);
            command.Parameters.AddWithValue("@cor_caixa", comicBook.BoxColor);
        }
    }
}

