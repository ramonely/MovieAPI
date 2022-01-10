using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MovieAPI.Model
{
    public class MovieCallsAPI
    {
        public Movie GetMovie(int id)
        {
            string sql = $"select * from movies where id={id}";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                Movie m = connect.Query<Movie>(sql).FirstOrDefault();
                connect.Close();

                return m;
            }

        }
        public List<Movie> GetByGenre(string value)
        {
            string sql = $"select * from movies where genre='{value}'";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return m;
            }

        }
        public Movie GetRandomByGenre(string genre)
        {
            string sql = $"select * from movies where genre='{genre}'";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                Random r = new Random();
                int ran = r.Next(0, m.Count());
                return m[ran];
            }
        }
        public List<Movie> GetMovies()
        {
            string sql = $"select * from movies";

            using (var connect = new MySqlConnection(Secret.Connection))
            {
                connect.Open();
                List<Movie> m = connect.Query<Movie>(sql).ToList();
                connect.Close();

                return m;
            }
        }

    }
}
