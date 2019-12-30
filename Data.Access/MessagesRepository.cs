using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InMotion.Data.Access {
	public class MessagesRepository : IMessagesRepository {
		private ApplicationDbContext _context;

		public MessagesRepository(ApplicationDbContext context) {
			_context=context;
		}

		public async void SaveMessage(Message message) {
			_context.Messages.Add(message);
			 _context.SaveChanges();
		}
	}
}
