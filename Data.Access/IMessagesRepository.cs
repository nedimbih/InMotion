using InMotion.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InMotion.Data.Access {
	public interface IMessagesRepository {
		void SaveMessage(Message message);
		public List<Message> GetUnreadMessages();
		public void SetAllAsSeen();
	}
}