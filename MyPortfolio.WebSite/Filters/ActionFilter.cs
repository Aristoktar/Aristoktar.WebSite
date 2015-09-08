using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.WebSite.Filters {
	public class ActionFilter : IActionFilter {
		public void OnActionExecuted ( ActionExecutedContext filterContext ) {
			//throw new NotImplementedException ();
		}

		public void OnActionExecuting ( ActionExecutingContext filterContext ) {
			
			string CurrentLangCode;

			if ( filterContext.RequestContext.RouteData.Values["lang"] != null && filterContext.RequestContext.RouteData.Values["lang"] as string != "null" ) {
				CurrentLangCode = filterContext.RequestContext.RouteData.Values["lang"] as string;
				//var CurrentLang = Repository.Languages.FirstOrDefault ( p => p.Code == CurrentLangCode );

				var ci = new CultureInfo ( CurrentLangCode );
				Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture ( new CultureInfo ( CurrentLangCode ).Name );
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture ( new CultureInfo ( CurrentLangCode ).Name );
			}

			//	if ( filterContext.RequestContext.HttpContext.Request.Cookies["Lang"] != null ) {
			//	string lang = filterContext.RequestContext.HttpContext.Request.Cookies["Lang"].Value;
			//	if (!string.IsNullOrWhiteSpace ( lang ) ) {
			//		Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture ( new CultureInfo ( lang ).Name );
			//		Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture ( new CultureInfo ( lang ).Name );

			//	}
			//}
		}
	}
}