using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMotion.Data.Models;
using InMotion.Data.Access;
using Microsoft.AspNetCore.Mvc;

namespace ApiServer.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class MessagesController : ControllerBase {
		private IMessagesRepository _repo;

		public MessagesController(IMessagesRepository repo) {
			_repo = repo;
		}
		
		[HttpPost]
		public  void Post([FromBody]Message message) {
			 _repo.SaveMessage(message);

		}
	}
}
