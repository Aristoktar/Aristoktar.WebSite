using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyPortfolio.Logic.Exceptions;

namespace MyPortfolio.WebSite.Filters {
	public class ExceptionFilter:IExceptionFilter {
		public void OnException ( ExceptionContext filterContext ) {
			if ( filterContext == null ) return;
			var exception = filterContext.Exception;
			if ( exception is MyPortfolioException ) {
				switch ( ((MyPortfolioException)exception).Type) {
					case Logic.Enums.ExceptionType.AdminAuthorization:
						filterContext.Result = new RedirectToRouteResult (
							new RouteValueDictionary 
							{ 
								{ "controller", "Admin" }, 
								{ "action", "LogIn" },
								{ "area", "Admin" }
							} );
						break;
					default:
						break;				
				}
			}
		}
	}
}