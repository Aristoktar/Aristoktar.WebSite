using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.WebSite.Models.Account {
	public class LogInVKModel {
		public string expire {
			get;
			set;
		}
		public string mid {
			get;
			set;
		}

		public string secret {
			get;
			set;
		}
		public string sid {
			get;
			set;
		}

		public string sig {
			get;
			set;
		}

		public string Email {
			get;
			set;
		}

		public string UserId {
			get;
			set;
		}
		public string Token {
			get;
			set;
		}
		
	}
}