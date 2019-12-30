using InMotion.Data.Access;
using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace InMotion.Services {
	public class MovieService : IMovieService {
		private IMoviesRepository _repo;

		public MovieService(IMoviesRepository repo) {
			_repo=repo;
		}
		public StringContent prepareMovieAsync(Movie movie) {
			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(movie);
			var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
			return content;
		}

		public List<Movie> GetMovies() {
			return _repo.GetAllMovies();
		}

		public void EditMovie(Movie movie) {
			_repo.UpdateMovie(movie);
		}

		public Movie GetMovie (string id) {
			return _repo.GetMovie(id);
		}
	}
}
