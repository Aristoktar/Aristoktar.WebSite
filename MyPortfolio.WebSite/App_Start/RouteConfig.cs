using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyPortfolio.WebSite {
	public class RouteConfig {
		public static void RegisterRoutes ( RouteCollection routes ) {
			routes.IgnoreRoute ( "{resource}.axd/{*pathInfo}" );

			routes.MapRoute (
				name: "lang" ,
				url: "{lang}/{controller}/{action}/{id}" ,
				constraints : new { lang = @"ru|en" },
				defaults: new {
					controller = "Home" ,
					action = "Index" ,
					lang = "ru",
					id = UrlParameter.Optional
				}
			);
			routes.MapRoute (
				name: "default" ,
				url: "{controller}/{action}/{id}" ,
				defaults: new {
					controller = "Home" ,
					action = "Index" ,
					id = UrlParameter.Optional ,
					lang = "ru"
				}
			);

		}
	}
}
