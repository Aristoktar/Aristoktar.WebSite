using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Enums;

namespace MyPortfolio.Logic.Exceptions {
	[Serializable]
	public sealed class MyPortfolioException :ApplicationException {
		public ExceptionType Type {
			get;
			set;
		}
		public MyPortfolioException ()
			: base ( "Unhandled exception." ) {
			
		}
		public MyPortfolioException (ExceptionType type)
			: base ( "Unhandled exception." ) {
			Type = type;
		}
	}
}
