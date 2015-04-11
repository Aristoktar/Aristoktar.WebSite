using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.WebSite.Models;

namespace MyPortfolio.WebSite.Controllers
{
    public class BooksController : Controller
    {
		IDataContext m_context;

		public BooksController (IDataContext context) {
			m_context = context;
		}

        // GET: Books
        public ActionResult Index()
        {
			var m = m_context.BooksQuery
				.Select ( a => new BookModel {
					Name = a.Name//,
					//Author = a.Author
				} ).ToList ();
            return View(m);
        }
    }
}