using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.WebSite.Models.Home {
	public class LoginModel {
		public string UserName {
			get;
			set;
		}
		public UserRole Role {
			get;
			set;
		}
		
	}
}