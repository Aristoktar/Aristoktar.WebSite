using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Logic.Entities {
	public class ArticlePart {
		public int Id {
			get;
			set;
		}
		public int Order {
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
		public int ArticleId {
			get;
			set;
		}
		public virtual Article Article {
			get;
			set;
		}

	}
}
