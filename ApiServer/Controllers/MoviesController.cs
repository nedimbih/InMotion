using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMotion.Data.Access;
using InMotion.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class MoviesController :  ControllerBase {
		private IMoviesRepository _repo;

		public MoviesController(IMoviesRepository repo) {
			_repo=repo;
		}


		[HttpGet]
		public List<Movie> Get() {
			return _repo.GetAllMovies();
		}

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public Movie Get(string id) {
			return _repo.GetMovie(id);
		}

		// POST api/<controller>
		[HttpPost]
		public void Post([FromBody]Movie movie) {
			_repo.AddMovie(movie);
		}

		// PUT api/<controller>/5
		[HttpPut]
		public void Put([FromBody]Movie movie) {
			_repo.UpdateMovie(movie);
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Delete(Movie movie) {
			_repo.DeleteMovie(movie);
		}
	}
}
