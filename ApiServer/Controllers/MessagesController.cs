using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMotion.Data.Models;
using InMotion.Data.Access;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class MessagesController : ControllerBase {
		private IMessagesRepository _repo;

		public MessagesController(IMessagesRepository repo) {
			_repo = repo;

		}
		[HttpGet]
		public ActionResult<Message> Get() {
			return new Message { Text= "value2" };
		}

		//[HttpGet("{id}")]
		//public string Get(int id) {
		//	return "value";
		//}

		[HttpPost]
		public  void Post([FromBody]Message message) {
			 _repo.SaveMessage(message);

		}

		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody]string value) {
		//}

		//[HttpDelete("{id}")]
		//public void Delete(int id) {
		//}
	}
}
