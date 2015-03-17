using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.WebSite.Models.Account {
	public class LogInModel {
		public string Email {
			get;
			set;
		}
		public string Password {
			get;
			set;
		}
		public bool StatusPost {
			get;
			set;
		}
	}
}