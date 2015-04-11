using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;
using MyPortfolio.WebSite.Areas.Admin.Models.Books;

namespace MyPortfolio.WebSite.Areas.Admin.Controllers
{
    public class BooksAdminController : Controller
    {
		private IDataContext m_DataContext;

		public BooksAdminController (IDataContext dataContext) {
			m_DataContext = dataContext;
		}

        // GET: Admin/BooksAdmin
        public ActionResult Index()
        {
			return View ( m_DataContext.BooksQuery.Select ( a => new BookModel {
				Id = a.Id ,
				Name = a.Name
			} ).ToList () );
        }

		[HttpGet]
		public ActionResult AddBook () {

			return View ( new AddBookModel {
				Authors = m_DataContext.AuthorsQuery
					.Select ( a => new AuthorModel {
					Id = a.Id,
					Description = a.Description,
					Name = a.Name
					} ).ToList ()
			} );
		}

		[HttpPost]
		public ActionResult Addbook (AddBookModel model) {
			if ( model.IsAuthorNew ) {
				var author = new Author {
					Name = model.Author.Name ,
					Description = model.Author.Description
				};
				m_DataContext.AddAuthor ( author );
				m_DataContext.SaveAllChanges ();
				var book = new Book {
					Name = model.Name ,
					Description = model.Description
				};
				m_DataContext.AddBook ( book );
				m_DataContext.SaveAllChanges ();
			}
			else {
				var book = new Book {
					AuthorId = model.Author.Id ,
					Name = model.Name ,
					Description = model.Description
				};
				m_DataContext.AddBook ( book );
				m_DataContext.SaveAllChanges ();
			}
			

			return View ();
		}
    }
}