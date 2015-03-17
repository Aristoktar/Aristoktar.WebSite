using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Data.Interfaces;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Implementation {
	public class UserProvider : IUserProvider {

		private IDataContext m_DataContext;
		public UserProvider (IDataContext dataContext) {
			m_DataContext = dataContext;
		}
		public IQueryable<User> UserQuery {
			get {
				return m_DataContext.UsersQuery;
			}
		}

		
		public void SaveAllChanges () {
			m_DataContext.SaveAllChanges ();
		}


		public void AddUser ( User user ) {
			m_DataContext.AddUser ( user );
		}
	}
}
