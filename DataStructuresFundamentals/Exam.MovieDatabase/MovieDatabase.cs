using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<Actor, HashSet<Movie>> actorsByMovies = new Dictionary<Actor, HashSet<Movie>>();
        private HashSet<Movie> movies = new HashSet<Movie>();

        public void AddActor(Actor actor)
        {
            actorsByMovies.Add(actor, new HashSet<Movie>());
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!actorsByMovies.ContainsKey(actor))
            {
                throw new ArgumentException();
            }

            actorsByMovies[actor].Add(movie);
            movies.Add(movie);
        }

        public bool Contains(Actor actor) => actorsByMovies.ContainsKey(actor);

        public bool Contains(Movie movie) => movies.Contains(movie);

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount() => actorsByMovies
            .OrderByDescending(kvp => kvp.Value.OrderByDescending(m => m.Budget)).ThenByDescending(a => a.Value.Count)
            .Select(a => a.Key);

        public IEnumerable<Movie> GetAllMovies() => movies;

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper) =>
            movies.Where(m => m.Budget >= lower && m.Budget <= upper).OrderByDescending(m => m.Rating);

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating() =>
            movies.OrderByDescending(m => m.Budget).ThenByDescending(m => m.Rating);

        public IEnumerable<Actor> GetNewbieActors() => actorsByMovies.Where(a => a.Value.Count == 0).Select(a => a.Key).ToList();
    }
}
