using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InMotion.Data.Models {
	public class Message {
		public string Id { get; set; }
		public string Name { get; set; }

		[Required]
		public string Text { get; set; }

		public bool Seen { get; set; }
	}	
}
