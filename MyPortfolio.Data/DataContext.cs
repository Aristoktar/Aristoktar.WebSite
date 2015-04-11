using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Data
{
    public class DataContext :DbContext, IDataContext
    {
		/// <summary>
		/// Model creating handler.
		/// </summary>
		/// <param name="modelBuilder">Model builder.</param>
		protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
			base.OnModelCreating ( modelBuilder );
		}

		public DbSet<Book> Books {
			get;
			set;
		}
		public DbSet<Author> Authors {
			get;
			set;
		}

		public DbSet<User> Users {
			get;
			set;
		}
		
		public DbSet<ArticleCategory> ArticleCategories {
			get;
			set;
		}
		public DbSet<Article> Articles {
			get;
			set;
		}
		public DbSet<ArticlePart> ArticleParts {
			get;
			set;
		}

		public DbSet<EisenhowerTask> EisenhowerTasks {
			get;
			set;
		}


		


		public IQueryable<Book> BooksQuery {
			get {
				return Books;
			}
		}
		
		public IQueryable<User> UsersQuery {
			get {
				return Users;
			}
		}

		public void SaveAllChanges () {
			SaveChanges ();
		}





		public void AddUser ( User user ) {
			Users.Add ( user );
		}

		public void AddBook ( Book book ) {
			Books.Add ( book );
		}
		public void AddAuthor ( Author author ) {
			Authors.Add ( author );
		}
		public IQueryable<EisenhowerTask> EisenhowerTaskQuery {
			get {
				return EisenhowerTasks;
			}
		}



		public IQueryable<Author> AuthorsQuery {
			get {
				return Authors;
			}
		}



		
	}
}
