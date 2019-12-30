using InMotion.Data;
using InMotion.Data.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace InMotion.Services {
	public interface IMessageService {
		public Task SaveMessageAsync(Message message);
		public Task<StringContent> prepareMessageAsync(Message message);
	}
}