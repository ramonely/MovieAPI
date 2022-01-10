using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MovieAPI.Controllers
{
    public class MovieController : Controller
    {
        MovieCallsAPI mAPI = new MovieCallsAPI();

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return mAPI.GetMovies();
        }

        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return mAPI.GetMovie(id);
        }

        [HttpGet("genre={genre}")]
        public List<Movie> GetByGenre(string genre)
        {
            List<Movie> m = mAPI.GetByGenre(genre);
            if (m.Count == 0)
            {
                m.Add(new Movie($"No Movies Found with Genre = {genre}"));
            }
            return m;
        }

        [HttpGet("random/{numMovies}")]
        public List<Movie> GetRandom(int numMovies)
        {
            List<Movie> m = mAPI.GetMovies();
            List<Movie> ranMovies = new List<Movie>();
            List<int> indices = new List<int>();
            Random r = new Random();

            if (numMovies > m.Count())
            {
                numMovies = m.Count();
            }

            for (int i = 1; i <= numMovies; i++)
            {
                int random = r.Next(0, m.Count());
                while (indices.Contains(random))
                {
                    random = r.Next(0, m.Count());
                }
                indices.Add(random);
            }

            foreach (int i in indices)
            {
                ranMovies.Add(m[i]);
            }

            return ranMovies;
        }

        [HttpGet("randombygenre/{genre}")]
        public Movie GetRandomByGenre(string genre)
        {
            Movie m = mAPI.GetRandomByGenre(genre);
            if (m == null)
            {
                m = new Movie($"No movies with Genre: {genre}");
            }

            return m;
        }

        [HttpGet("RandomList/{quantity}")]
        public List<Movie> GetRandomMovies(int quantity)
      {
            List<Movie> movies = mAPI.GetMovies();
            if (movies.Count <= quantity)
            {
                return movies;
            }
            else
            {
                List<Movie> output = new List<Movie>();
                while (output.Count < quantity)
                {
                    Random rng = new Random();
                    int pick = rng.Next(0, movies.Count);
                    output.Add(movies[pick]);
                    movies.RemoveAt(pick);
                } 
                return output;
            }
        }

        [HttpGet("GetMovie/{title}")]
        public Movie GetMovie(string title)
        {
            List<Movie> movies = mAPI.GetMovies();
            List<Movie> filtered = movies.Where(x => x.Title == title).ToList();
            if (filtered.Count > 0)
            {

                return filtered.First();
            }
            else
            {
                Movie error = new Movie();
                error.Title = "No movie found with that title: " + title;
                return error;
            }
        }
    }
}
