using InMotion.Data.Access;
using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InMotion.Services {
	public class MessageService : IMessageService {
		private IMessagesRepository _repo;

		public MessageService(IMessagesRepository repo) {
			_repo=repo;
		}

		public StringContent prepareMessageAsync(Message message) {
			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(message);
			var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
			return content; 
		}

		public List<Message> GetUnreadMessages() {
			return _repo.GetUnreadMessages();
		}

		public void SetAsSeen() {
			_repo.SetAllAsSeen();
		}

	}
}
