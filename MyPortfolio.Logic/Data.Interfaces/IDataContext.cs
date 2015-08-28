using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Interfaces {
	public interface IDataContext {

		#region Eisenhower
		IQueryable<EisenhowerTask> EisenhowerTaskQuery {
			get;
		}
		void AddEisenhowerTask ( EisenhowerTask task );
		void DeleteEisenhowerTask ( int TaskId ); 
		#endregion
		IQueryable<Book> BooksQuery {
			get;
		}
		IQueryable<Author> AuthorsQuery {
			get;
		}
		IQueryable<User> UsersQuery {
			get;
		}
		void AddUser ( User user );
		void AddBook ( Book book );
		void AddAuthor( Author author );
		void SaveAllChanges ();
	}
}
