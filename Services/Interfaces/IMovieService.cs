using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace InMotion.Services {
	public interface IMovieService {
		StringContent prepareMovieAsync(Movie movie);
		List<Movie> GetMovies();
		void EditMovie(Movie movie);
		Movie GetMovie(string id);
	}
}
