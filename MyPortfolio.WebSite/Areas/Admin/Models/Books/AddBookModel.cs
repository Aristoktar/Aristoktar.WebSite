using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.WebSite.Areas.Admin.Models.Books {
	public class AddBookModel {
		public string Name {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public AuthorModel Author {
			get;
			set;
		}

		public IEnumerable<AuthorModel> Authors {
			get;
			set;
		}
		public bool IsAuthorNew {
			get;
			set;
		}
	}
}