using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.WebSite.Models.Eisenhower;

namespace MyPortfolio.WebSite.Controllers
{
    public class EisenhowerController : Controller
    {

		private IDataContext m_DataContext;

		public EisenhowerController ( IDataContext dataContext ) {
			m_DataContext = dataContext;
		}
        // GET: Eisenhower
        public ActionResult Index()
        {
			var tasks = m_DataContext.EisenhowerTaskQuery.Select ( a => new EisenhowerTaskModel {
				Name = a.Name,
				Description =a.Description,
				Priority = a.Priority
			} ).ToList();
            return View(tasks);
        }

		public ActionResult AddTask () {
			return View ();
		}
    }
}