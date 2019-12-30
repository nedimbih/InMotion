using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace InMotion.Data.Access {
	public class MoviesRepository : IMoviesRepository {
		private ApplicationDbContext _context;

		public MoviesRepository(ApplicationDbContext context) {
			_context=context;
		}

		public List<Movie> GetAllMovies() {
			List<Movie> movies = _context.Movies.ToList();
			return movies;
		}

		public Movie GetMovie (string id) {
			return _context.Movies.First<Movie>(m=>m.Id==id);
		}

		public void AddMovie (Movie movie) {
			_context.Movies.Add(movie);
			_context.SaveChanges();
		}

		public void UpdateMovie(Movie movie) { 
			_context.Update<Movie>(movie);
			_context.SaveChanges();
		}

		public void DeleteMovie (Movie movie) {
			_context.Remove<Movie>(movie);
		}
	}
}
