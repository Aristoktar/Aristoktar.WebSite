using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Interfaces {
	public interface IDataContext {

		IQueryable<EisenhowerTask> EisenhowerTaskQuery {
			get;
		}
		IQueryable<Book> BooksQuery {
			get;
		}
		IQueryable<User> UsersQuery {
			get;
		}
		void AddUser ( User user );
		void AddBook ( Book book );
		void SaveAllChanges ();
	}
}
