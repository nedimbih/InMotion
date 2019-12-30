using InMotion.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace InMotion.Data.Access {
	public class MessagesRepository : IMessagesRepository {
		private ApplicationDbContext _context;

		public MessagesRepository(ApplicationDbContext context) {
			_context=context;
		}

		public void SaveMessage(Message message) {
			_context.Messages.Add(message);
			 _context.SaveChanges();
		}

		public List<Message> GetUnreadMessages() {
			var newMsgs = _context.Messages.Where<Message>(m=>m.Seen==false).ToList();
			return newMsgs;
		}

		public void SetAllAsSeen() {
			var newMsgs = GetUnreadMessages();
			foreach (var message in newMsgs) {
				message.Seen=true;

			}
			_context.SaveChanges();
		}
	}
}
