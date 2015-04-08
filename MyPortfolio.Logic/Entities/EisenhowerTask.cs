using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.Logic.Entities {
	public class EisenhowerTask {
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

		public EisenhowerPriority Priority {
			get;
			set;
		}

		public DateTime Created {
			get;
			set;
		}

		
	}
}
