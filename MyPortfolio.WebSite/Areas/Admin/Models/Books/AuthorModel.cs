using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.WebSite.Areas.Admin.Models.Books {
	public class AuthorModel {
		public int Id {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}
	}
}