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
                                    (@tipo_colecao, @numero_edicao, @ano_revista, @cor_caixa, @locada);";
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

        public ComicBook SearchComicBookByParameters(string comicBookCollectionType, string comicBookYear, string comicBookEditionNumber)
        {
            ComicBook searchedComicBook = new ComicBook();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT TOP(1) * FROM Revistas WHERE tipo_colecao = @tipo_colecao AND numero_edicao = @numero_edicao AND ano_revista = @ano_revista;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@tipo_colecao", comicBookCollectionType);
                    command.Parameters.AddWithValue("@ano_revista", comicBookYear);
                    command.Parameters.AddWithValue("@numero_edicao", comicBookEditionNumber);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        searchedComicBook = SqlToObject(reader);
                    }
                }
            }
            return searchedComicBook;
        }

        public void UpdateComicBook(ComicBook comicBook)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"UPDATE Revistas SET
                                    tipo_colecao = @tipo_colecao, numero_edicao = @numero_edicao, ano_revista = @ano_revista, cor_caixa = @cor_caixa, locada = @locada WHERE id_revista = @id_revista;";

                    command.Parameters.AddWithValue("@id_revista", comicBook.ComicBookId);

                    ObjectToSql(comicBook, command);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ComicBook> GenerateReportByFriend(string friendName)
        {
            List<ComicBook> comicBookList = new List<ComicBook>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    string sql = @"SELECT r.id_revista, r.tipo_colecao, r.numero_edicao, r.ano_revista, r.cor_caixa, r.locada
                                FROM Revistas r
                                JOIN Emprestimos e ON (e.id_revista = r.id_revista)
                                JOIN Amigos a ON (e.id_amigo = a.id_amigo)
                                WHERE a.nome_amigo = LOWER(@nome_amigo)
                                GROUP BY r.id_revista, r.tipo_colecao, r.numero_edicao, r.ano_revista, r.cor_caixa, r.locada;";
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("@nome_amigo", friendName.ToLower());
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comicBookList.Add(SqlToObject(reader));
                    }
                }
            }
            return comicBookList;
        }

        public ComicBook SqlToObject(SqlDataReader reader)
        {
            ComicBook comicBook = new ComicBook();

            comicBook.ComicBookId = Convert.ToInt64(reader["id_revista"]);
            comicBook.CollectionType = reader["tipo_colecao"].ToString();
            comicBook.EditionNumber = Convert.ToInt32(reader["numero_edicao"].ToString());
            comicBook.ComicBookYear = Convert.ToInt32(reader["ano_revista"]);
            comicBook.BoxColor =  (BoxColors)Enum.Parse(typeof(BoxColors),reader["cor_caixa"].ToString());
            comicBook.IsLocated = Convert.ToBoolean(reader["locada"]);

            return comicBook;
        }

        public void ObjectToSql(ComicBook comicBook, SqlCommand command)
        {
            command.Parameters.AddWithValue("@tipo_colecao", comicBook.CollectionType);
            command.Parameters.AddWithValue("@numero_edicao", comicBook.EditionNumber);
            command.Parameters.AddWithValue("@ano_revista", comicBook.ComicBookYear);
            command.Parameters.AddWithValue("@cor_caixa", comicBook.BoxColor);
            command.Parameters.AddWithValue("@locada", comicBook.IsLocated);
        }
    }
}

