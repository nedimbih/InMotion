using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InMotion.Data.Access {
	public interface IMoviesRepository {
		List<Movie> GetAllMovies();
		Movie GetMovie(string id);
		 void AddMovie(Movie movie);
		void UpdateMovie(Movie movie);
		void DeleteMovie(Movie movie);
	}
}
