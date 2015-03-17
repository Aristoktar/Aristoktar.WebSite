using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPortfolio.Logic.Entities;

namespace MyPortfolio.Logic.Data.Interfaces {
	public interface IUserProvider {
		IQueryable<User> UserQuery {
			get;
		}
		void AddUser(User user);
		void SaveAllChanges ();
	}
}
