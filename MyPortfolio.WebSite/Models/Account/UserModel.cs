using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.WebSite.Models.Account {
	public class UserModel {
		public int Id {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public UserRole Role {
			get;
			set;
		}

	}
}