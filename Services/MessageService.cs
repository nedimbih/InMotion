using InMotion.Data.Access;
using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace InMotion.Services {
	public class MessageService : IMessageService {
		private ApplicationDbContext _context;

		public MessageService(ApplicationDbContext context) {
			_context=context;
		}

		public async Task<StringContent> prepareMessageAsync(Message message) {
			var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(message);
			var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");
			return content; 
		}

		public Task SaveMessageAsync(Message message) => throw new NotImplementedException();
	}
}
