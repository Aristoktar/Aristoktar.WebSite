using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.WebSite.Controllers {
	public class HomeController : Controller {

		
		public ActionResult Index () {

			var lang = Thread.CurrentThread.CurrentCulture.Name;
			return View (DateTime.Now);
		}

		public ActionResult About () {
			ViewBag.Message = "Your application description page.";

			return View ();
		}

		public ActionResult Contact () {
			ViewBag.Message = "Your contact page.";

			return View ();
		}
		public ActionResult Lorenz () {
			return View ();
		}
		
	}
}