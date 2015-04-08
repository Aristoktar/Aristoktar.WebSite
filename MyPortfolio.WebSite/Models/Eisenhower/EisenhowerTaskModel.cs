using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.WebSite.Models.Eisenhower {
	public class EisenhowerTaskModel {
		public string Name {
			get;
			set;
		}
		public string Description {
			get;
			set;
		}

		public EisenhowerPriority Priority {
			get;
			set;
		}
	}
}