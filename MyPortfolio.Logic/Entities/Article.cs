using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Logic.Entities {
	public class Article {
		public int Id {
			get;
			set;
		}
		public string Name {
			get;
			set;
		}
		public string Brief {
			get;
			set;
		}
		public int CategoryId {
			get;
			set;
		}
		public virtual ArticleCategory Category {
			get;
			set;
		}
	}
}
