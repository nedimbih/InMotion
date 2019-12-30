using InMotion.Data.Models;
using System.Threading.Tasks;

namespace InMotion.Data.Access {
	public interface IMessagesRepository {
		void SaveMessage(Message message);
	}
}