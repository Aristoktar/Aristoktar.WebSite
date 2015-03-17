using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.Logic.Entities {
	public class User {
		public int Id {
			get;
			set;
		}
		public UserRole Role {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public string UniqueString {
			get;
			set;
		}
		public string Email {
			get;
			set;
		}
		public string VKUserId {
			get;
			set;
		}
		public string Password {
			get;
			set;
		}
	}
}
