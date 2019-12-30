using InMotion.Data.Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace InMotion.Services {
	public class NotificationService:INotificationService  {
		private IMessagesRepository _repo;

		public NotificationService(IMessagesRepository repo) {
			_repo = repo;
		}

		public bool HasNewMessages() {
			var newMsgs = _repo.GetUnreadMessages();
			return newMsgs.Count > 0;
		}
	}
}
