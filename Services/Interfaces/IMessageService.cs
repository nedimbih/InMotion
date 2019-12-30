using InMotion.Data;
using InMotion.Data.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InMotion.Services {
	public interface IMessageService {
		public StringContent prepareMessageAsync(Message message);
		public List<Message> GetUnreadMessages();
		public void SetAsSeen();
	}
}